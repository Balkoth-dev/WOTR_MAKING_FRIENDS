using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Designers.Mechanics.Facts.ModifyD20;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureImmunityFortitudeSave
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "ImmunityFortitudeSave";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            CreateFeature();
        }
        internal static void CreateFeature()
        {

            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .SetGroups(IClass.featureGroup)
                    .AddModifyD20(rule: RuleType.SavingThrow, savingThrowType: Kingmaker.RuleSystem.Rules.FlaggedSavingThrowType.Fortitude, replace: true, rollResult: ContextValues.Constant(20))
                    .ConfigureWithLogging();
        }
    }
}
