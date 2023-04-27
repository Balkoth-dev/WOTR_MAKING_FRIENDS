using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionLimbsArms
    {
        private static class InternalString
        {
            internal static Sprite icon = AbilityRefs.StrengthBlessingMajorAbility.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionLimbsArms";
            internal static int Ranks = 10;
            internal const string Feature = Evolution + "Feature";
            internal static LocalizedString FeatureName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString FeatureDescription = Helpers.ObtainString(Feature + ".Description");
            internal const string Ability = Evolution + "Ability";
            internal static LocalizedString AbilityName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString AbilityDescription = Helpers.ObtainString(Feature + ".Description");
            internal const string ActivatableAbility = Evolution + "ActivatableAbility";
            internal static LocalizedString ActivatableAbilityName = Helpers.ObtainString(ActivatableAbility + ".Name");
            internal static LocalizedString ActivatableAbilityDescription = Helpers.ObtainString(ActivatableAbility + ".Description");
            internal const string Buff = Evolution + "Buff";
            internal static LocalizedString BuffName = Helpers.ObtainString(Buff + ".Name");
            internal static LocalizedString BuffDescription = Helpers.ObtainString(Buff + ".Description");
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .RemoveComponents(c => c is IncreaseResourceAmount)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.ActivatableAbility)) })
                .AddComponent<AddAdditionalBothHandsAttacks>()
                .AddComponent<IncreaseResourceAmountRank>(c => { c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")); c.Rank = 2; c.Value = -2; })
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"),-2)
                .SetRanks(InternalString.Ranks)
                .ConfigureWithLogging(true);

        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .AddComponent<AbilityCasterHasResource>(c => {
                    c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource"));
                    c.resourceAmount = 1;
                })
                .AddComponent<AbilityCasterHasNoFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Evolution+InternalString.Ranks+"Feature"))
                    };
                })
                .ConfigureWithLogging(true);
        }
    }
}
