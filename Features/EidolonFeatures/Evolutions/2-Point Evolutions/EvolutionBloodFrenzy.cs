using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionBloodFrenzy
    {
        internal static class IClass
        {
            internal static Sprite icon = AbilityRefs.Rage.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionBloodFrenzy";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
            internal const string ActivatableAbility = Evolution + "ActivatableAbility";
            internal static LocalizedString ActivatableAbilityName = Helpers.ObtainString(ActivatableAbility + ".Name");
            internal static LocalizedString ActivatableAbilityDescription = Helpers.ObtainString(ActivatableAbility + ".Description");
            internal const string Buff = Evolution + "Buff";
            internal static LocalizedString BuffName = Helpers.ObtainString(Buff + ".Name");
            internal static LocalizedString BuffDescription = Helpers.ObtainString(Buff + ".Description");
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
            AddWeaponFrenzyOverrideAbility();
            AddEvolutionBuff();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.ActivatableAbility)) })
                .ConfigureWithLogging(true);
        }
        public static void AddWeaponFrenzyOverrideAbility()
        {
            ActivatableAbilityConfigurator.New(IClass.ActivatableAbility, GetGUID.GUIDByName(IClass.ActivatableAbility))
                .SetDisplayName(IClass.ActivatableAbilityName)
                .SetDescription(IClass.ActivatableAbilityDescription)
                .SetIcon(IClass.icon)
                .SetActivationType(AbilityActivationType.Immediately)
                .SetDeactivateImmediately(true)
                .SetActivateWithUnitCommand(UnitCommand.CommandType.Free)
                .SetActivateOnUnitAction(AbilityActivateOnUnitActionType.Attack)
                .AddRestrictionHasUnitCondition(UnitCondition.Fatigued, invert: true)
                .AddRestrictionHasUnitCondition(UnitCondition.Exhausted, invert: true)
                .SetOnlyInCombat(true)
                .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName(IClass.Buff)))
                .ConfigureWithLogging();
        }
        public static void AddEvolutionBuff()
        {
            BuffConfigurator.New(IClass.Buff, GetGUID.GUIDByName(IClass.Buff))
                .SetDisplayName(IClass.BuffName)
                .SetDescription(IClass.BuffDescription)
                .SetIcon(IClass.icon)
                .AddFactContextActions(ActionsBuilder.New().BuffActionAddStatBonus(descriptor: ModifierDescriptor.Morale, StatType.AdditionalAttackBonus, ContextValues.Constant(2))
                                                           .BuffActionAddStatBonus(descriptor: ModifierDescriptor.Morale, StatType.AdditionalDamage, ContextValues.Constant(2))
                                                           .Build(),
                                                           ActionsBuilder.New().ApplyBuff(BuffRefs.Fatigued.Cast<BlueprintBuffReference>().Reference, ContextDuration.Fixed(1, DurationRate.Minutes)))
                .AddCombatStateTrigger(ActionsBuilder.New().RemoveSelf())
                .AddCondition(UnitCondition.AttackNearest)
                .ConfigureWithLogging();
        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityOwnerOrPetHasFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonAberrantSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDaemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("GrandEidolonFeature")),
                    };
                    c.petType = PetTypeExtensions.Eidolon;
                })
                .AddComponent<AbilityCasterHasNoFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Feature)),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.BaseFeature))
                    };
                })
                .ConfigureWithLogging(true);
        }
    }
}
