using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Armies.State;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionBite
    {
        private static class InternalString
        {
            internal const string Feature = "EvolutionBite"+"Feature";
            internal static LocalizedString FeatureName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString FeatureDescription = Helpers.ObtainString(Feature + ".Description");
            internal const string Ability = "EvolutionBite"+"Ability";
            internal static LocalizedString AbilityName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString AbilityDescription = Helpers.ObtainString(Feature + ".Description");
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(AbilityRefs.AcidMaw.Reference.Get().m_Icon)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference)
                .ConfigureWithLogging(true);
        }
        public static void AdjustAbility()
        {

            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(AbilityRefs.AcidMaw.Reference.Get().m_Icon)
                .ConfigureWithLogging(true);
        }
    }
}
