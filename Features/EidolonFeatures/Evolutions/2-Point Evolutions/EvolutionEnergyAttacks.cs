using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionEnergyAttacks
    {
        internal static class IClass
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
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                var damageType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), IClass.abilities[i]);
                Main.Log(Enum.GetName(typeof(DamageEnergyType), damageType));
                FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"))
                    .SetIcon(IClass.icons[i])
                    .SetRanks(1)
                    .AdditionalDiceOnAttack(allNaturalAndUnarmed: true, value: ContextDice.Value(DiceType.D6), damageType: DamageTypes.Energy(damageType))
                    .ConfigureWithLogging(true);
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Ability"))
                    .SetIcon(IClass.icons[i])
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
