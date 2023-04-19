using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using static Kingmaker.Designers.Mechanics.Buffs.ChangeUnitSize;
using static Kingmaker.UnitLogic.FactLogic.LockEquipmentSlot;
using static WOTR_MAKING_FRIENDS.Enums.EidolonEnums;

namespace WOTR_MAKING_FRIENDS.Units
{
    internal class CreateUnits
    {
        internal static readonly BlueprintBrainReference characterBrain = BlueprintTool.Get<BlueprintBrain>("cf986dd7ba9d4ec46ad8a3a0406d02ae").ToReference<BlueprintBrainReference>();
        public static void CreateAllUnits()
        {
            CreateUnitsFromArray(NewSummons.newUnits);
            CreateUnitsFromArray(NewEidolons.newUnits);
            AdjustSummons();
            foreach (var eidolon in NewEidolons.newUnits)
            {
                AdjustEidolon(eidolon);
            }
        }
        internal static void CreateUnitsFromArray(Array newUnits)
        {
            foreach (NewUnit newUnit in newUnits)
            {
                BlueprintUnit copiedUnit = BlueprintTool.Get<BlueprintUnit>(newUnit.copiedUnit.ToString());

                SharedStringAsset sharedStringAsset = ScriptableObject.CreateInstance<SharedStringAsset>();
                sharedStringAsset.String = newUnit.m_DisplayName ?? copiedUnit.LocalizedName.String;

                UnitConfigurator unitConfigured = UnitConfigurator.New(newUnit.name, newUnit.guid)
                    .CopyFrom(newUnit.copiedUnit, c => c is not null)
                    .SetLocalizedName(sharedStringAsset)
                    .SetDisplayName(newUnit.m_DisplayName ?? copiedUnit.m_DisplayName)
                    .SetPrefab(newUnit.prefab ?? copiedUnit.Prefab)
                    .SetPortrait(newUnit.portrait ?? copiedUnit.m_Portrait)
                    .SetStrength(newUnit.strength ?? copiedUnit.Strength)
                    .SetDexterity(newUnit.dexterity ?? copiedUnit.Dexterity)
                    .SetConstitution(newUnit.constitution ?? copiedUnit.Constitution)
                    .SetIntelligence(newUnit.intelligence ?? copiedUnit.Intelligence)
                    .SetWisdom(newUnit.wisdom ?? copiedUnit.Wisdom)
                    .SetCharisma(newUnit.charisma ?? copiedUnit.Charisma)
                    .SetSize(newUnit.size ?? copiedUnit.Size)
                    .SetFaction(FactionRefs.Neutrals.Cast<BlueprintFactionReference>().Reference);

                if (newUnit.isSummon)
                {
                    unitConfigured.AddUnitUpgraderComponent(null, ComponentMerge.Skip, new() { UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.Reference.Get().AssetGuid });
                    unitConfigured.AddBuffOnEntityCreated(BuffRefs.SummonedCreatureVisual.Cast<BlueprintBuffReference>().Reference);
                    unitConfigured.AddBuffOnEntityCreated(BuffRefs.Unlootable.Cast<BlueprintBuffReference>().Reference);
                }

                if (newUnit.blueprintUnitFactReferences != null)
                {
                    unitConfigured.SetAddFacts(newUnit.blueprintUnitFactReferences);
                }
                unitConfigured.Configure();
                Main.Log(newUnit.name + " : " + newUnit.guid + " created.");
            }

        }
        internal static void AdjustEidolon(NewUnit eidolonUnit)
        {
            var eidolon = UnitConfigurator.For(eidolonUnit.guid)
                            .RemoveComponents(components => components is not null)
                            .AddAllowDyingCondition()
                            .AddResurrectOnRest()
                            .SetBrain(characterBrain)
                            .SetBody(new BlueprintUnit.UnitBody() { })
                    .AddClassLevels(null, CharacterClassRefs.AnimalCompanionClass.Cast<BlueprintCharacterClassReference>().Reference, null, 0, StatType.Unknown, null, StatType.Constitution, skills: new StatType[] { StatType.SkillPerception });

            if (eidolonUnit.eidolonBaseForm == EidolonBaseFormEnums.Abberant)
            {
                eidolon.SetStrength(12)
                    .SetDexterity(13)
                    .SetConstitution(16)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .SetBody(new BlueprintUnit.UnitBody()
                    {
                        PrimaryHand = ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference,
                        m_AdditionalLimbs = new BlueprintItemWeaponReference[] { ItemWeaponRefs.TentacleLarge1d6.Cast<BlueprintItemWeaponReference>().Reference }
                    })
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(20.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EidolonBaseFormEnums.Biped)
            {
                eidolon.SetStrength(16)
                    .SetDexterity(12)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.Cast<BlueprintItemWeaponReference>().Reference)
                    .SetSpeed(30.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EidolonBaseFormEnums.Quadruped)
            {
                eidolon.SetStrength(14)
                    .SetDexterity(14)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .SetBody(new BlueprintUnit.UnitBody()
                    {
                        PrimaryHand = ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference
                    })
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(40.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EidolonBaseFormEnums.Serpentine)
            {
                eidolon.SetStrength(12)
                    .SetDexterity(16)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .SetBody(new BlueprintUnit.UnitBody()
                    {
                        PrimaryHand = ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference,
                        m_AdditionalLimbs = new BlueprintItemWeaponReference[] { ItemWeaponRefs.Tail1d6.Cast<BlueprintItemWeaponReference>().Reference }
                    })
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(20.Feet());
            }

            eidolon.Configure();
        }
        internal static void AdjustSummons()
        {
            AdjustCacodaemon();
            AdjustDraconicAllies();
            AdjustStampedeSummonHorse();
            AdjustReleaseTheHoundsWolf();
            AdjustMeladaemon();
        }

        private static void AdjustMeladaemon()
        {
            UnitConfigurator.For(GetGUID.MeladaemonSummon)
                .AddChangeUnitSize(null, ComponentMerge.Replace, Size.Large, 1, ChangeType.Value)
                .RemoveComponents(components => components is AddClassLevels)
                .AddClassLevels(null, CharacterClassRefs.OutsiderClass.Cast<BlueprintCharacterClassReference>().Reference, null, 14, StatType.Unknown, null, StatType.Constitution)
                .SetAlignment(Alignment.NeutralEvil)
                .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.MeladaemonBrain))
                .SetBody(new BlueprintUnit.UnitBody()
                {
                    PrimaryHand = ItemWeaponRefs.Bite2d6.Cast<BlueprintItemWeaponReference>().Reference,
                    m_AdditionalLimbs = new BlueprintItemWeaponReference[] { ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference,
                                                                             ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference}
                }
                    )
                .Configure();
        }

