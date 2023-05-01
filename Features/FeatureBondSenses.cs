using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureBondSenses
    {
        private static class IClass
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
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName("SummonerBondedSensesFeature"))
                .CopyFrom(FeatureRefs.PossessedShamanSharedSkillPerception.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddComponent<BondedSensesComponent>()
                .AddRecalculateOnStatChange(stat: Kingmaker.EntitySystem.Stats.StatType.SkillPerception)
                .AddSavesFixerRecalculate()
                .ConfigureWithLogging();
        }
    }
}
