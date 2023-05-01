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
    internal class EvolutionSkilled
    {
        private static class InternalClass
        {
            internal const string Evolution = "EvolutionSkilled";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] { "SkillPerception", "SkillThievery", "SkillUseMagicDevice"};
            internal static Sprite[] icons = new[] {
                                            FeatureRefs.SkillFocusPerception.Reference.Get().m_Icon,
                                            FeatureRefs.SkillFocusThievery.Reference.Get().m_Icon,
                                            FeatureRefs.SkillFocusUseMagicDevice.Reference.Get().m_Icon,
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
                var skillType = (StatType)Enum.Parse(typeof(StatType), InternalClass.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(InternalClass.Evolution + InternalClass.abilities[i] + "Feature"))
                    .SetIcon(InternalClass.icons[i])
                    .SetRanks(1)
                    .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: skillType, value: 8)
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
