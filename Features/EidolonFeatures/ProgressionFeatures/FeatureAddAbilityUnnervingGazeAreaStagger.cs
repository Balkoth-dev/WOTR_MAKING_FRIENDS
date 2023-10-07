using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureAddAbilityUnnervingGazeAreaStagger
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddAbilityUnnervingGazeAreaStagger";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.WitchHexEvilEyeAbility.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassAbility
        {
            internal static string Ability = IClass.ProgressionFeature + "Ability";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static LocalizedString Name = IClass.Name;
            internal static LocalizedString Description = IClass.Description;
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
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbility.Guid) })
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateAbility()
        {
            var failedEffect = ActionsBuilder.New().ApplyBuffWithDurationSeconds(BuffRefs.Staggered.Cast<BlueprintBuffReference>(), 6).Build();
            var sickenEffect = ActionsBuilder.New().ConditionalSaved(failed: failedEffect).ApplyBuffWithDurationSeconds(BlueprintTool.GetRef<BlueprintBuffReference>(FeatureAddAbilityUnnervingGaze.IClassBuff.Guid), 6, toCaster: true).Build();

            AbilityConfigurator.New(IClassAbility.Ability, IClassAbility.Guid)
                .SetIcon(IClassAbility.Icon)
                .SetDisplayName(IClassAbility.Name)
                .SetDescription(IClassAbility.Description)
                .AddAbilityEffectRunAction(sickenEffect, savingThrowType: SavingThrowType.Will)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .SetCanTargetEnemies(true)
                .SetCanTargetFriends(false)
                .SetCanTargetSelf(false)
                .SetCanTargetPoint(false)
                .AddAbilityDeliverChain(targetDead: false, targetType: TargetType.Enemy, targetsCount: 3, radius: 15.Feet(), projectile: ProjectileRefs.Dummy00_Projectile.Cast<BlueprintProjectileReference>(), projectileFirst: ProjectileRefs.Dummy00_Projectile.Cast<BlueprintProjectileReference>())
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free)
                .AddAbilityCasterHasNoFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureAddAbilityUnnervingGaze.IClassBuff.Guid) })
                .ConfigureWithLogging();
        }
    }
}
