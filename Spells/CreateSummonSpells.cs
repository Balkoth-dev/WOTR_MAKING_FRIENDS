using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Craft;
using Kingmaker.Designers.EventConditionActionSystem;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
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
using static Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell;
using static WOTR_MAKING_FRIENDS.Spells.SummonAbilities;
using static WOTR_MAKING_FRIENDS.Spells.SummonBase;

namespace WOTR_MAKING_FRIENDS.Spells
{
    public class CreateSummonSpells
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
        
        public static BlueprintSummonPool CreateSummonerPoolContextAction()
        {
            return SummonPoolConfigurator.New(InternalString.SummonerPool, GetGUID.SummonerPool).Configure();
        }

        public static Dictionary<string, List<Blueprint<BlueprintAbilityReference>>> baseSummonSpells = new();

        internal static int[] scrollCost = {25, 150, 375, 700, 1125, 1650, 2275, 3000, 3825};
        internal static BlueprintItemEquipmentUsable summonMonsterISingleScroll = ItemEquipmentUsableRefs.ScrollOfSummonMonsterISingle.Reference.Get();
        public static void AddAbilityEffectRunActionsToSummon(SummonAbility summonAbility)
        {
            var summonSpell =
            AbilityConfigurator.New(summonAbility.name, summonAbility.guid)
                .SetIsFullRoundAction(summonAbility.isFullRound)
                .SetActionType(summonAbility.actionType)
                .SetIsFullRoundAction(summonAbility.isFullRound)
                .SetIcon(summonAbility.m_icon)
                .SetDisplayName(summonAbility.m_DisplayName)
                .SetDescription(summonAbility.m_Description)
                .SetType(AbilityType.Spell)
                .SetCanTargetPoint(true)
                .SetCanTargetSelf(true)
                .SetRange(AbilityRange.Close)
                .SetAnimation(CastAnimationStyle.Point)
                .SetAvailableMetamagic(Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal)
                .SetLocalizedDuration(summonAbility.localizationDuration)
                .AddAbilityEffectRunAction(
                     actions: CreateSummonMonsterConditional(summonAbility)
                )
                .AddContextRankConfig(summonAbility.contextRankConfig)
                .AddSpellDescriptorComponent(SpellDescriptor.Summoning);

            foreach(var spellList in summonAbility.spellListComponents)
            {
                summonSpell.AddSpellListComponent(summonAbility.spellLevel, spellList);
            };
            
            if(summonAbility.craftingComponent)
            {
                summonSpell.AddCraftInfoComponent(null, null, ComponentMerge.Replace, null, CraftSpellType.Summon_Polymorph);
                CreateSummonScroll(summonAbility);
            };

            if (summonAbility.materialComponent != null)
            {
                summonSpell.SetMaterialComponent(summonAbility.materialComponent);
            };

            if (summonAbility.numberOfSummons > DiceType.One)
            {
                string[] featureList =
                    { 
                        FeatureRefs.SuperiorSummoning.Cast<BlueprintBuffReference>().Reference.ToString(), 
                        FeatureRefs.BloodlineAbyssalAddedSummonings.Cast<BlueprintBuffReference>().Reference.ToString()
                    };
                summonSpell.AddContextRankConfig(ContextRankConfigs.FeatureList(featureList, false, AbilityRankType.ProjectilesCount));
                summonSpell.AddToAvailableMetamagic(Metamagic.Maximize, Metamagic.Empower);
            };

            summonSpell.Configure();
        }

        private static void CreateSummonScroll(SummonAbility summonAbility)
        {
            var summonScroll = BlueprintConfigurator<BlueprintItemEquipmentUsable>.New(summonAbility.name + "Scroll", GetGUID.GUIDByName(summonAbility.name + "Scroll"))
                .CopyFrom(summonMonsterISingleScroll)
                .Configure();
            summonScroll.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(summonAbility.guid);
            summonScroll.m_Cost = scrollCost[summonAbility.spellLevel];
            summonScroll.m_DisplayNameText = Helpers.ObtainString(summonAbility.name + "Scroll.Name");
            summonScroll.m_Icon = summonMonsterISingleScroll.m_Icon;
        }

