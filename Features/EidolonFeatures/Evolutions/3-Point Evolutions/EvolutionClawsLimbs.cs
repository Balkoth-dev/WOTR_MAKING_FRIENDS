﻿using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions
{
    internal class EvolutionClawsLimbs
    {
        internal static class IClass
        {
            internal static Sprite icon = FeatureRefs.StoneclawStrikeShifterFeature.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionClawsLimbs";
            internal static int Ranks = 10;
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
            internal const string AdditionalWeapon = "AdditionalWeaponClaw";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            var additionalWeapon = ItemWeaponConfigurator.New(IClass.AdditionalWeapon, GetGUID.GUIDByName(IClass.AdditionalWeapon))
                .CopyFrom(ItemWeaponRefs.Slam1d4)
                .SetType(WeaponTypeRefs.ClawType.Cast<BlueprintWeaponTypeReference>().Reference)
                .ConfigureWithLogging(true);

            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddComponent<AddSecondaryAttacksItemsByRank>(c =>
                {
                    c.m_Weapon = ItemWeaponRefs.Claw1d4.Cast<BlueprintItemWeaponReference>().Reference;
                    c.limbCount = 2;
                    c.m_feature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(IClass.Feature));
                })
                .SetRanks(IClass.Ranks)
                .ConfigureWithLogging(true);

        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasResource>(c =>
                {
                    c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource"));
                    c.resourceAmount = 2;
                })
                .ConfigureWithLogging(true);
        }
    }
}
