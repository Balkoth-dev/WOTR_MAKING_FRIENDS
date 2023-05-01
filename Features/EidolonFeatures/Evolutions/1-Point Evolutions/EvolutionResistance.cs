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

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionResistance
    {
        private static class InternalClass
        {
            internal const string Evolution = "EvolutionResistance";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] {
                                "Acid",
                                "Cold",
                                "Electricity",
                                "Fire",
                                "Sonic", };
            internal static Sprite[] icons = new[] {
                                            AbilityRefs.ResistAcid.Reference.Get().m_Icon,
                                            AbilityRefs.ResistCold.Reference.Get().m_Icon,
                                            AbilityRefs.ResistElectricity.Reference.Get().m_Icon,
                                            AbilityRefs.ResistFire.Reference.Get().m_Icon,
                                            AbilityRefs.ResistSonic.Reference.Get().m_Icon,
                                            };
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            for (var i = 0; i < InternalClass.abilities.Length; i++)
            {
                var skillType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), InternalClass.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(InternalClass.Evolution + InternalClass.abilities[i] + "Feature"))
                    .SetIcon(InternalClass.icons[i])
                    .SetRanks(1)
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddDamageResistanceEnergy(type:skillType,value:ContextValues.Rank())
                    .ConfigureWithLogging(true);
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 0; i < InternalClass.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(InternalClass.Evolution + InternalClass.abilities[i] + "Ability"))
                    .SetIcon(InternalClass.icons[i])
                    .AddComponent<AbilityCasterHasNoFacts>(c => {
                        c.m_Facts = new BlueprintUnitFactReference[]
                        {
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.Evolution + InternalClass.abilities[i] + "Feature")),
                            BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.Evolution + InternalClass.abilities[i] + "BaseFeature"))
                        };
                    })
                    .ConfigureWithLogging(true);
            }
        }
    }
}