        public static ActionList CreateSummonMonsterConditional(SummonAbility summonAbility)
        {
            if(summonAbility.goodMonster == null)
            {
                summonAbility.goodMonster = summonAbility.defaultMonster;
            }
            var summonMonsterConditional = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().Alignment(AlignmentComponent.Evil, true, false),
                    CreateSummonMonster(summonAbility, summonAbility.defaultMonster),
                    CreateSummonMonster(summonAbility, summonAbility.goodMonster)
                    );
            if(summonAbility.summonPool != null)
            {
                summonMonsterConditional
                .Add<ContextActionClearSummonPool>(c => { c.m_SummonPool = summonAbility.summonPool; });
            }
            return summonMonsterConditional.Build();
        }

        public static ActionList CreateSummonMonster(SummonAbility summonAbility, BlueprintUnitReference monster)
        {

            var contextDice = summonAbility.numberOfSummons > DiceType.One
                              ? ContextDice.Value(summonAbility.numberOfSummons, null, ContextValues.Rank(AbilityRankType.ProjectilesCount))
                              : ContextDice.Value(summonAbility.numberOfSummons);

            var contextDuration = ContextDuration.Variable(ContextValues.Rank(), summonAbility.durationRate, true);

            var summonedBuff = ActionsBuilder
                .New()
                .Conditional
                    (
                    ConditionsBuilder.New().Alignment(AlignmentComponent.Evil,true,false),
                    ActionsBuilder.New().ApplyBuffPermanent(summonAbility.evilBuff, null, null, null, true),
                    ActionsBuilder.New().ApplyBuffPermanent(summonAbility.goodBuff, null, null, null, true)
                    );

            if(summonAbility.summonBuff != null)
            {
                foreach(var buff in summonAbility.summonBuff)
                {
                    summonedBuff.ApplyBuffPermanent(buff, null, null, null, true);
                }
            }

            if (summonAbility.blueprintUnitFactReferences != null)
            {
                foreach (var unitFactRef in summonAbility.blueprintUnitFactReferences)
                {
                    summonedBuff.AddFact(unitFactRef,null);
                }
            }

            summonedBuff.Build();


            var summonMonster = ActionsBuilder.New();

            if (summonAbility.summonPool == null)
            {
                summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);
            }
            else
            {
                summonMonster.SpawnMonster(contextDice, contextDuration, monster, summonedBuff, false, false);
            }

            if (summonAbility.numberOfBonusSummons > 0)
            {
                contextDice = ContextDice.Value(DiceType.Zero,9,summonAbility.numberOfBonusSummons);
                if (summonAbility.summonPool == null)
                {
                    summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);
                }
                else
                {
                    summonMonster.SpawnMonster(contextDice, contextDuration, monster, summonedBuff, false, false);
                }
            }

            return summonMonster.Build();
        }

        public static void CreateSummonMonsterBase(SummonAbilityBase summonAbilityBase)
        {
            AbilityConfigurator.New(summonAbilityBase.name, summonAbilityBase.guid)
                .SetIcon(summonAbilityBase.m_icon)
                .SetDisplayName(summonAbilityBase.m_DisplayName)
                .SetDescription(summonAbilityBase.m_Description)
                .SetLocalizedDuration(summonAbilityBase.localizationDuration)
                .SetActionType(summonAbilityBase.actionType)
                .SetIsFullRoundAction(summonAbilityBase.isFullRound)
                .SetHasVariants(true)
                .Configure();
        }

        public static void CreateSpells()
        {
            CreateSummonerPoolContextAction();

            BuffConfigurator.New("dummyBuff", GetGUID.DummyBuff).Configure();
            
            foreach (SummonAbilityBase baseAbility in summonBaseAbilities)
            {
                CreateSummonMonsterBase(baseAbility);
            }

            foreach (SummonAbility ability in summonAbilities)
            {
                AddAbilityEffectRunActionsToSummon(ability);
                if (ability.summonSpellBaseGuid != null)
                {
                    if (!baseSummonSpells.ContainsKey(ability.summonSpellBaseGuid))
                    {
                        baseSummonSpells[ability.summonSpellBaseGuid] = new List<Blueprint<BlueprintAbilityReference>>();
                    }
                    baseSummonSpells[ability.summonSpellBaseGuid].Add(ability.guid);
                }
            }

            foreach(var baseSummonSpell in baseSummonSpells)
            {
                AbilityConfigurator.For(baseSummonSpell.Key).AddAbilityVariants(baseSummonSpell.Value).Configure();
            }
        }

    }
}
