using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureLifeBond
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerLifeBondFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeBondFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeBondFeature.Description");
        }
        public static void CreateEidolonLifeBond()
        {
            CreateEidolonLifeBondFeature();
        }
        public static void CreateEidolonLifeBondFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .CopyFrom(FeatureRefs.OracleRevelationLifeLink.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeBond.png"))
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("SummonerLifeBondActivatableAbility")) })
                .ConfigureWithLogging();

        }
    }
}
