using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureElemental1
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "Elemental1";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.RainbowPattern.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            CreateFeature();
            AdjustElementalVariants();
        }

        internal static void CreateFeature()
        {
            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetRanks(IClass.Ranks)
                .SetGroup(IClass.featureGroup)
                .SetAllFeatures(
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonFireElementalVariantFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonAirElementalVariantFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonWaterElementalVariantFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonEarthElementalVariantFeature"))
                ).ConfigureWithLogging();
        }

        internal static void AdjustElementalVariants()
        {
            FeatureConfigurator.New("EidolonFireElementalVariantFeature", GetGUID.GUIDByName("EidolonFireElementalVariantFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonFireElementalVariantFeature.Name"))
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.ElementalBodyIFire.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionImmunityFireBaseFeature")) })
                .ConfigureWithLogging(true);
            FeatureConfigurator.New("EidolonAirElementalVariantFeature", GetGUID.GUIDByName("EidolonAirElementalVariantFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonAirElementalVariantFeature.Name"))
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionImmunityElectricityBaseFeature")) })
                .ConfigureWithLogging(true);
            FeatureConfigurator.New("EidolonWaterElementalVariantFeature", GetGUID.GUIDByName("EidolonWaterElementalVariantFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonWaterElementalVariantFeature.Name"))
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.ElementalBodyIWater.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature")) })
                .ConfigureWithLogging(true);
            FeatureConfigurator.New("EidolonEarthElementalVariantFeature", GetGUID.GUIDByName("EidolonEarthElementalVariantFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonEarthElementalVariantFeature.Name"))
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.ElementalBodyIEarth.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionImmunityAcidBaseFeature")) })
                .ConfigureWithLogging(true);
        }

    }
}
