using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Craft;
using Kingmaker.Designers.EventConditionActionSystem;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Spells
{
    public static class SummonAbilities
    {
        public class SummonAbility
        {
            /// <summary> GUID of the summon spell. </summary>
            internal string guid;
            /// <summary> Internal name of the ability </summary>
            internal string name;
            /// <summary> Guid of the spell that holds this variant, if any. </summary>
            internal string summonSpellBaseGuid;
            /// <summary> Level of the spell. </summary>
            internal int spellLevel;
            /// <summary>  IsFullRound true, it will use that instead of the action type. </summary>
            internal bool isFullRound;
            /// <summary>  Adds a crafting component to the spell. Defaulted to true, turn to false if creating an ability instead. </summary>
            internal bool craftingComponent = true;
            /// <summary> By default, summons use the Evil monster, this needs to be filled while the good monster does not. </summary>
            internal BlueprintUnitReference defaultMonster;
            /// <summary> Optional summon if a summon has a variant based on the alignment of the caster. Do not set if you only want the spell to summon a specific monster. </summary>
            internal BlueprintUnitReference goodMonster;
            /// <summary> Summon pool used by the ability. Various uses, mainly used for when the ability only has one summon at a time. </summary>
            internal BlueprintSummonPoolReference summonPool;
            /// <summary> The default summon buff. As far as I can tell it's used for the effects cast when they are summoned. </summary>
            internal BlueprintBuffReference summonBuff;
            /// <summary> If the user is good/neutral, this adds another buff. Usually used for adding the celestial template. </summary>
            internal BlueprintBuffReference goodBuff;
            /// <summary> If the user is evil, this adds another buff. Usually used for adding the fiendish template. </summary>
            internal BlueprintBuffReference evilBuff;
            /// <summary> List of spell list components. This is grouped up because an ability can belong to multiple spell lists. </summary>
            internal List<BlueprintSpellListReference> spellListComponents;
            /// <summary> DiceType that determines the amount of summons. </summary>
            internal DiceType numberOfSummons;
            /// <summary> DurationRate used to determined how many rounds/minutes/etc. are used per context rate. </summary>
            internal DurationRate durationRate;
            /// <summary> Duration that the player sees, shows on the ability. </summary>
            internal Duration localizationDuration;
            /// <summary> Action type used to for the ability. If IsFullRound true, it will use that instead. </summary>
            internal CommandType actionType;
            /// <summary> Name of the ability that is shown to the player. </summary>
            internal LocalizedString m_DisplayName;
            /// <summary> Description of the ability that is shown to the player. </summary>
            internal LocalizedString m_Description;
            /// <summary> Icon of the ability that is shown to the player. </summary>
            internal Sprite m_icon;
            /// <summary> Context Rank Config that will determine what the summon's duration is based off of.</summary>
            internal ContextRankConfig contextRankConfig;
            public SummonAbility()
            {
                goodBuff = BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.DummyBuff);
                evilBuff = BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.DummyBuff);
                localizationDuration = Duration.RoundPerLevel;
            }

        };

        public static SummonAbility[] summonAbilities =
        {
            new SummonAbility
            {
                name = "SummonerSummonISingle",
                guid = GetGUID.SummonerSummonISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIBase,
                spellLevel = 1,
                defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Description,
                actionType = CommandType.Standard,
                m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIISingle",
                guid = GetGUID.SummonerSummonIISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIBase,
                spellLevel = 2,
                defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIId3",
                guid = GetGUID.SummonerSummonIId3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIBase,
                spellLevel = 2,
                defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIId3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIId3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIId3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIIISingle",
                guid = GetGUID.SummonerSummonIIISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIIBase,
                spellLevel = 3,
                defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIIId3",
                guid = GetGUID.SummonerSummonIIId3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIIBase,
                spellLevel = 3,
                defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIVSingle",
                guid = GetGUID.SummonerSummonIVSingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIVBase,
                spellLevel = 4,
                defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIVd3",
                guid = GetGUID.SummonerSummonIVd3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIVBase,
                spellLevel = 4,
                defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVSingle",
                guid = GetGUID.SummonerSummonVSingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVBase,
                spellLevel = 5,
                defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVd3",
                guid = GetGUID.SummonerSummonVd3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVBase,
                spellLevel = 5,
                defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVd3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVd3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVd3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVISingle",
                guid = GetGUID.SummonerSummonVISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIBase,
                spellLevel = 6,
                defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVId3",
                guid = GetGUID.SummonerSummonVId3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIBase,
                spellLevel = 6,
                defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVId3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVId3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVId3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVIISingle",
                guid = GetGUID.SummonerSummonVIISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIBase,
                spellLevel = 7,
                defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                m_DisplayName = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVIId3",
                guid = GetGUID.SummonerSummonVIId3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIBase,
                spellLevel = 7,
                defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVIIISingle",
                guid = GetGUID.SummonerSummonVIIISingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIIBase,
                spellLevel = 8,
                defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonVIIId3",
                guid = GetGUID.SummonerSummonVIIId3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIIBase,
                spellLevel = 8,
                defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                m_DisplayName = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIXSingle",
                guid = GetGUID.SummonerSummonIXSingle,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIXBase,
                spellLevel = 9,
                defaultMonster = UnitRefs.ThanadaemonSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AzataGhaelSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel(),
                craftingComponent = false
            },
            new SummonAbility
            {
                name = "SummonerSummonIXd3",
                guid = GetGUID.SummonerSummonIXd3,
                summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIXBase,
                spellLevel = 9,
                defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                localizationDuration = Duration.MinutePerLevel,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_DisplayName,
                m_Description = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_Description,
                m_icon = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_Icon,
                actionType = CommandType.Standard,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CharacterLevel()
            },
            new SummonAbility
            {
                name = "SummonMinorMonsterRedPanda",
                guid = GetGUID.SummonMinorMonsterRedPanda,
                summonSpellBaseGuid = GetGUID.SummonMinorMonsterBase,
                spellLevel = 1,
                defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.RedPandaSummon),
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Rounds,
                localizationDuration = Duration.RoundPerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = Helpers.ObtainString("summonminormonsterredpanda.Name"),
                m_Description = Helpers.ObtainString("summonminormonsterredpanda.Description"),
                actionType = CommandType.Standard,
                isFullRound = true,
                m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CasterLevel()
            },
            new SummonAbility
            {
                name = "SummonMinorMonsterCat",
                guid = GetGUID.SummonMinorMonsterCat,
                summonSpellBaseGuid = GetGUID.SummonMinorMonsterBase,
                spellLevel = 1,
                defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.CatSummon),
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Rounds,
                localizationDuration = Duration.RoundPerLevel,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
                m_DisplayName = Helpers.ObtainString("SummonMinorMonsterCat.Name"),
                m_Description = Helpers.ObtainString("SummonMinorMonsterCat.Description"),
                actionType = CommandType.Standard,
                isFullRound = true,
                m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
                spellListComponents = new() { BlueprintTool.GetRef<BlueprintSpellListReference>(GetGUID.SummonerSecondSpellbookSpellList) },
                contextRankConfig = ContextRankConfigs.CasterLevel()
            },
        };

    }
}
