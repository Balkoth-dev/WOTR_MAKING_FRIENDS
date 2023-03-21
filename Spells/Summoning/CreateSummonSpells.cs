using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using HarmonyLib;
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
using static WOTR_MAKING_FRIENDS.Spells.Summoning.SummonAbilities;
using static WOTR_MAKING_FRIENDS.Spells.Summoning.SummonBase;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    public class CreateSummonSpells
    {
        internal static class Refs
        {
            internal static readonly BlueprintSummonPoolReference summonerPoolRef = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool);
        }

        public static Dictionary<string, List<Blueprint<BlueprintAbilityReference>>> baseSummonSpells = new();

        internal static int[] scrollCost = {25, 150, 375, 700, 1125, 1650, 2275, 3000, 3825};
        internal static BlueprintItemEquipmentUsable summonMonsterISingleScroll = ItemEquipmentUsableRefs.ScrollOfSummonMonsterISingle.Reference.Get();
        public static void CreateSummonAbility(SummonAbility summonAbility)
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

            if (summonAbility.spellListComponents != null)
            {
                foreach (var spellList in summonAbility.spellListComponents)
                {
                    if (summonAbility.summonSpellBaseGuid == null)
                    {
                        summonSpell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                    }
                    else
                    {
                        summonSpell.AddSpellListComponent(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key));
                    }
                };
            }
            
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
            int maxSpellLevel = 0;
            if (summonAbility.spellListComponents.Count > 0)
            {
                maxSpellLevel = summonAbility.spellListComponents.Values.Max();
            }
            summonScroll.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(summonAbility.guid);
            summonScroll.m_Cost = scrollCost[maxSpellLevel];
            summonScroll.m_DisplayNameText = Helpers.ObtainString(summonAbility.name + "Scroll.Name");
            summonScroll.m_Icon = summonMonsterISingleScroll.m_Icon;
        }

        public static ActionList CreateSummonMonsterConditional(SummonAbility summonAbility)
        {
            if(summonAbility.goodMonster == null)
            {
                summonAbility.goodMonster = summonAbility.defaultMonster;
            }

            var summonMonsterConditional = ActionsBuilder.New();

            if (summonAbility.summonPool != null)
                summonMonsterConditional.ClearSummonPool(summonAbility.summonPool);
            
            summonMonsterConditional.Conditional(
                ConditionsBuilder.New().Alignment(AlignmentComponent.Evil, true, false),
                CreateSummonMonster(summonAbility, summonAbility.defaultMonster),
                CreateSummonMonster(summonAbility, summonAbility.goodMonster)
                );

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

            summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);

            if (summonAbility.numberOfBonusSummons > 0)
            {
                contextDice = ContextDice.Value(DiceType.Zero,0,summonAbility.numberOfBonusSummons);
                summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);
            }

            return summonMonster.Build();
        }

        public static void CreateSummonMonsterBase(SummonAbilityBase summonAbilityBase)
        {
                var baseSummonSpell = AbilityConfigurator.New(summonAbilityBase.name, summonAbilityBase.guid)
                    .SetIcon(summonAbilityBase.m_icon)
                    .SetDisplayName(summonAbilityBase.m_DisplayName)
                    .SetDescription(summonAbilityBase.m_Description)
                    .SetLocalizedDuration(summonAbilityBase.localizationDuration)
                    .SetActionType(summonAbilityBase.actionType)
                    .SetIsFullRoundAction(summonAbilityBase.isFullRound)
                    .SetHasVariants(true);

                if (summonAbilityBase.spellListComponents != null)
                {
                    foreach (var spellList in summonAbilityBase.spellListComponents)
                    {
                        baseSummonSpell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                    }
                }

                baseSummonSpell.Configure();
        }

        public static void CreateSummoningSpells()
        {
            float count = 0;
            float uniqueCount = 0;

            foreach (SummonAbilityBase baseAbility in summonBaseAbilities)
            {
                CreateSummonMonsterBase(baseAbility);
                Main.Log(baseAbility.name + " : " + baseAbility.guid + " created.");
                count++;
            }

            foreach (SummonAbility ability in summonAbilities)
            {
                CreateSummonAbility(ability);

                Main.Log(ability.name + " : " + ability.guid + " created.");
                if (ability.summonSpellBaseGuid != null)
                {
                    if (!baseSummonSpells.ContainsKey(ability.summonSpellBaseGuid))
                    {
                        baseSummonSpells[ability.summonSpellBaseGuid] = new List<Blueprint<BlueprintAbilityReference>>();
                    }
                    baseSummonSpells[ability.summonSpellBaseGuid].Add(ability.guid);
                }
                count++;
                if(!ability.name.Contains("SummonerSummon"))
                {
                    uniqueCount++;
                }
            }

            Main.Log(count + " total summoning spells created, including base.");
            Main.Log(uniqueCount + " unique summoning spells created.");

            foreach (var baseSummonSpell in baseSummonSpells)
            {
                AbilityConfigurator.For(baseSummonSpell.Key).AddAbilityVariants(baseSummonSpell.Value).Configure();
            }
        }

    }
}
