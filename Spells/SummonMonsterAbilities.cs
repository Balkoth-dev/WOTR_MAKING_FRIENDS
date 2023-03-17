using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
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
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Spells
{
    public static class SummonMonsterAbilities
    {
        public class SummonAbility
        {
            internal string guid;
            internal int spellLevel;
            /// <summary>
            /// By default, summons use the Evil monster, this needs to be filled while the good monster does not.
            /// </summary>
            internal BlueprintUnitReference defaultMonster;
            internal BlueprintUnitReference goodMonster;
            internal BlueprintBuffReference summonBuff;
            internal BlueprintSummonPoolReference summonPool;
            internal DiceType numberOfSummons;
            internal DurationRate durationRate;
            internal BlueprintBuffReference goodBuff;
            internal BlueprintBuffReference evilBuff;
        };

        public static List<SummonAbility> summonAbilities = new()
        {
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonISingle,
                spellLevel = 1,
                defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIISingle,
                spellLevel = 2,
                defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIId3,
                spellLevel = 2,
                defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIIISingle,
                spellLevel = 3,
                defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIIId3,
                spellLevel = 3,
                defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIVSingle,
                spellLevel = 4,
                defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIVd3,
                spellLevel = 4,
                defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVSingle,
                spellLevel = 5,
                defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVd3,
                spellLevel = 5,
                defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVISingle,
                spellLevel = 6,
                defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVId3,
                spellLevel = 6,
                defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVIISingle,
                spellLevel = 7,
                defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVIId3,
                spellLevel = 7,
                defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVIIISingle,
                spellLevel = 8,
                defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonVIIId3,
                spellLevel = 8,
                defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = null,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIXSingle,
                spellLevel = 9,
                defaultMonster = UnitRefs.ThanadaemonSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.AzataGhaelSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.One,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            },
            new SummonAbility
            {
                guid = GetGUID.SummonerSummonIXd3,
                spellLevel = 9,
                defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
                goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                summonBuff = BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference,
                summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
                numberOfSummons = DiceType.D3,
                durationRate = DurationRate.Minutes,
                goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
                evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference
            }
        };

    }
}
