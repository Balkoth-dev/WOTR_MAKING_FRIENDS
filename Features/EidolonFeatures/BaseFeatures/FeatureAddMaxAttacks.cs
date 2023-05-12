using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureAddMaxAttacks
    {
        internal static class IClass
        {
            internal const string Feature = "AddMaxAttacksFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal const string StepFeature = "AddMaxAttacksStepFeature";
        }

        public static void Create()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddAbilityResources(0, GetGUID.GUIDByName("EidolonMaxAttacksResource"), true, true)
                .ConfigureWithLogging();

            FeatureConfigurator.New(IClass.StepFeature, GetGUID.GUIDByName(IClass.StepFeature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("EidolonMaxAttacksResource"), 1)
                .SetRanks(40)
                .ConfigureWithLogging();

            FeatureConfigurator.New(IClass.Feature+"Aspect", GetGUID.GUIDByName(IClass.Feature + "Aspect"))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddAbilityResources(99, GetGUID.GUIDByName("EidolonMaxAttacksResource"), true, true)
                .ConfigureWithLogging();
        }

    }
}
