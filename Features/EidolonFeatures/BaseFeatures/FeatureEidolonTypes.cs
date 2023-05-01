using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions;
using WOTR_MAKING_FRIENDS.Utilities;
using static RootMotion.FinalIK.GrounderQuadruped;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    internal class FeatureEidolonTypes
    {
        private static class IClass
        {
            internal const string Feature = "EidolonSubtypeFeature";
            internal static LocalizedString Name = Helpers.ObtainString("eidolonsubtypefeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("eidolonsubtypefeature.Description");
        }
        public static void Create()
        {
            CreateBaseFeature();
            CreateEnumFeature("BaseFormFeature", new EnumsEidolonBaseForm());
            CreateSubtypeSelectionFeature();
            CreateEnumFeature("SubtypeFeature", new EnumsEidolonSubtype());
            CreateEnumFeature("VariantFeature", new EnumsEidolonVariant());
            CreateSubtypeFeatures("SubtypeFeature");
        }
        internal static void CreateBaseFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName("EidolonSubtypeFeature"))
                               .SetDisplayName(IClass.Name)
                               .SetDescription(IClass.Description)
                               .SetHideInUI(true)
                               .SetHideInCharacterSheetAndLevelUp(true)
                               .SetGroups(FeatureGroup.CreatureType)
                               .SetRanks(1)
                               .SetIsClassFeature(true)
                               .ConfigureWithLogging();
        }
        internal static void CreateSubtypeSelectionFeature()
        {
            var featureName = "EidolonSubtypeSelectionFeature";
            FeatureSelectionConfigurator.New(featureName, GetGUID.GUIDByName(featureName))
                               .SetDisplayName(Helpers.ObtainString(featureName + ".Name"))
                               .SetDescription(Helpers.ObtainString(featureName + ".Description"))
                               .SetHideInUI(true)
                               .SetHideInCharacterSheetAndLevelUp(true)
                               .SetGroups(FeatureGroup.CreatureType)
                               .SetRanks(1)
                               .SetIsClassFeature(true)
                               .ConfigureWithLogging();
        }
        internal static void CreateEnumFeature(string name, Enum enumType)
        {
            foreach (var enumValue in Enum.GetValues(enumType.GetType()))
            {
                try
                {
                    var eidolonFeatureName = "Eidolon" + Enum.GetName(enumType.GetType(), enumValue) + name;
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var feature = FeatureConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
                                                            .SetDisplayName(Helpers.ObtainString(eidolonFeatureName + ".Name"))
                                                            .SetHideInUI(true)
                                                            .SetHideInCharacterSheetAndLevelUp(true)
                                                            .SetGroups(FeatureGroup.CreatureType)
                                                            .SetRanks(1)
                                                            .SetIsClassFeature(true)
                                                            .ConfigureWithLogging();
                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }
        }
        internal static void CreateSubtypeFeatures(string name)
        {
            foreach (var eidolonSubtype in EidolonSubtypeInfo.eidolonSubtypes)
            {
                try
                {
                    if (!eidolonSubtype.hide)
                    {
                        var eidolonFeatureName = "Eidolon" + eidolonSubtype.name + name;
                        var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                        var feature = FeatureConfigurator.For(eidolonFeatureGuid);

                        var prerequisites = new List<Blueprint<BlueprintFeatureReference>>();
                        foreach (var baseForm in eidolonSubtype.baseForms)
                        {
                            var baseFormFeatureName = "Eidolon" + Enum.GetName(baseForm.GetType(), baseForm) + "BaseFormFeature";
                            prerequisites.Add(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(baseFormFeatureName)));
                        }
                        feature.AddPrerequisiteFeaturesFromList(prerequisites);

                        var progressionName = "Eidolon" + eidolonSubtype.name + "Progression";
                        feature.AddFeatureOnApply(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(progressionName)));

                        var featureConfigured = feature.ConfigureWithLogging(true);

                        FeatureSelectionConfigurator.For(GetGUID.GUIDByName("EidolonSubtypeSelectionFeature")).AddToAllFeatures(featureConfigured).ConfigureWithLogging(true);
                    }
                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }

            }
        }
    }
}
