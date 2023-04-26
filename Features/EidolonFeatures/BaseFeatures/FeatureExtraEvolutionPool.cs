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
    public static class FeatureExtraEvolutionPool
    {
        private static class InternalString
        {
            internal const string Feature = "ExtraEvolutionPoolFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }

        public static void Create()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), 1)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AbilityRefs.TarPool.Reference.Get().m_Icon)
                .SetRanks(40)
                .ConfigureWithLogging();
        }
    }
}
