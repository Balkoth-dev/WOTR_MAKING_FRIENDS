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

            foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonBaseForm)))
            {
                try
                {
                    var eidolonFeatureName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + "BaseFormFeature";
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var characterClass = FeatureConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
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
            foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonSubtype)))
            {
                try
                {
                    var eidolonFeatureName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonSubtype), eidolonBaseForm) + "SubtypeFeature";
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var characterClass = FeatureConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
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
