using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureEidolonRank
    {
        internal static class IClass
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
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetRanks(20)
                .SetIsClassFeature(true)
                .ConfigureWithLogging();

        }
    }
}
