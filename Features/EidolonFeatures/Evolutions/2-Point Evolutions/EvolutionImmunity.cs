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
    internal class EvolutionImmunity
    {
        private static class InternalString
        {
            internal const string Evolution = "EvolutionImmunity";
            internal const string Feature = Evolution + "Feature";
            internal static string[] abilities = new[] {
                                "Acid",
                                "Cold",
                                "Electricity",
                                "Fire",
                                "Sonic", };
            internal static Sprite[] icons = new[] {
                                            AbilityRefs.ProtectionFromAcid.Reference.Get().m_Icon,
                                            AbilityRefs.ProtectionFromCold.Reference.Get().m_Icon,
                                            AbilityRefs.ProtectionFromElectricity.Reference.Get().m_Icon,
                                            AbilityRefs.ProtectionFromFire.Reference.Get().m_Icon,
                                            AbilityRefs.ProtectionFromSonic.Reference.Get().m_Icon,
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
                var energyType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), InternalString.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Feature"))
                    .SetIcon(InternalString.icons[i])
                    .SetRanks(1)
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddEnergyImmunity(type: energyType)
                    .ConfigureWithLogging(true);
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < InternalString.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Ability"))
                    .SetIcon(InternalString.icons[i])
                    .AddComponent<AbilityCasterHasFactRank>(c => {
                        c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Evolution + InternalString.abilities[i] + "Feature"));
                        c.maxRank = 1;
                    })
                    .ConfigureWithLogging(true);
            }
        }
    }
}
