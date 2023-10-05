using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureStartingEvolutions
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonStartingEvolutions";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.MagicFangGreater.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }

        private static BlueprintUnitFactReference evolutionLimbsArms = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionLimbsArmsFeature"));
        private static BlueprintUnitFactReference evolutionBaseLimbsArms = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionLimbsArmsBaseFeature"));
        private static BlueprintUnitFactReference evolutionClaws = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionClawsBaseFeature"));
        private static BlueprintUnitFactReference evolutionTentacles = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionTentacleMassBaseFeature"));
        private static BlueprintUnitFactReference evolutionBite = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionBiteBaseFeature"));
        private static BlueprintUnitFactReference evolutionTail = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionTailBaseFeature"));
        private static BlueprintUnitFactReference evolutionTailSlap = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionTailSlapBaseFeature"));
        private static BlueprintUnitFactReference evolutionSlam = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSlamBaseFeature"));
        private static BlueprintUnitFactReference evolutionMagicAttacks = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionMagicAttacksBaseFeature"));
        private static BlueprintUnitFactReference evolutionSpike = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSpikeBaseFeature"));
        private static BlueprintUnitFactReference evolutionNaturalArmor = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionNaturalArmorBaseFeature"));
        private static BlueprintUnitFactReference evolutionWingBuffet = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionWingBuffetBaseFeature"));

        public static void Create()
        {
            var allfeatures = new List<Blueprint<BlueprintFeatureReference>>();

            foreach (var subtype in EidolonSubtypes.eidolonSubtypes)
            {
                foreach (var baseform in subtype.baseForms)
                {
                    allfeatures.Add(CreateFeatureRef(baseform, subtype.subtype));
                }
            }

            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetRanks(IClass.Ranks)
                .SetGroup(IClass.featureGroup)
                .SetAllFeatures(allfeatures.ToArray())
                .ConfigureWithLogging();
        }

        internal static BlueprintFeatureReference CreateFeatureRef(EnumsEidolonBaseForm baseForm, EnumsEidolonSubtype subtype)
        {
            var baseFormName = Enum.GetName(baseForm.GetType(), baseForm);
            var subtypeName = Enum.GetName(subtype.GetType(), subtype);
            var featureName = baseFormName + subtypeName + "StartingEvolutionsFeature";
            var featureGuid = GetGUID.GUIDByName(featureName);

            var feature = FeatureConfigurator.New(featureName, featureGuid, IClass.featureGroup)
                .SetDisplayName(Helpers.ObtainString(featureName + ".Name"))
                .SetDisplayName(Helpers.ObtainString(featureName + ".Description"))
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("Eidolon" + subtypeName + "SubtypeFeature")))
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("Eidolon" + baseFormName + "BaseFormFeature")));

            var addFacts = new List<Blueprint<BlueprintUnitFactReference>>();

            if (baseForm == EnumsEidolonBaseForm.Biped)
            {
                addFacts.Add(evolutionLimbsArms);
                addFacts.Add(evolutionBaseLimbsArms);
                if (subtype == EnumsEidolonSubtype.Aberrant)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Aeon)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Agathion)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Angel)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Archon)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Astral)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Daemon)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Demon)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Devil)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Div)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Elemental)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Inevitable)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Kami)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Kyton)
                {
                    addFacts.Add(evolutionNaturalArmor);
                }
                else if (subtype == EnumsEidolonSubtype.Psychopomp)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Shadow)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Storykin)
                {
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Void)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionWingBuffet);
                }
            }

            if (baseForm == EnumsEidolonBaseForm.Quadruped)
            {
                if (subtype == EnumsEidolonSubtype.Radiant)
                {
                    addFacts.Add(evolutionClaws);
                }
                else if (subtype == EnumsEidolonSubtype.Storykin)
                {
                    addFacts.Add(evolutionSlam);
                }
                else
                {
                    addFacts.Add(evolutionBite);
                }
            }

            if (baseForm == EnumsEidolonBaseForm.Serpentine)
            {
                addFacts.Add(evolutionTail);
                if (subtype == EnumsEidolonSubtype.Aberrant)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Aeon)
                {
                    addFacts.Add(evolutionBaseLimbsArms);
                    addFacts.Add(evolutionLimbsArms);
                    addFacts.Add(evolutionSlam);
                }
                else if (subtype == EnumsEidolonSubtype.Astral)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionMagicAttacks);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Azata)
                {
                    addFacts.Add(evolutionBaseLimbsArms);
                    addFacts.Add(evolutionLimbsArms);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Daemon)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionSpike);
                }
                else if (subtype == EnumsEidolonSubtype.Deepwater)
                {
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Demon)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Elemental)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionNaturalArmor);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Protean)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Protean)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Shadow)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionNaturalArmor);
                    addFacts.Add(evolutionTailSlap);
                }
                else if (subtype == EnumsEidolonSubtype.Shadow)
                {
                    addFacts.Add(evolutionBite);
                    addFacts.Add(evolutionTailSlap);
                }
            }

            if (baseForm == EnumsEidolonBaseForm.Abberant)
            {
                addFacts.Add(evolutionBite);
                addFacts.Add(evolutionTentacles);
            }

            feature.AddFacts(addFacts);

            feature.ConfigureWithLogging();

            return BlueprintTool.GetRef<BlueprintFeatureReference>(featureGuid);

        }

    }
}
