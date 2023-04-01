// Decompiled with JetBrains decompiler
// Type: Kingmaker.UnitLogic.FactLogic.AddPet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 64D16269-EAD0-42E0-B6AE-F51781CAE9F7
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Wrath_Data\Managed\Assembly-CSharp.dll

using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
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

        public BlueprintUnit Pet => this.m_Pet?.Get();

        public BlueprintFeature LevelRank => this.m_LevelRank?.Get();

        public BlueprintFeature UpgradeFeature => this.m_UpgradeFeature?.Get();

        public override void OnActivate() => this.TryUpdatePet();

        public override void OnDeactivate()
        {
            if (this.IsReapplying || this.Data.Disabled)
                return;
            UnitEntityData unitEntityData = this.Data.SpawnedPetRef.Value;
            if (!(unitEntityData != (UnitDescriptor)null))
                return;
            foreach (ItemSlot equipmentSlot in unitEntityData.Body.EquipmentSlots)
            {
                if (equipmentSlot.HasItem && equipmentSlot.CanRemoveItem())
                    equipmentSlot.RemoveItem();
                equipmentSlot.Lock.Retain();
            }
            unitEntityData.RemoveMaster();
            if (this.m_DestroyPetOnDeactivate)
                unitEntityData.MarkForDestroy();
            AddEidolon.DeactivateAction current = ContextData<AddEidolon.DeactivateAction>.Current;
            if (current == null)
                return;
            current.Action(unitEntityData);
        }

        public void OnAreaBeginUnloading()
        {
        }

        public void OnAreaDidLoad() => this.TryUpdatePet();

        void IUpdatePet.TryUpdatePet() => this.TryUpdatePet();

        private void TryUpdatePet()
        {
            if (this.Data.Disabled || this.Owner.IsPet || !this.Owner.PreviewOf.IsEmpty)
                return;
            AddClassLevels.ExecutionMark current = ContextData<AddClassLevels.ExecutionMark>.Current;
            AddPetData data = this.Data;
            data.AutoLevelup = ((data.AutoLevelup ? 1 : 0) | (!(bool)(ContextData<AddClassLevels.ExecutionMark>)current ? 0 : (current.Unit != (UnitDescriptor)this.Owner ? 1 : 0))) != 0;
            this.Data.AutoLevelup |= this.m_ForceAutoLevelup;
            if (this.Owner.HoldingState == null)
            {
                EventBus.Subscribe((object)new AddEidolon.UnitSpawnHandler(this, this.Runtime));
            }
            else
            {
                UnitEntityData spawnedPet = this.Data.SpawnedPetRef.Value;
                bool flag = spawnedPet != (UnitDescriptor)null;
                UnitPartPetMaster unitPartPetMaster = this.Owner.Ensure<UnitPartPetMaster>();
                string id = unitPartPetMaster.Pets.FirstItem<EntityPartRef<UnitEntityData, UnitPartPet>>((Func<EntityPartRef<UnitEntityData, UnitPartPet>, bool>)(i =>
                {
                    PetType? type5 = i.EntityPart?.Type;
                    PetType type6 = this.Type;
                    return type5.GetValueOrDefault() == type6 & type5.HasValue;
                })).EntityRef.Id;
                if (spawnedPet == (UnitDescriptor)null && id == null && !unitPartPetMaster.IsExPet(this.Type))
                {
                    Vector3 position = this.Owner.Position;
                    if (this.Owner.IsInGame)
                    {
                        FreePlaceSelector.PlaceSpawnPlaces(1, 0.5f, this.Owner.Position);
                        position = FreePlaceSelector.GetRelaxedPosition(0, true);
                    }
                    this.Data.SpawnedPetRef = (UnitReference)(spawnedPet = Game.Instance.EntityCreator.SpawnUnit(this.Pet, position, Quaternion.Euler(0.0f, this.Owner.Orientation, 0.0f), this.Owner.HoldingState));
                }
                else if (spawnedPet != (UnitDescriptor)null && id != null && spawnedPet.UniqueId != id)
                {
                    spawnedPet.MarkForDestroy();
                    if (!spawnedPet.IsPet)
                        spawnedPet.Descriptor.SwitchFactions(BlueprintRoot.Instance.SystemMechanics.FactionNeutrals);
                    this.Data.SpawnedPetRef = (UnitReference)(spawnedPet = (UnitEntityData)null);
                    this.Data.Disabled = true;
                    PFLog.Default.Error(string.Format("Can't spawn second animal companion: {0}, {1}", (object)this.Owner, (object)this.Fact));
                }
                if (!(spawnedPet != (UnitDescriptor)null))
                    return;
                if (!unitPartPetMaster.IsExPet(spawnedPet.UniqueId) && spawnedPet.Master == (UnitDescriptor)null)
                {
                    spawnedPet.SetMaster(this.Owner, this.Type);
                    spawnedPet.IsInGame = this.Owner.IsInGame;
                }
                this.TryLevelUpPet();
                if (flag || !Game.Instance.Player.PartyCharacters.Contains((UnitReference)this.Owner))
                    return;
                EventBus.RaiseEvent<IPartyHandler>((Action<IPartyHandler>)(h => h.HandleAddCompanion(spawnedPet)));
            }
        }

        private int GetPetLevel()
        {
            if (this.m_UseContextValueLevel)
            {
                ContextValue levelContextValue = this.m_LevelContextValue;
                return levelContextValue == null ? 1 : levelContextValue.Calculate(this.Context);
            }
            if (!(bool)(SimpleBlueprint)this.LevelRank)
                return 1;
            EntityFact fact = this.Owner.GetFact((BlueprintUnitFact)this.LevelRank);
            int index = Mathf.Min(20, fact != null ? fact.GetRank() : 0);
            switch (this.ProgressionType)
            {
                case PetProgressionType.AnimalCompanion:
                    return Math.Min(this.Owner.Progression.CharacterLevel, AddEidolon.RankToLevelEidolon[index]);
                default:
                    return 1;
            }
        }

        private void TryLevelUpPet()
        {
            UnitEntityData unitEntityData = this.Data.SpawnedPetRef.Value;
            if (unitEntityData == (UnitDescriptor)null)
                return;
            BlueprintComponentAndRuntime<AddClassLevels> componentAndRuntime = unitEntityData.Facts.List.Select<EntityFact, BlueprintComponentAndRuntime<AddClassLevels>>((Func<EntityFact, BlueprintComponentAndRuntime<AddClassLevels>>)(f => f.GetComponentWithRuntime<AddClassLevels>())).FirstOrDefault<BlueprintComponentAndRuntime<AddClassLevels>>((Func<BlueprintComponentAndRuntime<AddClassLevels>, bool>)(c => c.Component != null));
            if (componentAndRuntime.Component == null)
                return;
            int characterLevel = unitEntityData.Descriptor.Progression.CharacterLevel;
            int petLevel = this.GetPetLevel();
            int levels = petLevel - characterLevel;
            if (levels > 0)
            {
                UnitPartCompanion unitPartCompanion = this.Owner.Get<UnitPartCompanion>();
                if ((unitPartCompanion == null || unitPartCompanion.State == CompanionState.None ? 0 : (unitPartCompanion.State != CompanionState.ExCompanion ? 1 : 0)) != 0 && !this.Data.AutoLevelup && this.Type == PetTypeExtensions.Eidolon)
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
                        addClassLevels = (AddClassLevels)null;
                    }
                    else
                    {
                        BlueprintUnit blueprint = master.Blueprint;
                        addClassLevels = blueprint != null ? blueprint.GetComponent<AddClassLevelsToPets>()?.LevelsProgression : (AddClassLevels)null;
                    }
                    AddClassLevels c = addClassLevels;
                    if (c != null)
                        AddClassLevels.LevelUp(c, unitEntityData.Descriptor, levels);
                    else
                        componentAndRuntime.Component.LevelUp(componentAndRuntime.Runtime, unitEntityData.Descriptor, levels);
                }
            }
            if (this.GetPetLevel() >= this.UpgradeLevel && this.UpgradeFeature != null)
                unitEntityData.Progression.Features.AddFeature(this.UpgradeFeature);
            this.Data.AutoLevelup = false;
        }

        public override void OnPostLoad()
        {
        }

        public override void OnApplyPostLoadFixes()
        {
            UnitEntityData _this = this.Data.SpawnedPetRef.Value;
            if (!(_this != (UnitDescriptor)null) || this.UpgradeFeature == null || this.GetPetLevel() < this.UpgradeLevel || _this.HasFact((BlueprintFact)this.UpgradeFeature))
                return;
            _this.Progression.Features.AddFeature(this.UpgradeFeature);
        }

        public override void ApplyValidation(ValidationContext context, int parentIndex)
        {
            base.ApplyValidation(context, parentIndex);
            if ((bool)(SimpleBlueprint)this.Pet)
                return;
            context.AddError("Pet is not specified");
        }

        public class DeactivateAction : ContextData<AddEidolon.DeactivateAction>
        {
            public Action<UnitEntityData> Action { get; private set; }

            public AddEidolon.DeactivateAction Setup(Action<UnitEntityData> action)
            {
                this.Action = action;
                return this;
            }

            public override void Reset() => this.Action = (Action<UnitEntityData>)null;
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
                this.m_Feature = feature;
                this.m_FeatureRuntime = runtime;
            }

            public void HandleUnitSpawned(UnitEntityData entityData)
            {
                if (!((UnitEntityData)entityData.Descriptor == (UnitDescriptor)this.m_FeatureRuntime.Owner))
                    return;
                if ((UnityEngine.Object)entityData.View != (UnityEngine.Object)null)
                {
                    using (this.m_FeatureRuntime.RequestEventContext())
                        this.m_Feature.TryUpdatePet();
                }
                EventBus.Unsubscribe((object)this);
            }

            public void HandleUnitDestroyed(UnitEntityData entityData)
            {
            }

            public void HandleUnitDeath(UnitEntityData entityData)
            {
            }

            public void OnAreaBeginUnloading() => EventBus.Unsubscribe((object)this);

            public void OnAreaDidLoad()
            {
            }
        }
    }
}
