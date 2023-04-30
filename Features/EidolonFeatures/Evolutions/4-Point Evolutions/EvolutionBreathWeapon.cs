using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Microsoft.Build.Framework.XamlTypes;
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

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._4_Point_Evolutions
{
    internal class EvolutionBreathWeapon
    {
        private static class InternalString
        {
            internal const string Evolution = "EvolutionBreathWeapon";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] {
                                "Acid",
                                "Cold",
                                "Electricity",
                                "Fire" };
            internal static Sprite[] icons = new[] {
                                            AbilityRefs.DragonsBreathGreen.Reference.Get().m_Icon,
                                            AbilityRefs.DragonsBreathSilver.Reference.Get().m_Icon,
                                            AbilityRefs.DragonsBreathBlue.Reference.Get().m_Icon,
                                            AbilityRefs.DragonsBreathGold.Reference.Get().m_Icon,
                                            };
            internal static BlueprintAbilityReference[] copiedAbilities = new BlueprintAbilityReference[] { 
                                             AbilityRefs.DragonbloodShifterGreenBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference,
                                             AbilityRefs.DragonbloodShifterSilverBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference,
                                             AbilityRefs.DragonbloodShifterBlueBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference,
                                             AbilityRefs.DragonbloodShifterGoldBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference
                                            };
        }
        public static void Adjust()
        {
            AdjustFeature();
            ConfigureBreathWeapons();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            for (var i = 0; i < InternalString.abilities.Length; i++)
            {
                var energyType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), InternalString.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Feature"))
                    .SetIcon(InternalString.icons[i])
                    .SetRanks(1)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "BreathAbility")) })
                    .ConfigureWithLogging(true);
            }
        }
        public static void ConfigureBreathWeapons()
        {
            for (var i = 0; i < InternalString.copiedAbilities.Length; i++)
            {
                var energyType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), InternalString.abilities[i]);
                AbilityConfigurator.New(InternalString.Evolution + InternalString.abilities[i] + "BreathAbility",GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "BreathAbility"))
                    .CopyFrom(InternalString.copiedAbilities[i],c => c is not AbilityResourceLogic)
                    .SetDescription(Helpers.ObtainString(InternalString.Evolution + InternalString.abilities[i] + "BreathAbility.Name"))
                    .SetDescription(Helpers.ObtainString(InternalString.Evolution + InternalString.abilities[i] + "BreathAbility.Description"))
                    .SetIcon(InternalString.icons[i])
                    .ConfigureWithLogging();
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < InternalString.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Ability"))
                    .SetIcon(InternalString.icons[i])
                    .AddComponent<AbilityCasterHasFactRank>(c => {
                        c.startLevel = 9;
                    })
                    .AddComponent<AbilityCasterHasNoFacts>(c => {
                        c.m_Facts = new BlueprintUnitFactReference[]
                        {
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Feature")),
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "BaseFeature"))
                        };
                    })
                    .ConfigureWithLogging(true);
            }
        }
    }
}
