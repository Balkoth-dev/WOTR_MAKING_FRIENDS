using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static RootMotion.FinalIK.GrounderQuadruped;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    internal class FeatureEidolonTypes
    {
        private static class InternalString
        {
            internal const string Feature = "EidolonSubtypeFeature";
            internal static LocalizedString Name = Helpers.ObtainString("eidolonsubtypefeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("eidolonsubtypefeature.Description");
        }
        public static void Create()
        {
            CreateBaseFeature();
            CreateEnumFeature("BaseFormFeature", new EnumsEidolonBaseForm());
            CreateEnumFeature("SubtypeFeature", new EnumsEidolonSubtype());
            CreateEnumFeature("VariantFeature", new EnumsEidolonVariant());
        }
        internal static void CreateBaseFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.EidolonSubtypeFeature)
                               .SetDisplayName(InternalString.Name)
                               .SetDescription(InternalString.Description)
                               .SetHideInUI(true)
                               .SetHideInCharacterSheetAndLevelUp(true)
                               .SetGroups(FeatureGroup.CreatureType)
                               .SetRanks(1)
                               .SetIsClassFeature(true)
                               .Configure();

            Main.Log("EidolonSubtypeFeature : " + GetGUID.EidolonSubtypeFeature + " created.");

        }
        internal static void CreateEnumFeature(string name, Enum enumType)
        {
            foreach (var eidolonBaseForm in Enum.GetValues(enumType.GetType()))
            {
                try
                {
                    var eidolonFeatureName = "Eidolon" + Enum.GetName(enumType.GetType(), eidolonBaseForm) + name;
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var feature = FeatureConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
                                                            .SetDisplayName(Helpers.ObtainString(eidolonFeatureName + ".Name"))
                                                            .SetHideInUI(true)
                                                            .SetHideInCharacterSheetAndLevelUp(true)
                                                            .SetGroups(FeatureGroup.CreatureType)
                                                            .SetRanks(1)
                                                            .SetIsClassFeature(true)
                                                            .Configure();

                    Main.Log(eidolonFeatureName + " : " + eidolonFeatureGuid + " created.");
                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }
        }
    }
}
