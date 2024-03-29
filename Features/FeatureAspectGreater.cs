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
    internal class FeatureAspectGreater
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerAspectGreaterFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }
        public static void Create()
        {
            CreateFeature();
        }
        public static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(FeatureRefs.GreaterChimericAspectFeature.Reference.Get().m_Icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionThreeAbilityBase")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionFourAbilityBase")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("ExtraEvolutionPoolFeature4")) })
                .SetGroups(FeatureGroupExtension.SummonerFeatureGroup)
                .ConfigureWithLogging();

        }
    }
}
