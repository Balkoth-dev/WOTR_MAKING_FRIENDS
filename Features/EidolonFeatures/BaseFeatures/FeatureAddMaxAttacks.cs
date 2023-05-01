using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureAddMaxAttacks
    {
        private static class InternalClass
        {
            internal const string Feature = "AddMaxAttacksFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal const string StepFeature = "AddMaxAttacksStepFeature";
        }

        public static void Create()
        {
            FeatureConfigurator.New(InternalClass.Feature, GetGUID.GUIDByName(InternalClass.Feature))
                .SetDisplayName(InternalClass.Name)
                .SetDescription(InternalClass.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddAbilityResources(0, GetGUID.GUIDByName("EidolonMaxAttacksResource"),true,true)
                .ConfigureWithLogging();

            FeatureConfigurator.New(InternalClass.StepFeature, GetGUID.GUIDByName(InternalClass.StepFeature))
                .SetDisplayName(InternalClass.Name)
                .SetDescription(InternalClass.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("EidolonMaxAttacksResource"), 1)
                .SetRanks(40)
                .ConfigureWithLogging();
        }

    }
}
