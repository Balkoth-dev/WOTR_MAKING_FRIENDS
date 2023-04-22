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
using WOTR_MAKING_FRIENDS.Classes.EidolonClasses;
using WOTR_MAKING_FRIENDS.GUIDs;
using static Kingmaker.Designers.Mechanics.Buffs.ChangeUnitSize;
using static Kingmaker.UnitLogic.FactLogic.LockEquipmentSlot;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;
using WOTR_MAKING_FRIENDS.Utilities;
using HarmonyLib;
using System.Linq;

namespace WOTR_MAKING_FRIENDS.Units
{
    internal class CreateUnits
    {
        internal static readonly BlueprintBrainReference characterBrain = BlueprintTool.Get<BlueprintBrain>("cf986dd7ba9d4ec46ad8a3a0406d02ae").ToReference<BlueprintBrainReference>();
        public static void CreateAllUnits()
        {
            CreateUnitsFromArray(UnitSummons.newUnits);
            CreateUnitsFromArray(UnitEidolons.newUnits);
            AdjustSummons();
            foreach (var eidolon in UnitEidolons.newUnits)
            {
                try
                {
                    AdjustEidolon(eidolon);
                }
                catch { }
            }
        }
        internal static void CreateUnitsFromArray(Array newUnits)
        {
            foreach (NewUnitClass newUnit in newUnits)
            {
                try
                {
                    BlueprintUnit copiedUnit = BlueprintTool.Get<BlueprintUnit>(newUnit.copiedUnit.ToString());

                    SharedStringAsset sharedStringAsset = ScriptableObject.CreateInstance<SharedStringAsset>();
                    sharedStringAsset.String = newUnit.m_DisplayName ?? copiedUnit.LocalizedName.String;

                    UnitConfigurator unitConfigured = UnitConfigurator.New(newUnit.Name, newUnit.Guid)
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
                    unitConfigured.ConfigureWithLogging();
                }
                catch(Exception ex)
                {
                    Main.Log(ex.ToString());
                }
            }

        }
        internal static void AdjustEidolon(NewUnitClass eidolonUnit)
        {
            var featureBaseForm = GetGUID.GUIDByName("Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonUnit.eidolonBaseForm) + "BaseFormFeature");
            var featureSubtype = GetGUID.GUIDByName("Eidolon" + Enum.GetName(typeof(EnumsEidolonSubtype), eidolonUnit.eidolonSubtype) + "SubtypeFeature");

            var newFacts = new Blueprint<BlueprintUnitFactReference>[] {
                                         FeatureRefs.OutsiderType.Cast<BlueprintUnitFactReference>().Reference,
                                         FeatureRefs.HeadLocatorFeature.Cast<BlueprintUnitFactReference>().Reference,
                                         BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonSubtypeFeature")),
                                         BlueprintTool.GetRef<BlueprintUnitFactReference>(featureBaseForm),
                                         BlueprintTool.GetRef<BlueprintUnitFactReference>(featureSubtype) };

            if (eidolonUnit.blueprintUnitFactReferences != null)
            {
                eidolonUnit.blueprintUnitFactReferences = eidolonUnit.blueprintUnitFactReferences.Concat(newFacts).ToArray();
            }
            else
            {
                eidolonUnit.blueprintUnitFactReferences = newFacts;
            }

            var eidolon = UnitConfigurator.For(eidolonUnit.Guid)
                            .RemoveComponents(components => components is not null)
                            .AddAllowDyingCondition()
                            .AddResurrectOnRest()
                            .SetBrain(characterBrain)
                            .SetBody(new BlueprintUnit.UnitBody() { })
                            .SetAddFacts(eidolonUnit.blueprintUnitFactReferences)
                            .AddClassLevels(null, BlueprintTool.GetRef<BlueprintCharacterClassReference>(GetGUID.GUIDByName("EidolonBaseClass")), null, 0, StatType.Unknown, null, StatType.Constitution, skills: new StatType[] { StatType.SkillPerception }); ;

            if (eidolonUnit.eidolonBaseForm == EnumsEidolonBaseForm.Abberant)
            {
                eidolon.SetStrength(12)
                    .SetDexterity(13)
                    .SetConstitution(16)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(20.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EnumsEidolonBaseForm.Biped)
            {
                eidolon.SetStrength(16)
                    .SetDexterity(12)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .SetSpeed(30.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EnumsEidolonBaseForm.Quadruped)
            {
                eidolon.SetStrength(14)
                    .SetDexterity(14)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(40.Feet());
            }
            else if (eidolonUnit.eidolonBaseForm == EnumsEidolonBaseForm.Serpentine)
            {
                eidolon.SetStrength(12)
                    .SetDexterity(16)
                    .SetConstitution(13)
                    .SetIntelligence(7)
                    .SetWisdom(10)
                    .SetCharisma(11)
                    .AddLockEquipmentSlot(slotType: SlotType.MainHand)
                    .AddLockEquipmentSlot(slotType: SlotType.OffHand)
                    .SetSpeed(20.Feet());
            }

            eidolon.ConfigureWithLogging();
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
            UnitConfigurator.For(GetGUID.GUIDByName("MeladaemonSummon"))
                .AddChangeUnitSize(null, ComponentMerge.Replace, Size.Large, 1, ChangeType.Value)
                .RemoveComponents(components => components is AddClassLevels)
                .AddClassLevels(null, CharacterClassRefs.OutsiderClass.Cast<BlueprintCharacterClassReference>().Reference, null, 14, StatType.Unknown, null, StatType.Constitution)
                .SetAlignment(Alignment.NeutralEvil)
                .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.GUIDByName("MeladaemonBrain")))
                .SetBody(new BlueprintUnit.UnitBody()
                {
                    PrimaryHand = ItemWeaponRefs.Bite2d6.Cast<BlueprintItemWeaponReference>().Reference,
                    m_AdditionalLimbs = new BlueprintItemWeaponReference[] { ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference,
                                                                             ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference}
                }
                    )
                .ConfigureWithLogging();
        }

        private static void AdjustReleaseTheHoundsWolf()
        {
            UnitConfigurator.For(GetGUID.GUIDByName("ReleaseTheHoundsWolf"))
                    .RemoveComponents(components => components is AddClassLevels)
                    .AddClassLevels(null, CharacterClassRefs.AnimalClass.Cast<BlueprintCharacterClassReference>().Reference, null, 6, StatType.Unknown, null, StatType.Constitution)
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.GUIDByName("StampedeHorseBrain")))
                    .ConfigureWithLogging();
        }

