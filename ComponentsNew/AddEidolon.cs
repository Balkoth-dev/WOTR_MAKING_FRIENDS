// Decompiled with JetBrains decompiler
// Type: Kingmaker.UnitLogic.FactLogic.AddPet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 64D16269-EAD0-42E0-B6AE-F51781CAE9F7
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Wrath_Data\Managed\Assembly-CSharp.dll

using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.Items.Slots;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.View;
using Owlcat.QA.Validation;
using System;
using System.Linq;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("d918579b19d94c04b4c0baecd11fcb3c")]
    public class AddEidolon :
      UnitFactComponentDelegate<AddPetData>,
      IAreaHandler,
      IGlobalSubscriber,
      ISubscriber,
      IUpdatePet
    {
        public PetType Type;
        public PetProgressionType ProgressionType;
        [SerializeField]
        public BlueprintUnitReference m_Pet;
        [SerializeField]
        public bool m_UseContextValueLevel;
        [SerializeField]
        [HideIf("m_UseContextValueLevel")]
        public BlueprintFeatureReference m_LevelRank;
        [SerializeField]
        [ShowIf("m_UseContextValueLevel")]
        public ContextValue m_LevelContextValue;
        [SerializeField]
        public bool m_ForceAutoLevelup;
        [SerializeField]
        public BlueprintFeatureReference m_UpgradeFeature;
        [SerializeField]
        public bool m_DestroyPetOnDeactivate;
        public int UpgradeLevel;
        private static readonly int[] RankToLevelEidolon = new int[21]
        {
      0,
      2,
      3,
      3,
      4,
      5,
      6,
      7,
      8,
      9,
      10,
      11,
      12,
      13,
      14,
      15,
      16,
      17,
      18,
      19,
      20
        };

        public BlueprintUnit Pet => m_Pet?.Get();

        public BlueprintFeature LevelRank => m_LevelRank?.Get();

        public BlueprintFeature UpgradeFeature => m_UpgradeFeature?.Get();

        public override void OnActivate() => TryUpdatePet();

        public override void OnDeactivate()
        {
            if (IsReapplying || Data.Disabled)
            {
                return;
            }

            UnitEntityData unitEntityData = Data.SpawnedPetRef.Value;
            if (!(unitEntityData != null))
            {
                return;
            }

            foreach (ItemSlot equipmentSlot in unitEntityData.Body.EquipmentSlots)
            {
                if (equipmentSlot.HasItem && equipmentSlot.CanRemoveItem())
                {
                    equipmentSlot.RemoveItem();
                }

                equipmentSlot.Lock.Retain();
            }
            unitEntityData.RemoveMaster();
            if (m_DestroyPetOnDeactivate)
            {
                unitEntityData.MarkForDestroy();
            }

            AddEidolon.DeactivateAction current = ContextData<AddEidolon.DeactivateAction>.Current;
            if (current == null)
            {
                return;
            }

            current.Action(unitEntityData);
        }

        public void OnAreaBeginUnloading()
        {
        }

        public void OnAreaDidLoad() => TryUpdatePet();

        void IUpdatePet.TryUpdatePet() => TryUpdatePet();

        private void TryUpdatePet()
        {
            if (Data.Disabled || Owner.IsPet || !Owner.PreviewOf.IsEmpty)
            {
                return;
            }

            AddClassLevels.ExecutionMark current = ContextData<AddClassLevels.ExecutionMark>.Current;
            AddPetData data = Data;
            data.AutoLevelup = ((data.AutoLevelup ? 1 : 0) | (!(bool)(ContextData<AddClassLevels.ExecutionMark>)current ? 0 : (current.Unit != Owner ? 1 : 0))) != 0;
            Data.AutoLevelup |= m_ForceAutoLevelup;
            if (Owner.HoldingState == null)
            {
                EventBus.Subscribe(new AddEidolon.UnitSpawnHandler(this, Runtime));
            }
            else
            {
                UnitEntityData spawnedPet = Data.SpawnedPetRef.Value;
                bool flag = spawnedPet != null;
                UnitPartPetMaster unitPartPetMaster = Owner.Ensure<UnitPartPetMaster>();
                string id = unitPartPetMaster.Pets.FirstItem<EntityPartRef<UnitEntityData, UnitPartPet>>(i =>
                {
                    PetType? type5 = i.EntityPart?.Type;
                    PetType type6 = Type;
                    return type5.GetValueOrDefault() == type6 & type5.HasValue;
                }).EntityRef.Id;
                if (spawnedPet == null && id == null && !unitPartPetMaster.IsExPet(Type))
                {
                    Vector3 position = Owner.Position;
                    if (Owner.IsInGame)
                    {
                        FreePlaceSelector.PlaceSpawnPlaces(1, 0.5f, Owner.Position);
                        position = FreePlaceSelector.GetRelaxedPosition(0, true);
                    }
                    Data.SpawnedPetRef = spawnedPet = Game.Instance.EntityCreator.SpawnUnit(Pet, position, Quaternion.Euler(0.0f, Owner.Orientation, 0.0f), Owner.HoldingState);
                }
                else if (spawnedPet != null && id != null && spawnedPet.UniqueId != id)
                {
                    spawnedPet.MarkForDestroy();
                    if (!spawnedPet.IsPet)
                    {
                        spawnedPet.Descriptor.SwitchFactions(BlueprintRoot.Instance.SystemMechanics.FactionNeutrals);
                    }

                    Data.SpawnedPetRef = spawnedPet = null;
                    Data.Disabled = true;
                    PFLog.Default.Error(string.Format("Can't spawn second animal companion: {0}, {1}", Owner, Fact));
                }
                if (!(spawnedPet != null))
                {
                    return;
                }

                if (!unitPartPetMaster.IsExPet(spawnedPet.UniqueId) && spawnedPet.Master == null)
                {
                    spawnedPet.SetMaster(Owner, Type);
                    spawnedPet.IsInGame = Owner.IsInGame;
                }
                TryLevelUpPet();
                if (flag || !Game.Instance.Player.PartyCharacters.Contains(Owner))
                {
                    return;
                }

                EventBus.RaiseEvent<IPartyHandler>(h => h.HandleAddCompanion(spawnedPet));
            }
        }

        private int GetPetLevel()
        {
            if (m_UseContextValueLevel)
            {
                ContextValue levelContextValue = m_LevelContextValue;
                return levelContextValue == null ? 1 : levelContextValue.Calculate(Context);
            }
            if (!(bool)(SimpleBlueprint)LevelRank)
            {
                return 1;
            }

            EntityFact fact = Owner.GetFact(LevelRank);
            int index = Mathf.Min(20, fact != null ? fact.GetRank() : 0);
            switch (ProgressionType)
            {
                case PetProgressionType.AnimalCompanion:
                    return Math.Min(Owner.Progression.CharacterLevel, AddEidolon.RankToLevelEidolon[index]);
                default:
                    return 1;
            }
        }

        private void TryLevelUpPet()
        {
            UnitEntityData unitEntityData = Data.SpawnedPetRef.Value;
            if (unitEntityData == null)
            {
                return;
            }

            BlueprintComponentAndRuntime<AddClassLevels> componentAndRuntime = unitEntityData.Facts.List.Select<EntityFact, BlueprintComponentAndRuntime<AddClassLevels>>(f => f.GetComponentWithRuntime<AddClassLevels>()).FirstOrDefault<BlueprintComponentAndRuntime<AddClassLevels>>(c => c.Component != null);
            if (componentAndRuntime.Component == null)
            {
                return;
            }

            int characterLevel = unitEntityData.Descriptor.Progression.CharacterLevel;
            int petLevel = GetPetLevel();
            int levels = petLevel - characterLevel;
            if (levels > 0)
            {
                UnitPartCompanion unitPartCompanion = Owner.Get<UnitPartCompanion>();
                if ((unitPartCompanion == null || unitPartCompanion.State == CompanionState.None ? 0 : (unitPartCompanion.State != CompanionState.ExCompanion ? 1 : 0)) != 0 && !Data.AutoLevelup && Type == PetTypeExtensions.Eidolon)
                {
                    int bonus = BlueprintRoot.Instance.Progression.XPTable.GetBonus(petLevel);
                    unitEntityData.Progression.AdvanceExperienceTo(bonus, false, true);
                }
                else
                {
                    UnitEntityData master = unitEntityData.Master;
                    AddClassLevels addClassLevels;
                    if ((object)master == null)
                    {
                        addClassLevels = null;
                    }
                    else
                    {
                        BlueprintUnit blueprint = master.Blueprint;
                        addClassLevels = blueprint != null ? blueprint.GetComponent<AddClassLevelsToPets>()?.LevelsProgression : null;
                    }
                    AddClassLevels c = addClassLevels;
                    if (c != null)
                    {
                        AddClassLevels.LevelUp(c, unitEntityData.Descriptor, levels);
                    }
                    else
                    {
                        componentAndRuntime.Component.LevelUp(componentAndRuntime.Runtime, unitEntityData.Descriptor, levels);
                    }
                }
            }
            if (GetPetLevel() >= UpgradeLevel && UpgradeFeature != null)
            {
                unitEntityData.Progression.Features.AddFeature(UpgradeFeature);
            }

            Data.AutoLevelup = false;
        }

        public override void OnPostLoad()
        {
        }

        public override void OnApplyPostLoadFixes()
        {
            UnitEntityData _this = Data.SpawnedPetRef.Value;
            if (!(_this != null) || UpgradeFeature == null || GetPetLevel() < UpgradeLevel || _this.HasFact(UpgradeFeature))
            {
                return;
            }

            _this.Progression.Features.AddFeature(UpgradeFeature);
        }

        public override void ApplyValidation(ValidationContext context, int parentIndex)
        {
            base.ApplyValidation(context, parentIndex);
            if ((bool)(SimpleBlueprint)Pet)
            {
                return;
            }

            context.AddError("Pet is not specified");
        }

        public class DeactivateAction : ContextData<AddEidolon.DeactivateAction>
        {
            public Action<UnitEntityData> Action { get; private set; }

            public AddEidolon.DeactivateAction Setup(Action<UnitEntityData> action)
            {
                Action = action;
                return this;
            }

            public override void Reset() => Action = null;
        }

        private class UnitSpawnHandler :
          IUnitHandler,
          IGlobalSubscriber,
          ISubscriber,
          IUnitSpawnHandler,
          IAreaHandler
        {
            private readonly AddEidolon m_Feature;
            private readonly EntityFactComponentDelegate<UnitEntityData, AddPetData>.ComponentRuntime m_FeatureRuntime;

            public UnitSpawnHandler(
              AddEidolon feature,
              EntityFactComponentDelegate<UnitEntityData, AddPetData>.ComponentRuntime runtime)
            {
                m_Feature = feature;
                m_FeatureRuntime = runtime;
            }

            public void HandleUnitSpawned(UnitEntityData entityData)
            {
                if (!(entityData.Descriptor == m_FeatureRuntime.Owner))
                {
                    return;
                }

                if (entityData.View != null)
                {
                    using (m_FeatureRuntime.RequestEventContext())
                    {
                        m_Feature.TryUpdatePet();
                    }
                }
                EventBus.Unsubscribe(this);
            }

            public void HandleUnitDestroyed(UnitEntityData entityData)
            {
            }

            public void HandleUnitDeath(UnitEntityData entityData)
            {
            }

            public void OnAreaBeginUnloading() => EventBus.Unsubscribe(this);

            public void OnAreaDidLoad()
            {
            }
        }
    }
}
