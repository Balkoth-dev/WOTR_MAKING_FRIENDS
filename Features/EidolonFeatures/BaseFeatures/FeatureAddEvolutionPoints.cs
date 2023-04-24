using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureAddEvolutionPoints
    {
        private static class InternalString
        {
            internal const string Feature = "AddEvolutionPointsFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }

        public static void Create()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(FeatureRefs.LuckDomainBaseFeature.Reference.Get().m_Icon)
                .AddAbilityResources(1, GetGUID.GUIDByName("SummonerEvolutionPointsResource"))
                .ConfigureWithLogging();
        }

    }
}
