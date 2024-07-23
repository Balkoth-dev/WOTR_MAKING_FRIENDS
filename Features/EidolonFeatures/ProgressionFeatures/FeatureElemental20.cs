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
    public static class FeatureElemental20
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonElemental20";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.RainbowStarfall.Reference.Get().m_Icon;
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
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonFireElementalCapstoneFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonEarthElementalCapstoneFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonAirElementalCapstoneFeature")),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonWaterElementalCapstoneFeature"))
                ).ConfigureWithLogging();
        }

        internal static void AdjustElementalVariants()
        {
            FeatureConfigurator.New("EidolonFireElementalCapstoneFeature", GetGUID.GUIDByName("EidolonFireElementalCapstoneFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonFireElementalCapstoneFeature.Name"))
                .SetDescription(Helpers.ObtainString("EidolonFireElementalCapstoneFeature.Description"))
                .SetIcon(AbilityRefs.ElementalBodyIIIFire.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonFireElementalVariantFeature")))
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionEnergyAttacksFireBaseFeature")), FeatureRefs.Mobility.Cast<BlueprintUnitFactReference>() })
                .ConfigureWithLogging();
            FeatureConfigurator.New("EidolonEarthElementalCapstoneFeature", GetGUID.GUIDByName("EidolonEarthElementalCapstoneFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonEarthElementalCapstoneFeature.Name"))
                .SetDescription(Helpers.ObtainString("EidolonEarthElementalCapstoneFeature.Description"))
                .SetIcon(AbilityRefs.ElementalBodyIIIEarth.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonEarthElementalVariantFeature")))
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionEnergyAttacksAcidBaseFeature")), BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDR5Feature")) })
                .ConfigureWithLogging();
            FeatureConfigurator.New("EidolonAirElementalCapstoneFeature", GetGUID.GUIDByName("EidolonAirElementalCapstoneFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonAirElementalCapstoneFeature.Name"))
                .SetDescription(Helpers.ObtainString("EidolonAirElementalCapstoneFeature.Description"))
                .SetIcon(AbilityRefs.ElementalBodyIIIAir.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonAirElementalVariantFeature")))
                .AddFacts(new() { AbilityRefs.AirElementalLargeWhirlwindAbility.Cast<BlueprintUnitFactReference>(), BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionEnergyAttacksElectricityBaseFeature")) })
                .ConfigureWithLogging();
            FeatureConfigurator.New("EidolonWaterElementalCapstoneFeature", GetGUID.GUIDByName("EidolonWaterElementalCapstoneFeature"))
                .SetDisplayName(Helpers.ObtainString("EidolonWaterElementalCapstoneFeature.Name"))
                .SetDescription(Helpers.ObtainString("EidolonWaterElementalCapstoneFeature.Description"))
                .SetIcon(AbilityRefs.ElementalBodyIIIWater.Reference.Get().m_Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonWaterElementalVariantFeature")))
                .AddFacts(new() { AbilityRefs.AirElementalLargeWhirlwindAbility.Cast<BlueprintUnitFactReference>(), BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionEnergyAttacksColdBaseFeature")) })
                .ConfigureWithLogging();
        }

    }
}
