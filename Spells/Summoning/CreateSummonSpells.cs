using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Craft;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using System.Linq;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell;
using static WOTR_MAKING_FRIENDS.Spells.Summoning.SummonAbilities;
using static WOTR_MAKING_FRIENDS.Spells.Summoning.SummonBase;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    public class CreateSummonSpells
    {
        internal static class Refs
        {
            internal static readonly BlueprintSummonPoolReference summonerPoolRef = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.GUIDByName("SummonerPool"));
        }

        public static Dictionary<string, List<Blueprint<BlueprintAbilityReference>>> baseSummonSpells = new();

        internal static int[] scrollCost = { 25, 150, 375, 700, 1125, 1650, 2275, 3000, 3825 };
        internal static BlueprintItemEquipmentUsable summonMonsterISingleScroll = ItemEquipmentUsableRefs.ScrollOfSummonMonsterISingle.Reference.Get();
        public static void CreateSummonAbility(SummonAbility summonAbility)
        {
            AbilityConfigurator summonSpell =
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
                foreach (KeyValuePair<string, int> spellList in summonAbility.spellListComponents)
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

            if (summonAbility.craftingComponent)
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

            summonSpell.ConfigureWithLogging();
        }

        private static void CreateSummonScroll(SummonAbility summonAbility)
        {
            BlueprintItemEquipmentUsable summonScroll = BlueprintConfigurator<BlueprintItemEquipmentUsable>.New(summonAbility.name + "Scroll", GetGUID.GUIDByName(summonAbility.name + "Scroll"))
                .CopyFrom(summonMonsterISingleScroll)
                .ConfigureWithLogging();
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
            if (summonAbility.goodMonster == null)
            {
                summonAbility.goodMonster = summonAbility.defaultMonster;
            }

            ActionsBuilder summonMonsterConditional = ActionsBuilder.New();

            if (summonAbility.summonPool != null)
            {
                summonMonsterConditional.ClearSummonPool(summonAbility.summonPool);
            }

            summonMonsterConditional.Conditional(
                ConditionsBuilder.New().Alignment(AlignmentComponent.Evil, true, false),
                CreateSummonMonster(summonAbility, summonAbility.defaultMonster),
                CreateSummonMonster(summonAbility, summonAbility.goodMonster)
                );

            return summonMonsterConditional.Build();
        }

        public static ActionList CreateSummonMonster(SummonAbility summonAbility, BlueprintUnitReference monster)
        {

            Kingmaker.UnitLogic.Mechanics.ContextDiceValue contextDice = summonAbility.numberOfSummons > DiceType.One
                              ? ContextDice.Value(summonAbility.numberOfSummons, null, ContextValues.Rank(AbilityRankType.ProjectilesCount))
                              : ContextDice.Value(summonAbility.numberOfSummons);

            Kingmaker.UnitLogic.Mechanics.ContextDurationValue contextDuration = ContextDuration.Variable(ContextValues.Rank(), summonAbility.durationRate, true);

            ActionsBuilder summonedBuff = ActionsBuilder
                .New()
                .Conditional
                    (
                    ConditionsBuilder.New().Alignment(AlignmentComponent.Evil, true, false),
                    ActionsBuilder.New().ApplyBuffPermanent(summonAbility.evilBuff, null, null, null, true),
                    ActionsBuilder.New().ApplyBuffPermanent(summonAbility.goodBuff, null, null, null, true)
                    );

            if (summonAbility.summonBuff != null)
            {
                foreach (BlueprintBuffReference buff in summonAbility.summonBuff)
                {
                    summonedBuff.ApplyBuffPermanent(buff, null, null, null, true);
                }
            }

            if (summonAbility.blueprintUnitFactReferences != null)
            {
                foreach (Blueprint<BlueprintUnitFactReference> unitFactRef in summonAbility.blueprintUnitFactReferences)
                {
                    summonedBuff.AddFact(unitFactRef, null);
                }
            }

            summonedBuff.Build();


            ActionsBuilder summonMonster = ActionsBuilder.New();

            summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);

            if (summonAbility.numberOfBonusSummons > 0)
            {
                contextDice = ContextDice.Value(DiceType.Zero, 0, summonAbility.numberOfBonusSummons);
                summonMonster.SpawnMonsterUsingSummonPool(contextDice, contextDuration, monster, summonAbility.summonPool, summonedBuff, false, false);
            }

            return summonMonster.Build();
        }

        public static void CreateSummonMonsterBase(SummonAbilityBase summonAbilityBase)
        {
            AbilityConfigurator baseSummonSpell = AbilityConfigurator.New(summonAbilityBase.name, summonAbilityBase.guid)
                .SetIcon(summonAbilityBase.m_icon)
                .SetDisplayName(summonAbilityBase.m_DisplayName)
                .SetDescription(summonAbilityBase.m_Description)
                .SetLocalizedDuration(summonAbilityBase.localizationDuration)
                .SetActionType(summonAbilityBase.actionType)
                .SetIsFullRoundAction(summonAbilityBase.isFullRound)
                .SetHasVariants(true);

            if (summonAbilityBase.spellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in summonAbilityBase.spellListComponents)
                {
                    baseSummonSpell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }

            baseSummonSpell.ConfigureWithLogging();
        }

        public static void CreateSummoningSpells()
        {
            float count = 0;
            float uniqueCount = 0;

            foreach (SummonAbilityBase baseAbility in summonBaseAbilities)
            {
                CreateSummonMonsterBase(baseAbility);
                count++;
            }

            foreach (SummonAbility ability in summonAbilities)
            {
                CreateSummonAbility(ability);

                if (ability.summonSpellBaseGuid != null)
                {
                    if (!baseSummonSpells.ContainsKey(ability.summonSpellBaseGuid))
                    {
                        baseSummonSpells[ability.summonSpellBaseGuid] = new List<Blueprint<BlueprintAbilityReference>>();
                    }
                    baseSummonSpells[ability.summonSpellBaseGuid].Add(ability.guid);
                }
                count++;
                if (!ability.name.Contains("SummonerSummon"))
                {
                    uniqueCount++;
                }
            }

            Main.Log(count + " total summoning spells created, including base.");
            Main.Log(uniqueCount + " unique summoning spells created.");

            foreach (KeyValuePair<string, List<Blueprint<BlueprintAbilityReference>>> baseSummonSpell in baseSummonSpells)
            {
                AbilityConfigurator.For(baseSummonSpell.Key).AddAbilityVariants(baseSummonSpell.Value).ConfigureWithLogging();
            }
        }

    }
}
