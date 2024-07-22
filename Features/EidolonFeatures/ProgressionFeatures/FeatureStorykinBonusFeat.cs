using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureStorykinBonusFeat
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonStorykinBonusFeat";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.IronWill.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .SetAllFeatures(
                                      FeatureRefs.IronWill.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.IronWillImproved.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.LightningReflexes.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.LightningReflexesImproved.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.GreatFortitude.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.GreatFortitudeImproved.Cast<BlueprintFeatureReference>()
                    )
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
    }
}
