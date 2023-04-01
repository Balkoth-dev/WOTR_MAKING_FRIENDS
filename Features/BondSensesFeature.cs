using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class BondedSensesFeature
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerBondedSensesFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerBondedSensesFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerBondedSensesFeature.Description");
        }
        public static void CreateBondedSenses()
        {
            CreateBondedSensesFeature();
        }
        public static void CreateBondedSensesFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.SummonerBondedSensesFeature)
                .CopyFrom(FeatureRefs.PossessedShamanSharedSkillPerception.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddComponent<BondedSensesComponent>()
                .AddRecalculateOnStatChange(stat: Kingmaker.EntitySystem.Stats.StatType.SkillPerception)
                .AddSavesFixerRecalculate()
                .Configure();
        }
    }
}
