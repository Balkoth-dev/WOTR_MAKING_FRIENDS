using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using Kingmaker.Enums;
using static WOTR_MAKING_FRIENDS.Units.NewUnits;
using static Kingmaker.Designers.Mechanics.Buffs.ChangeUnitSize;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Class.LevelUp.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Items;
using Kingmaker.EntitySystem.Persistence.Versioning;
using BlueprintCore.Actions.Builder;
using Kingmaker.AI.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Experience;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.Units
{
    class CreateUnits
    {
        public static void CreateAllUnits()
        {
            foreach (NewUnit newUnit in newUnits)
            {
                var copiedUnit = BlueprintTool.Get<BlueprintUnit>(newUnit.copiedUnit.ToString());

                var sharedStringAsset = ScriptableObject.CreateInstance<SharedStringAsset>();
                sharedStringAsset.String = newUnit.m_DisplayName ?? copiedUnit.LocalizedName.String;

                var unitConfigured = UnitConfigurator.New(newUnit.name, newUnit.guid)
                    .CopyFrom(newUnit.copiedUnit)
                    .CopyFrom(newUnit.copiedUnit, c => c is not null)
                    .SetLocalizedName(sharedStringAsset)
                    .AddBuffOnEntityCreated(BuffRefs.SummonedCreatureVisual.Cast<BlueprintBuffReference>().Reference)
                    .AddBuffOnEntityCreated(BuffRefs.Unlootable.Cast<BlueprintBuffReference>().Reference)
                    .AddUnitUpgraderComponent(null, ComponentMerge.Skip, new() { UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.Reference.Get().AssetGuid })
                    .SetDisplayName(newUnit.m_DisplayName ?? copiedUnit.m_DisplayName)
                    .SetPrefab(newUnit.prefab ?? copiedUnit.Prefab)
                    .SetPortrait(newUnit.portrait ?? copiedUnit.m_Portrait)
                    .SetStrength(newUnit.strength ?? copiedUnit.Strength)
                    .SetDexterity(newUnit.dexterity ?? copiedUnit.Dexterity)
                    .SetConstitution(newUnit.constitution ?? copiedUnit.Constitution)
                    .SetIntelligence(newUnit.intelligence ?? copiedUnit.Intelligence)
                    .SetWisdom(newUnit.wisdom ?? copiedUnit.Wisdom)
                    .SetCharisma(newUnit.charisma ?? copiedUnit.Charisma)
                    .SetSize(newUnit.size ?? copiedUnit.Size);

                if(newUnit.blueprintUnitFactReferences != null)
                    unitConfigured.SetAddFacts(newUnit.blueprintUnitFactReferences);

                unitConfigured.Configure();
            }
            AdjustUnits();

        }
        internal static void AdjustUnits()
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
                .SetBody(new BlueprintUnit.UnitBody() { 
                    PrimaryHand = ItemWeaponRefs.Bite2d6.Cast<BlueprintItemWeaponReference>().Reference, 
                    m_AdditionalLimbs = new BlueprintItemWeaponReference[] { ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference,
                                                                             ItemWeaponRefs.Claw2d6.Cast<BlueprintItemWeaponReference>().Reference} }
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
                .AddChangeUnitSize(null,ComponentMerge.Replace,Size.Fine,-2,ChangeType.Value)
                .RemoveComponents(components => components is AddClassLevels)
                .AddClassLevels(null,CharacterClassRefs.OutsiderClass.Cast<BlueprintCharacterClassReference>().Reference,null,3,StatType.Unknown,null,StatType.Constitution)
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

            foreach (var guid in draconicAllies)
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
