using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
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
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Units;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    internal class FeatureEidolonSelection
    {
        private static class InternalClass
        {
            internal const string BaseFeatureSelection = "EidolonBaseFeatureSelection";
            internal const string BaseFormSelectionFeature = "BaseFormSelectionFeature";
            internal const string Feature = "CompanionFeature";
        }

        public static void Create()
        {
            BaseFeatureSelection();
            BaseFormSelectionFeatures(InternalClass.BaseFormSelectionFeature, new EnumsEidolonBaseForm());
            EidolonFeature(InternalClass.Feature, UnitEidolons.newUnits);
        }

        internal static void BaseFeatureSelection()
        {
            var feature = FeatureSelectionConfigurator.New(InternalClass.BaseFeatureSelection, GetGUID.GUIDByName(InternalClass.BaseFeatureSelection))
                                                    .SetDisplayName(Helpers.ObtainString(InternalClass.BaseFeatureSelection + ".Name"))
                                                    .SetDescription(Helpers.ObtainString(InternalClass.BaseFeatureSelection + ".Description"))
                                                    .SetHideInUI(false)
                                                    .SetHideInCharacterSheetAndLevelUp(false)
                                                    .SetGroups(FeatureGroup.AnimalCompanion)
                                                    .SetRanks(1)
                                                    .SetIsClassFeature(true)
                                                    .ConfigureWithLogging();
        }

        internal static void BaseFormSelectionFeatures(string name, Enum enumType)
        {
            foreach (var eidolonBaseForm in Enum.GetValues(enumType.GetType()))
            {
                try
                {
                    var eidolonFeatureName = "Eidolon" + Enum.GetName(enumType.GetType(), eidolonBaseForm) + name;
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var feature = FeatureSelectionConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
                                                            .SetDisplayName(Helpers.ObtainString(eidolonFeatureName + ".Name"))
                                                            .SetDescription(Helpers.ObtainString(eidolonFeatureName + ".Description"))
                                                            .SetHideInUI(false)
                                                            .SetHideInCharacterSheetAndLevelUp(false)
                                                            .SetGroups(FeatureGroup.AnimalCompanion)
                                                            .SetRanks(1)
                                                            .SetIsClassFeature(true)
                                                            .ConfigureWithLogging();

                    FeatureSelectionConfigurator.For(GetGUID.GUIDByName(InternalClass.BaseFeatureSelection)).AddToAllFeatures(eidolonFeatureGuid).ConfigureWithLogging(true);

                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }
        }

        internal static void EidolonFeature(string featureName, NewUnitClass[] eidolons)
        {
            foreach (var eidolon in eidolons)
            {
                try
                {
                    AddEidolon addEidolon = new AddEidolon()
                    {
                        m_Pet = BlueprintTool.GetRef<BlueprintUnitReference>(eidolon.Guid),
                        ProgressionType = PetProgressionTypeExtensions.EidolonProgression,
                        m_UseContextValueLevel = false,
                        m_LevelRank = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonRankFeature")),
                        Type = PetTypeExtensions.Eidolon,
                        m_ForceAutoLevelup = false
                    };

                    var eidolonFeatureName = eidolon.Name + featureName;
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    var feature = FeatureConfigurator.New(eidolonFeatureName, eidolonFeatureGuid)
                                                        .SetDisplayName(Helpers.ObtainString(eidolonFeatureName + ".Name"))
                                                        .SetDescription(Helpers.ObtainString(eidolonFeatureName + ".Description"))
                                                        .AddFeatureOnApply(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonProgression")))
                                                        .AddFeatureOnApply(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonRankFeature")))
                                                        .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                                                        .SetRanks(1)
                                                        .SetReapplyOnLevelUp(true)
                                                        .SetIsClassFeature(true)
                                                        .SetGroups(FeatureGroup.AnimalCompanion)
                                                        .ConfigureWithLogging();

                    feature.AddComponents(new[] { addEidolon });

                    var eidolonBaseFormType = Enum.GetName(typeof(EnumsEidolonBaseForm), eidolon.eidolonBaseForm);
                    var eidolonSelectionFeatureName = "Eidolon" + eidolonBaseFormType + InternalClass.BaseFormSelectionFeature;
                    var eidolonSelectionFeatureGuid = GetGUID.GUIDByName(eidolonSelectionFeatureName);
                    FeatureSelectionConfigurator.For(eidolonSelectionFeatureGuid).AddToAllFeatures(eidolonFeatureGuid).ConfigureWithLogging(true);
                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }
        }
    }
}
