using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.BlueprintAbilityResource;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions
{
    internal class EvolutionDamageReduction
    {
        private static class InternalString
        {
            internal static Sprite icon = FeatureRefs.BloodragerDamageReduction.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionDamageReduction";
            internal const string Feature = Evolution + "Feature";
            internal const string ResourceReductionFeature = Evolution + "ResourceReductionFeature";
            internal const string Ability = Evolution + "Ability";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.New(InternalString.ResourceReductionFeature, GetGUID.GUIDByName(InternalString.ResourceReductionFeature))
                .CopyFrom(GetGUID.GUIDByName(InternalString.Feature), c => true)
                .SetRanks(100)
                .SetHideInUI(true)
                .ConfigureWithLogging();

            var feature = FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .RemoveComponents(c => c is IncreaseResourceAmount)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(GetGUID.GUIDByName(InternalString.Feature)))
                .AddDamageResistancePhysical(value: ContextValues.Rank())
                .SetRanks(100)
                .ConfigureWithLogging(true);

        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .RemoveComponents(c => c is AbilityEffectRunAction)
                .ConfigureWithLogging(true);

            var abilityAction = ActionsBuilder.New().AddFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(InternalString.ResourceReductionFeature)))
                                                    .Add<ContextActionAddFeatureRanks>(c => { c.setRank = 5; c.m_PermanentFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(InternalString.Feature)); })
                                                    .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")), 99)
                                                    .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")), 99)
                                                    .Build();

            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .AddAbilityEffectRunAction(actions: abilityAction)
                       .AddComponent<AbilityCasterHasFactRank>(c => {
                           c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Feature));
                           c.maxRank = 100;
                           c.numLevelsBetweenRanks = 0;
                           c.startLevel = 15;
                       })
                .ConfigureWithLogging(true);
        }
    }
}
