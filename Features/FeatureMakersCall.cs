using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureMakersCall
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerMakersCallFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerMakersCallFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerMakersCallFeature.Description");
        }
        public static void CreateMakersCall()
        {
            CreateMakersCallFeature();
        }
        public static void CreateMakersCallFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .CopyFrom(FeatureRefs.ArcanistExploitDimensionalSlideFeature.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddAbilityResources(amount: 1, resource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerMakersCallResource")), true)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("SummonerMakersCallAbility")) })
                .SetIcon(FeatureRefs.DimensionalRideFeature.Reference.Get().m_Icon)
                .Configure();
        }
    }
}
