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
        private static class InternalString
        {
            internal const string Feature = "AddMaxAttacksFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal const string StepFeature = "AddMaxAttacksStepFeature";
        }

        public static void Create()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddAbilityResources(0, GetGUID.GUIDByName("EidolonMaxAttacksResource"),true,true)
                .ConfigureWithLogging();

            FeatureConfigurator.New(InternalString.StepFeature, GetGUID.GUIDByName(InternalString.StepFeature))
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AbilityRefs.MagicFangGreater.Reference.Get().m_Icon)
                .AddIncreaseResourceAmount(GetGUID.GUIDByName("EidolonMaxAttacksResource"), 1)
                .SetRanks(40)
                .ConfigureWithLogging();
        }

    }
}
