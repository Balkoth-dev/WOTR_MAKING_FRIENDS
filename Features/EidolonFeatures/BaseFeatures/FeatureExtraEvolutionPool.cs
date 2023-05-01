using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureExtraEvolutionPool
    {
        internal static class IClass
        {
            internal const string Feature = "ExtraEvolutionPoolFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }

        public static void Create()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), 1)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.TarPool.Reference.Get().m_Icon)
                .SetRanks(40)
                .ConfigureWithLogging();
        }
    }
}