        private static void AdjustReleaseTheHoundsWolf()
        {
            UnitConfigurator.For(GetGUID.ReleaseTheHoundsWolf)
                    .RemoveComponents(components => components is AddClassLevels)
                    .AddClassLevels(null, CharacterClassRefs.AnimalClass.Cast<BlueprintCharacterClassReference>().Reference, null, 6, StatType.Unknown, null, StatType.Constitution)
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.StampedeHorseBrain))
                    .Configure();
        }

        internal static void AdjustCacodaemon()
        {
            UnitConfigurator.For(GetGUID.CacodaemonSummon)
                .AddChangeUnitSize(null, ComponentMerge.Replace, Size.Fine, -2, ChangeType.Value)
                .RemoveComponents(components => components is AddClassLevels)
                .AddClassLevels(null, CharacterClassRefs.OutsiderClass.Cast<BlueprintCharacterClassReference>().Reference, null, 3, StatType.Unknown, null, StatType.Constitution)
                .AddBuffOnEntityCreated(BuffRefs.InvisibilityBuff.Cast<BlueprintBuffReference>().Reference)
                .AddBuffOnEntityCreated(BuffRefs.FastHealing2.Cast<BlueprintBuffReference>().Reference)
                .SetAlignment(Alignment.NeutralEvil)
                .SetBody(new BlueprintUnit.UnitBody() { PrimaryHand = ItemWeaponRefs.Bite1d4.Cast<BlueprintItemWeaponReference>().Reference })
                .Configure();
        }
        internal static void AdjustDraconicAllies()
        {
            string[] draconicAllies =
                {
                    GetGUID.DraconicAllySummonBlack,
                    GetGUID.DraconicAllySummonBlue,
                    GetGUID.DraconicAllySummonBrass,
                    GetGUID.DraconicAllySummonGreen,
                    GetGUID.DraconicAllySummonRed,
                    GetGUID.DraconicAllySummonSilver,
                    GetGUID.DraconicAllySummonWhite
                };

            foreach (string guid in draconicAllies)
            {
                UnitConfigurator.For(guid)
                    .RemoveComponents(components => components is AddClassLevels)
                    .AddClassLevels(null, CharacterClassRefs.DragonClass.Cast<BlueprintCharacterClassReference>().Reference, false, 2, StatType.Unknown, null, StatType.Constitution)
                    .SetAlignment(Alignment.NeutralGood)
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.DraconicAllyBrain))
                    .Configure();
            }
        }

        private static void AdjustStampedeSummonHorse()
        {
            UnitConfigurator.For(GetGUID.StampedeSummonHorse)
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.StampedeHorseBrain))
                    .Configure();
        }
    }
}
