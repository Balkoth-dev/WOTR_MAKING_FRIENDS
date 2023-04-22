using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureTransposition
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerTranspositionFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerTranspositionFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerTranspositionFeature.Description");
        }
        public static void CreateTransposition()
        {
            CreateTranspositionFeature();
        }
        public static void CreateTranspositionFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .CopyFrom(FeatureRefs.ArcanistExploitDimensionalSlideFeature.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("SummonerTranspositionAbility")) })
                .SetIcon(FeatureRefs.SpellDanceFeature.Reference.Get().m_Icon)
                .Configure();
        }
    }
}
