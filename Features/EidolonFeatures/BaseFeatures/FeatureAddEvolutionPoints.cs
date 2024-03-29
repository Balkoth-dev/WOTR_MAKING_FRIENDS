﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureAddEvolutionPoints
    {
        internal static class IClass
        {
            internal const string Feature = "AddEvolutionPointsFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }
        internal static class IClassAddFeature
        {
            internal const string Feature = "ExtraEvolutionPoolFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }
        internal static class IClassGrandEidolonFeature
        {
            internal const string Feature = "GrandEidolonFeatureFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }

        public static void Create()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "EvolutionPoints.png"))
                .AddAbilityResources(1, GetGUID.GUIDByName("SummonerEvolutionPointsResource"), true, true)
                .SetRanks(1)
                .ConfigureWithLogging();

            FeatureConfigurator.New(IClassAddFeature.Feature, GetGUID.GUIDByName(IClassAddFeature.Feature))
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), 1)
                .SetDisplayName(IClassAddFeature.Name)
                .SetDescription(IClassAddFeature.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "EvolutionPoints.png"))
                .SetRanks(100)
                .ConfigureWithLogging();

            FeatureConfigurator.New(IClassAddFeature.Feature + "4", GetGUID.GUIDByName(IClassAddFeature.Feature + "4"))
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), 4)
                .SetDisplayName(IClassAddFeature.Name)
                .SetDescription(IClassAddFeature.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "EvolutionPoints.png"))
                .SetRanks(100)
                .ConfigureWithLogging();

            FeatureConfigurator.New(IClassGrandEidolonFeature.Feature, GetGUID.GUIDByName(IClassGrandEidolonFeature.Feature))
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), 4)
                .SetDisplayName(IClassGrandEidolonFeature.Name)
                .SetDescription(IClassGrandEidolonFeature.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "GrandEidolon.png"))
                .SetRanks(100)
                .ConfigureWithLogging();
        }

    }
}
