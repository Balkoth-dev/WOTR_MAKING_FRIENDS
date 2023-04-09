using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class LifeLinkFeature
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerLifeLinkFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkFeature.Description");
        }
        public static void CreateEidolonLifeLink()
        {
            CreateEidolonLifeLinkFeature();
        }
        public static void CreateEidolonLifeLinkFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.SummonerLifeLinkFeature)
                .CopyFrom(FeatureRefs.OracleRevelationLifeLink.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.SummonerLifeLinkActivatableAbility) })
                .Configure();

        }
    }
}
