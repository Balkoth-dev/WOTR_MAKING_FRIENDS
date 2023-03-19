﻿using BlueprintCore.Blueprints.Configurators;
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

namespace WOTR_MAKING_FRIENDS.Units
{
    class CreateUnits
    {
        public static void CreateAllUnits()
        {
            foreach (NewUnit newUnit in newUnits)
            {

                var unitConfigured = UnitConfigurator.New(newUnit.name, newUnit.guid)
                    .CopyFrom(newUnit.copiedUnit)
                    .SetDisplayName(newUnit.m_DisplayName)
                    .SetLocalizedName(new SharedStringAsset() { String = newUnit.m_DisplayName })
                    .SetStrength(newUnit.strength)
                    .SetDexterity(newUnit.dexterity)
                    .SetConstitution(newUnit.constitution)
                    .SetIntelligence(newUnit.intelligence)
                    .SetWisdom(newUnit.wisdom)
                    .SetCharisma(newUnit.charisma)
                    .SetSize(newUnit.size)
                    .AddBuffOnEntityCreated(BuffRefs.SummonedCreatureVisual.Cast<BlueprintBuffReference>().Reference)
                    .AddBuffOnEntityCreated(BuffRefs.Unlootable.Cast<BlueprintBuffReference>().Reference)
                    .SetAddFacts(newUnit.blueprintUnitFactReferences);

                if (newUnit.prefab != null)
                    unitConfigured.SetPrefab(newUnit.prefab);

                if (newUnit.portrait != null)
                    unitConfigured.SetPortrait(newUnit.portrait);

                unitConfigured.Configure();
            }
            AdjustUnits();

        }
        internal static void AdjustUnits()
        {
            AdjustCacodaemon();
            AdjustDraconicAllies();
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
                    .AddUnitUpgraderComponent(null, ComponentMerge.Replace, new() { UnitUpgraderRefs.PF_359232_RemoveBrokenSummonOnLoad.Reference.Get().AssetGuid })
                    .SetBrain(BlueprintTool.GetRef<BlueprintBrainReference>(GetGUID.DraconicAllyBrain))
                    .Configure();
            }
        }
    }
}
