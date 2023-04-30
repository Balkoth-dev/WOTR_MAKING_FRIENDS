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

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionEnergyAttacks
    {
        private static class InternalString
        {
            internal const string Evolution = "EvolutionEnergyAttacks";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] { "Acid", "Cold", "Electricity", "Fire" };
            internal static Sprite[] icons = new[] {
                                            ActivatableAbilityRefs.KineticBladeEarthBlastAbility.Reference.Get().m_Icon,
                                            ActivatableAbilityRefs.KineticBladeColdBlastAbility.Reference.Get().m_Icon,
                                            ActivatableAbilityRefs.KineticBladeElectricBlastAbility.Reference.Get().m_Icon,
                                            ActivatableAbilityRefs.KineticBladeFireBlastAbility.Reference.Get().m_Icon,
                                            };
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            for (var i = 0; i < InternalString.abilities.Length; i++)
            {
                var damageType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), InternalString.abilities[i]);
                Main.Log(Enum.GetName(typeof(DamageEnergyType), damageType));
                FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Feature"))
                    .SetIcon(InternalString.icons[i])
                    .SetRanks(1)
                    .AdditionalDiceOnAttack(allNaturalAndUnarmed: true,value: ContextDice.Value(DiceType.D6),damageType:DamageTypes.Energy(damageType))
                    .ConfigureWithLogging(true); 
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < InternalString.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Ability"))
                    .SetIcon(InternalString.icons[i])
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
