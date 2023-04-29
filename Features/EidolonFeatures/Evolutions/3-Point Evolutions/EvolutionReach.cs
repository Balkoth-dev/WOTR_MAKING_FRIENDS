﻿using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions
{
    internal class EvolutionReach
    {
        private static class InternalString
        {
            internal static Sprite icon = FeatureRefs.LungeFeature.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionReach";
            internal const string Feature = Evolution + "Feature";
            internal const string Ability = Evolution + "Ability";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .AddStatBonus(descriptor:Kingmaker.Enums.ModifierDescriptor.Other,false,StatType.Reach,5)
                .ConfigureWithLogging(true);
        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .AddComponent<AbilityCasterHasNoFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Feature))
                    };
                })
                .ConfigureWithLogging(true);
        }
    }
}