        internal static void AdjustCacodaemon()
        {
            UnitConfigurator.For(GetGUID.GUIDByName("CacodaemonSummon"))
                .AddChangeUnitSize(null, ComponentMerge.Replace, Size.Fine, -2, ChangeType.Value)
                .RemoveComponents(components => components is AddClassLevels)
                .AddClassLevels(null, CharacterClassRefs.OutsiderClass.Cast<BlueprintCharacterClassReference>().Reference, null, 3, StatType.Unknown, null, StatType.Constitution)
                .AddBuffOnEntityCreated(BuffRefs.InvisibilityBuff.Cast<BlueprintBuffReference>().Reference)
                .AddBuffOnEntityCreated(BuffRefs.FastHealing2.Cast<BlueprintBuffReference>().Reference)
                .SetAlignment(Alignment.NeutralEvil)
                .SetBody(new BlueprintUnit.UnitBody() { PrimaryHand = ItemWeaponRefs.Bite1d4.Cast<BlueprintItemWeaponReference>().Reference })
                .ConfigureWithLogging();
        }
        internal static void AdjustDraconicAllies()
        {
            string[] draconicAllies =
                {
                    GetGUID.GUIDByName("DraconicAllySummonBlack"),
                    GetGUID.GUIDByName("DraconicAllySummonBlue"),
                    GetGUID.GUIDByName("DraconicAllySummonBrass"),
                    GetGUID.GUIDByName("DraconicAllySummonGreen"),
                    GetGUID.GUIDByName("DraconicAllySummonRed"),
                    GetGUID.GUIDByName("DraconicAllySummonSilver"),
                    GetGUID.GUIDByName("DraconicAllySummonWhite")
                };

            foreach (string guid in draconicAllies)
            {
                UnitConfigurator.For(guid)
                    .RemoveComponents(components => components is AddClassLevels)
                    .AddClassLevels(null, CharacterClassRefs.DragonClass.Cast<BlueprintCharacterClassReference>().Reference, false, 2, StatType.Unknown, null, StatType.Constitution)
                    .SetAlignment(Alignment.NeutralGood)
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.GUIDByName("DraconicAllyBrain")))
                    .ConfigureWithLogging();
            }
        }

        private static void AdjustStampedeSummonHorse()
        {
            UnitConfigurator.For(GetGUID.GUIDByName("StampedeSummonHorse"))
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.GUIDByName("StampedeHorseBrain")))
                    .ConfigureWithLogging();
        }
    }
}
