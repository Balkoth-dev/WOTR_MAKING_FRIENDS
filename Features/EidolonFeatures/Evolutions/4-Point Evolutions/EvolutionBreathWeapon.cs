using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._4_Point_Evolutions
{
    internal class EvolutionBreathWeapon
    {
        internal static class IClass
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
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                var energyType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), IClass.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"))
                    .SetIcon(IClass.icons[i])
                    .SetRanks(1)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "BreathAbility")) })
                    .ConfigureWithLogging(true);
            }
        }
        public static void ConfigureBreathWeapons()
        {
            for (var i = 0; i < IClass.copiedAbilities.Length; i++)
            {
                var energyType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), IClass.abilities[i]);
                AbilityConfigurator.New(IClass.Evolution + IClass.abilities[i] + "BreathAbility", GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "BreathAbility"))
                    .CopyFrom(IClass.copiedAbilities[i], c => c is not AbilityResourceLogic)
                    .SetDescription(Helpers.ObtainString(IClass.Evolution + IClass.abilities[i] + "BreathAbility.Name"))
                    .SetDescription(Helpers.ObtainString(IClass.Evolution + IClass.abilities[i] + "BreathAbility.Description"))
                    .SetIcon(IClass.icons[i])
                    .ConfigureWithLogging();
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Ability"))
                    .SetIcon(IClass.icons[i])
                    .AddComponent<AbilityCasterHasFactRank>(c =>
                    {
                        c.startLevel = 9;
                    })
                    .AddComponent<AbilityCasterHasNoFacts>(c =>
                    {
                        c.m_Facts = new BlueprintUnitFactReference[]
                        {
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature")),
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "BaseFeature"))
                        };
                    })
                    .ConfigureWithLogging(true);
            }
        }
    }
}
