using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureAddFeatureLayOnHands
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonAddFeatureLayOnHands";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.LayOnHandsFeature.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassAbilitySelf
        {
            internal static string Ability = IClass.ProgressionFeature + "SelfAbility";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public static class IClassAbilityOthers
        {
            internal static string Ability = IClass.ProgressionFeature + "OthersAbility";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            CreateFeature();
            CreateAbilitySelf();
            CreateAbilityOthers();
        }
        internal static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbilitySelf.Guid), BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbilityOthers.Guid) })
                    .AddAbilityResources(resource: AbilityResourceRefs.LayOnHandsResource.Cast<BlueprintAbilityResourceReference>())
                    .AddIncreaseResourceAmount(AbilityResourceRefs.LayOnHandsResource.Cast<BlueprintAbilityResourceReference>(), 2)
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateAbilitySelf()
        {
            AbilityConfigurator.New(IClassAbilitySelf.Ability, IClassAbilitySelf.Guid)
                .CopyFrom(AbilityRefs.LayOnHandsSelf, c => c is not (ContextRankConfig or AbilityCasterAlignment))
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                .ConfigureWithLogging();
        }
        internal static void CreateAbilityOthers()
        {
            AbilityConfigurator.New(IClassAbilityOthers.Ability, IClassAbilityOthers.Guid)
                .CopyFrom(AbilityRefs.LayOnHandsOthers, c => c is not (ContextRankConfig or AbilityCasterAlignment))
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithDiv2Progression())
                .ConfigureWithLogging();
        }
    }
}

