using BlueprintCore.Blueprints.CustomConfigurators;
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
    public static class FeatureAeonSelectionFeature
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonAeonSelectionFeature";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.AnimalAspectBase.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassSubFeature1
        {
            internal static string ProgressionFeature = "EidolonAeonEmotionsFeature";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.AnimalAspectBase.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassSubFeature2
        {
            internal static string ProgressionFeature = "EidolonAeonTimeFeature";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.AnimalAspectBase.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassResource
        {
            internal static string Resource = IClass.ProgressionFeature + "Resource";
            internal static string Guid = GetGUID.GUIDByName(Resource);
        }
        public static void Create()
        {
            CreateFeature();
            CreateResource();
            CreateSubFeatures();
        }

        public static void CreateSubFeatures()
        {

            FeatureConfigurator.New(IClassSubFeature1.Feature, IClassSubFeature1.Guid)
                    .SetDisplayName(IClassSubFeature1.Name)
                    .SetDisplayName(IClassSubFeature1.Description)
                    .SetIcon(IClassSubFeature1.Icon)
                    .SetRanks(IClassSubFeature1.Ranks)
                    .AddAbilityResources(3, BlueprintTool.GetRef<BlueprintAbilityResourceReference>(IClassResource.Guid), true)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureAddSpellCrushingDespair.IClass.Guid), BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureAddSpellGoodHope.IClass.Guid) })
                    .SetGroups(IClassSubFeature1.featureGroup)
                    .ConfigureWithLogging();

            FeatureConfigurator.New(IClassSubFeature2.Feature, IClassSubFeature2.Guid)
                    .SetDisplayName(IClassSubFeature2.Name)
                    .SetDisplayName(IClassSubFeature2.Description)
                    .SetIcon(IClassSubFeature2.Icon)
                    .SetRanks(IClassSubFeature2.Ranks)
                    .AddAbilityResources(3, BlueprintTool.GetRef<BlueprintAbilityResourceReference>(IClassResource.Guid), true)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureAddSpellHaste.IClass.Guid), BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureAddSpellSlow.IClass.Guid) })
                    .SetGroups(IClassSubFeature2.featureGroup)
                    .ConfigureWithLogging();
        }

        internal static void CreateResource()
        {
            BlueprintAbilityResource.Amount maxAmount = ResourceAmountBuilder.New(3).Build();
            AbilityResourceConfigurator.New(IClassResource.Resource, IClassResource.Guid)
                .SetMaxAmount(maxAmount)
                .ConfigureWithLogging();
        }

        public static void CreateFeature()
        {
            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetRanks(IClass.Ranks)
                .SetGroup(IClass.featureGroup)
                .SetAllFeatures(
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(IClassSubFeature1.Guid),
                                  BlueprintTool.GetRef<BlueprintFeatureReference>(IClassSubFeature2.Guid)
                ).Configure();
        }

    }
}
