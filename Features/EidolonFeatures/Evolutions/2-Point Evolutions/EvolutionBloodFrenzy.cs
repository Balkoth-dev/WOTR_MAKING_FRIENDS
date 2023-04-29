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
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionBloodFrenzy
    {
        private static class InternalString
        {
            internal static Sprite icon = AbilityRefs.Rage.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionBloodFrenzy";
            internal const string Feature = Evolution + "Feature";
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
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.ActivatableAbility)) })
                .ConfigureWithLogging(true);
        }
        public static void AddWeaponFrenzyOverrideAbility()
        {
            ActivatableAbilityConfigurator.New(InternalString.ActivatableAbility, GetGUID.GUIDByName(InternalString.ActivatableAbility))
                .SetDisplayName(InternalString.ActivatableAbilityName)
                .SetDescription(InternalString.ActivatableAbilityDescription)
                .SetIcon(InternalString.icon)
                .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                .SetDeactivateImmediately(true)
                .SetActivateWithUnitCommand(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free)
                .SetActivateOnUnitAction(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivateOnUnitActionType.Attack)
                .AddRestrictionHasUnitCondition(Kingmaker.UnitLogic.UnitCondition.Fatigued,invert:true)
                .AddRestrictionHasUnitCondition(Kingmaker.UnitLogic.UnitCondition.Exhausted, invert: true)
                .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName(InternalString.Buff)))
                .ConfigureWithLogging();
        }
        public static void AddEvolutionBuff()
        {
            BuffConfigurator.New(InternalString.Buff, GetGUID.GUIDByName(InternalString.Buff))
                .SetDisplayName(InternalString.BuffName)
                .SetDescription(InternalString.BuffDescription)
                .SetIcon(InternalString.icon)
                .AddFactContextActions(ActionsBuilder.New().BuffActionAddStatBonus(descriptor:ModifierDescriptor.Morale,StatType.AdditionalAttackBonus,ContextValues.Constant(2))
                                                           .BuffActionAddStatBonus(descriptor: ModifierDescriptor.Morale, StatType.AdditionalDamage, ContextValues.Constant(2))
                                                           .Build(),
                                                           ActionsBuilder.New().ApplyBuff(BuffRefs.Fatigued.Cast<BlueprintBuffReference>().Reference,ContextDuration.Fixed(1,DurationRate.Minutes)))
                .AddCombatStateTrigger(ActionsBuilder.New().RemoveSelf())
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.AttackNearest)
                .ConfigureWithLogging();
        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .AddComponent<AbilityCasterHasFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonAberrantSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDaemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDemonSubtypeFeature"))
                    };
                })
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
