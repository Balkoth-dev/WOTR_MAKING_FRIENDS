using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureLifeLink
    {
        private static class IClass
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
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .CopyFrom(FeatureRefs.OracleRevelationLifeLink.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("SummonerLifeLinkActivatableAbility")) })
                .ConfigureWithLogging();

        }
    }
}
