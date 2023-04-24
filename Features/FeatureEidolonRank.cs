using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureEidolonRank
    {
        private static class InternalString
        {
            internal const string Feature = "EidolonRankFeature";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonRankFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonRankFeature.Description");
        }
        public static void CreateEidolonRank()
        {
            CreateEidolonRankFeature();
        }
        public static void CreateEidolonRankFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .CopyFrom(FeatureRefs.AnimalCompanionRank.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .ClearIsPrerequisiteFor()
                .ConfigureWithLogging();

        }
    }
}
