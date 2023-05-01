using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine; using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureAbilityIncreaseSelection
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AncestorBonusFeat";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public void Create()
        {
            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDisplayName(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetRanks(IClass.Ranks)
                .SetGroup(IClass.featureGroup)
                .SetAllFeatures(
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseStrengthBaseFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseDexterityBaseFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseConstitutionBaseFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseIntelligenceBaseFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseWisdomBaseFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionAbilityIncreaseCharismaBaseFeature"))
                ).Configure();
        }

    }
}
