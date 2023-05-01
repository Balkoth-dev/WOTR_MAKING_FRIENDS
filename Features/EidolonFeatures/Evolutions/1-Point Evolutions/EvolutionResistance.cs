using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionResistance
    {
        internal static class IClass
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
            for (var i = 0; i < IClass.abilities.Length; i++)
            {
                var skillType = (DamageEnergyType)Enum.Parse(typeof(DamageEnergyType), IClass.abilities[i]);
                FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Evolution + IClass.abilities[i] + "Feature"))
                    .SetIcon(IClass.icons[i])
                    .SetRanks(1)
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddDamageResistanceEnergy(type: skillType, value: ContextValues.Rank())
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
