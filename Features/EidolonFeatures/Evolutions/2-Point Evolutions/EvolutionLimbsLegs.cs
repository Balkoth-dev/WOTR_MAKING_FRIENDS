using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.BlueprintAbilityResource;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionLimbsLegs
    {
        private static class InternalString
        {
            internal static Sprite icon = AssetLoader.LoadInternal("Evolutions", "EvolutionLimbsLegs.png");
            internal const string Evolution = "EvolutionLimbsLegs";
            internal const string Feature = Evolution + "Feature";
            
            
            internal const string Ability = Evolution + "Ability";
            
            
            internal const string ActivatableAbility = Evolution + "ActivatableAbility";
            internal static LocalizedString ActivatableAbilityName = Helpers.ObtainString(ActivatableAbility + ".Name");
            internal static LocalizedString ActivatableAbilityDescription = Helpers.ObtainString(ActivatableAbility + ".Description");
            internal const string Buff = Evolution + "Buff";
            internal static LocalizedString BuffName = Helpers.ObtainString(Buff + ".Name");
            internal static LocalizedString BuffDescription = Helpers.ObtainString(Buff + ".Description");
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: StatType.Speed, value: 10)
                .SetRanks(99)
                .ConfigureWithLogging(true);
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .ConfigureWithLogging(true);
        }
    }
}
