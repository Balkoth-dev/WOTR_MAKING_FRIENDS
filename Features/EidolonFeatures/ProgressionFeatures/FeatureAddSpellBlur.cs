﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureAddSpellBlur
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddSpellBlur";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
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
        public static void Create()
        {
            CreateFeature();
            CreateAbility();
        }
        internal static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbility.Guid) })
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateAbility()
        {
            AbilityConfigurator.New(IClassAbility.Ability, IClassAbility.Guid)
                .CopyFrom(AbilityRefs.Blur, c => c is not ContextRankConfig)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                .SetCanTargetFriends(false)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free)
                .ConfigureWithLogging();
        }
    }
}