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
    public class SummonMonster
    {
        
        internal static class InternalString
        {
            internal const string a = "";
            internal const string SummonerPool = "SummonerPool";
            internal static readonly LocalizedString SummonMonsterSpellbookName = Helpers.ObtainString(a + ".Name");
        }
        internal static class Refs
        {
            internal static readonly BlueprintSummonPoolReference summonerPoolRef = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool);
        }
        public static class SummonAbility
        {
            public static string guid;
            /// <summary>
            /// By default, summons use the Evil monster, this needs to be filled while the good monster does not.
            /// </summary>
            public static BlueprintUnitReference defaultMonster;
            public static BlueprintUnitReference goodMonster;
            public static BlueprintUnitReference summonBuff;
            public static BlueprintUnitReference summonPool;
            public static BlueprintUnitReference numberOfSummons;
            public static BlueprintUnitReference durationRate;
            public static BlueprintUnitReference goodBuff;
            public static BlueprintUnitReference evilBuff;
        }
        internal static class SummonBlueprints
        {
            internal static List<BlueprintAbility> monsterTacticianBlueprintAbilities = new() { 
                AbilityRefs.SummonMonsterISingle.Reference.Get(),
                AbilityRefs.SummonMonsterIISingle.Reference.Get(),
                AbilityRefs.SummonMonsterIId3.Reference.Get(),
                AbilityRefs.SummonMonsterIIISingle.Reference.Get(),
                AbilityRefs.SummonMonsterIIId3.Reference.Get(),
                AbilityRefs.SummonMonsterIVSingle.Reference.Get(),
                AbilityRefs.SummonMonsterIVd3.Reference.Get(),
                AbilityRefs.SummonMonsterVSingle.Reference.Get(),
                AbilityRefs.SummonMonsterVd3.Reference.Get(),
                AbilityRefs.SummonMonsterVISingle.Reference.Get(),
                AbilityRefs.SummonMonsterVId3.Reference.Get(),
                AbilityRefs.SummonMonsterVIISingle.Reference.Get(),
                AbilityRefs.SummonMonsterVIId3.Reference.Get(),
                AbilityRefs.SummonMonsterVIIISingle.Reference.Get(),
                AbilityRefs.SummonMonsterVIIId3.Reference.Get(),
                AbilityRefs.SummonMonsterIXSingle.Reference.Get(),
                AbilityRefs.SummonMonsterIXd3.Reference.Get()
            };
            internal static List<BlueprintAbility> summonMonsterBaseBlueprintAbilities = new()
            {
                AbilityRefs.SummonMonsterIIBase.Reference.Get(),
                AbilityRefs.SummonMonsterIIIBase.Reference.Get(),
                AbilityRefs.SummonMonsterIVBase.Reference.Get(),
                AbilityRefs.SummonMonsterVBase.Reference.Get(),
                AbilityRefs.SummonMonsterVIBase.Reference.Get(),
                AbilityRefs.SummonMonsterVIIBase.Reference.Get(),
                AbilityRefs.SummonMonsterVIIIBase.Reference.Get(),
                AbilityRefs.SummonMonsterIXBase.Reference.Get(),
            };
        }
        
        public static BlueprintSummonPool CreateSummonerPoolContextAction()
        {
            return SummonPoolConfigurator.New(InternalString.SummonerPool, GetGUID.SummonerPool).Configure();
        }
        public static void CreateSummonerSummonMonsterSpells()
        {
            try
            {
                foreach (BlueprintAbility ability in SummonBlueprints.monsterTacticianBlueprintAbilities)
                {
                    string summonMonsterAbilityName = ability.name.Replace("SummonMonster", "SummonerSummon");

                    string summonMonsterFieldGuid = GetGUID.GUIDByName(summonMonsterAbilityName);

                    BlueprintAbility summonMonsterAbility = AbilityConfigurator.New(summonMonsterAbilityName, summonMonsterFieldGuid)
                        .CopyFrom(ability, c => c is not (AbilityResourceLogic or AbilityEffectRunAction or CraftInfoComponent))
                        .SetIsFullRoundAction(false)
                        .SetActionType(CommandType.Standard)
                        .Configure();
                }

                foreach (BlueprintAbility ability in SummonBlueprints.summonMonsterBaseBlueprintAbilities)
                {
                    string summonMonsterAbilityName = ability.name.Replace("Summon", "SummonerSummon");

                    AbilityEffectRunAction mtAbilityEffectRunAction = ability.GetComponent<AbilityEffectRunAction>();
                    string summonMonsterFieldGuid = GetGUID.GUIDByName(summonMonsterAbilityName);
                    
                    BlueprintAbility summonMonsterAbility = AbilityConfigurator.New(summonMonsterAbilityName, summonMonsterFieldGuid)
                        .CopyFrom(ability, c => c is not (SpellListComponent or AbilityVariants or RecommendationNoFeatFromGroup))
                        .SetLocalizedDuration(Duration.MinutePerLevel)
                        .SetActionType(CommandType.Standard)
                        .AddSpellListComponent(ability.GetComponent<SpellListComponent>().SpellLevel, GetGUID.SummonerSecondSpellbookSpellList)
                        .Configure();
                }
            }
            catch(Exception e)
            {
                Main.Log(null, e);
            }

        }

        public static void AddAbilityEffectRunActionsToSummon(string summonGUID, BlueprintUnitReference evilMonster, BlueprintBuffReference summonedCreatureBuff = null, BlueprintSummonPoolReference summonPoolReferenceType = null, BlueprintUnitReference goodMonster = null, DiceType diceType = DiceType.One, DurationRate durationRate = DurationRate.Rounds)
        {
            AbilityConfigurator.For(summonGUID)
                .AddAbilityEffectRunAction(
                     actions: CreateSummonMonsterConditional(evilMonster, summonedCreatureBuff, summonPoolReferenceType, goodMonster, diceType, durationRate)
                )
                .Configure();
        }

        public static ActionList CreateSummonMonsterConditional(BlueprintUnitReference evilMonster, BlueprintBuffReference summonedCreatureBuff, BlueprintSummonPoolReference summonPoolReferenceType, BlueprintUnitReference goodMonster = null, DiceType diceType = DiceType.One, DurationRate durationRate = DurationRate.Rounds)
        {
            if(goodMonster == null)
            {
                goodMonster = evilMonster;
            }
            return ActionsBuilder.New()
                .Add<ContextActionClearSummonPool>(c => { c.m_SummonPool = summonPoolReferenceType; })
                .Conditional(
                    ConditionsBuilder.New().Alignment(AlignmentComponent.Evil, true, false),
                    CreateSummonMonster(evilMonster, summonedCreatureBuff, summonPoolReferenceType, diceType, durationRate),
                    CreateSummonMonster(goodMonster, summonedCreatureBuff, summonPoolReferenceType, diceType, durationRate)
                    )
                .Build();
        }

        public static ActionList CreateSummonMonster(BlueprintUnitReference monster, BlueprintBuffReference summonedCreatureBuff, BlueprintSummonPoolReference summonPoolReferenceType, DiceType diceType = DiceType.One, DurationRate durationRate = DurationRate.Rounds)
        {
            var contextDice = ContextDice.Value(diceType,null,ContextValues.Rank(AbilityRankType.ProjectilesCount));
            var contextDuration = ContextDuration.Variable(ContextValues.Rank(),durationRate, true);

            var summonedBuff = ActionsBuilder
                .New()
                .ApplyBuffPermanent(summonedCreatureBuff, null, null, null, true)
                .Conditional
                    (
                    ConditionsBuilder.New().Alignment(AlignmentComponent.Evil,true,false),
                    ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference, null, null, null, true),
                    ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference, null, null, null, true)
                    )
                .Build();
            
            return ActionsBuilder.New()
                .SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonPoolReferenceType, summonedBuff,false,false)
                .Build();
        }

        public static void CreateSummonMonsterBase(string baseAbility, List<Blueprint<BlueprintAbilityReference>> summonSpells)
        {
            AbilityConfigurator.For(baseAbility).AddAbilityVariants(summonSpells).Configure();
        }

        public static void CreateSummonSpells()
        {
            CreateSummonerPoolContextAction();
            CreateSummonerSummonMonsterSpells();

            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonISingle, UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIISingle, UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIId3, UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIIISingle, UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIIId3, UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIVSingle, UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIVd3, UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVSingle, UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVd3, UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVISingle, UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVId3, UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVIISingle, UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVIId3, UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVIIISingle, UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonVIIId3, UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, null, DiceType.D3, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIXSingle, UnitRefs.ThanadaemonSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.AzataGhaelSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.One, DurationRate.Minutes);
            AddAbilityEffectRunActionsToSummon(GetGUID.SummonerSummonIXd3, UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference, BuffRefs.SummonedCreatureSpawnMonsterVI_IX.Cast<BlueprintBuffReference>().Reference, Refs.summonerPoolRef, UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference, DiceType.D3, DurationRate.Minutes);

            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterIIBase,new() { GetGUID.SummonerSummonIISingle, GetGUID.SummonerSummonIId3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterIIIBase, new() { GetGUID.SummonerSummonIIISingle, GetGUID.SummonerSummonIIId3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterIVBase, new() { GetGUID.SummonerSummonIVSingle, GetGUID.SummonerSummonIVd3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterVBase, new() { GetGUID.SummonerSummonVSingle, GetGUID.SummonerSummonVd3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterVIBase, new() { GetGUID.SummonerSummonVISingle, GetGUID.SummonerSummonVId3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterVIIBase, new() { GetGUID.SummonerSummonVIISingle, GetGUID.SummonerSummonVIId3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterVIIIBase, new() { GetGUID.SummonerSummonVIIISingle, GetGUID.SummonerSummonVIIId3 });
            CreateSummonMonsterBase(GetGUID.SummonerSummonMonsterIXBase, new() { GetGUID.SummonerSummonIXSingle, GetGUID.SummonerSummonIXd3 });

        }

    }
}
