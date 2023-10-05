using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionSkilled
    {
        internal static class IClass
        {
            internal const string Evolution = "EvolutionSkilled";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] { "SkillPerception", "SkillThievery", "SkillUseMagicDevice" };
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
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                var skillType = (StatType)Enum.Parse(typeof(StatType), IClass.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"))
                    .SetIcon(IClass.icons[i])
                    .SetRanks(1)
                    .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: skillType, value: 8)
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
