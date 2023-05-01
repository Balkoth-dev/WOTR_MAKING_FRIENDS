using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
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

        public static void Create()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(FeatureRefs.LuckDomainBaseFeature.Reference.Get().m_Icon)
                .AddAbilityResources(1, GetGUID.GUIDByName("SummonerEvolutionPointsResource"), true, true)
                .SetRanks(99)
                .ConfigureWithLogging();
        }

    }
}
