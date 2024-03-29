﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureTransposition
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerTranspositionFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerTranspositionFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerTranspositionFeature.Description");
        }
        public static void CreateTransposition()
        {
            CreateTranspositionFeature();
        }
        public static void CreateTranspositionFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .CopyFrom(FeatureRefs.ArcanistExploitDimensionalSlideFeature.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("SummonerTranspositionAbility")) })
                .SetIcon(FeatureRefs.SpellDanceFeature.Reference.Get().m_Icon)
                .SetGroups(FeatureGroupExtension.SummonerFeatureGroup)
                .ConfigureWithLogging();
        }
    }
}
