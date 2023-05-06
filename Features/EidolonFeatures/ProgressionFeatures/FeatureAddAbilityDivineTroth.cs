﻿using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureAddAbilityDivineTroth
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddAbilityDivineTroth";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.DivineGuardianTrothFeature.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassAbility
        {
            internal static string Ability = IClass.ProgressionFeature + "Ability";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static string Name = Helpers.ObtainString(Ability + ".Name");
            internal static string Description = Helpers.ObtainString(Ability + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public static class IClassResource
        {
            internal static string Resource = IClass.ProgressionFeature + "Resource";
            internal static string Guid = GetGUID.GUIDByName(Resource);
        }
        public static void Create()
        {
            CreateFeature();
            CreateResource();
            CreateAbility();
        }
        internal static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbility.Guid), FeatureRefs.DivineGuardianCourageousDefense.Cast<BlueprintUnitFactReference>() })
                    .AddAbilityResources(1,BlueprintTool.GetRef<BlueprintAbilityResourceReference>(IClassResource.Guid),true)
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateResource()
        {
            BlueprintAbilityResource.Amount maxAmount = ResourceAmountBuilder.New(1).Build();
            AbilityResourceConfigurator.New(IClassResource.Resource, IClassResource.Guid)
                .SetMaxAmount(maxAmount)
                .ConfigureWithLogging();
        }
        internal static void CreateAbility()
        {
            AbilityConfigurator.New(IClassAbility.Ability, IClassAbility.Guid)
                .CopyFrom(AbilityRefs.DivineGuardianTrothAbility, c => c is not (AbilityCasterAlignment or AbilityResourceLogic))
                .AddAbilityResourceLogic(amount: 1, isSpendResource: true,  requiredResource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(IClassResource.Guid))
                .ConfigureWithLogging();
        }
    }
}
