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
    internal class EvolutionAbilityIncrease
    {
        private static class IClass
        {
            internal const string Evolution = "EvolutionAbilityIncrease";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal static string[] abilities = new[] { "","Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
            internal static Sprite[] icons = new[] { 
                                            null,
                                            AbilityRefs.BullsStrength.Reference.Get().m_Icon,
                                            AbilityRefs.CatsGrace.Reference.Get().m_Icon,
                                            AbilityRefs.BearsEndurance.Reference.Get().m_Icon,
                                            AbilityRefs.FoxsCunning.Reference.Get().m_Icon,
                                            AbilityRefs.OwlsWisdom.Reference.Get().m_Icon,
                                            AbilityRefs.EaglesSplendor.Reference.Get().m_Icon
                                            };
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            for(var i = 1; i < IClass.abilities.Length; i++)
            {
                FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"))
                    .SetIcon(IClass.icons[i])
                    .SetRanks(4)
                    .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: (StatType)Enum.Parse(typeof(StatType), i.ToString()), value: 2)
                    .ConfigureWithLogging(true);
            }
        }

        public static void AdjustAbility()
        {
            for (var i = 1; i < IClass.abilities.Length; i++)
            {
                AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Ability"))
                    .SetIcon(IClass.icons[i])
                    .AddComponent<AbilityCasterHasFactRank>(c => {
                        c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"));
                        c.maxRank = 4;
                        c.numLevelsBetweenRanks = 6;
                    })
                    .ConfigureWithLogging(true);
            }
        }
    }
}
