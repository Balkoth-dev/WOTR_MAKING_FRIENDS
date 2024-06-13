using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionSlam
    {
        internal static class IClass
        {
            internal static Sprite icon = ActivatableAbilityRefs.TerribleSlamAbilityLevel1.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionSlam";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
            internal const string ActivatableAbility = Evolution + "ActivatableAbility";
            internal static LocalizedString ActivatableAbilityName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString ActivatableAbilityDescription = Helpers.ObtainString(Feature + ".Description");
            internal const string Buff = Evolution + "Buff";
            internal static LocalizedString BuffName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString BuffDescription = Helpers.ObtainString(Feature + ".Description");
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
            AddWeaponEmptyHandOverrideAbility();
            AddEvolutionBuff();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.ActivatableAbility)) })
                .AddManeuverBonus(type: Kingmaker.RuleSystem.Rules.CombatManeuver.BullRush, bonus: 2, descriptor: Kingmaker.Enums.ModifierDescriptor.Racial)
                .ConfigureWithLogging(true);
        }
        public static void AddWeaponEmptyHandOverrideAbility()
        {
            ActivatableAbilityConfigurator.New(IClass.ActivatableAbility, GetGUID.GUIDByName(IClass.ActivatableAbility))
                .SetDisplayName(IClass.ActivatableAbilityName)
                .SetDescription(IClass.ActivatableAbilityDescription)
                .SetIcon(IClass.icon)
                .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                .SetDeactivateImmediately(true)
                .SetActivateWithUnitCommand(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Free)
                .SetActivateOnUnitAction(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivateOnUnitActionType.Attack)
                .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName(IClass.Buff)))
                .ConfigureWithLogging();
        }
        public static void AddEvolutionBuff()
        {
            BuffConfigurator.New(IClass.Buff, GetGUID.GUIDByName(IClass.Buff))
                .SetDisplayName(IClass.BuffName)
                .SetDescription(IClass.BuffDescription)
                .SetIcon(IClass.icon)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Slam1d8.Cast<BlueprintItemWeaponReference>().Reference)
                .ConfigureWithLogging();
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
