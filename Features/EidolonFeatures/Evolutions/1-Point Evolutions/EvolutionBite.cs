using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.FactLogic.LockEquipmentSlot;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions;

internal class EvolutionBite
{
    internal static class IClass
    {
        internal static Sprite icon = ItemWeaponRefs.Bite1d10.Reference.Get().m_Icon;
        internal const string Evolution = "EvolutionBite";
        internal const string Feature = Evolution + "Feature";
        internal const string BiteFeature = Evolution + "BiteFeature";
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
        FeatureConfigurator.New(IClass.BiteFeature, GetGUID.GUIDByName(IClass.BiteFeature))
            .SetIcon(IClass.icon)
            .AddAdditionalLimb(weapon: ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference)
            .ConfigureWithLogging();

        FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
            .SetIcon(IClass.icon)
            .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.ActivatableAbility)) })
            .AddFeatureIfHasFact(checkedFact: BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Buff)),
                                 feature: BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.BiteFeature)),
                                 not: true)
            .AddIncreaseResourceAmount(GetGUID.GUIDByName("EidolonMaxAttacksResource"), -1)
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
        Kingmaker.ElementsSystem.ActionList applyEvolutionBiteBite = ActionsBuilder.New().OnContextCaster(ActionsBuilder.New().AddFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(IClass.BiteFeature))))
                                                       .Build();
        var factExceptionList = new List<BlueprintUnitFactReference> { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionLimbsArmsFeature")) };


        BuffConfigurator.New(IClass.Buff, GetGUID.GUIDByName(IClass.Buff))
            .SetDisplayName(IClass.BuffName)
            .SetDescription(IClass.BuffDescription)
            .SetIcon(IClass.icon)
            .AddComponent<AddWeaponOverride>(c => { c.m_Blade = ItemWeaponRefs.Bite1d6.Cast<BlueprintItemWeaponReference>().Reference; c.UseSecondaryHandInstead = false; })
            .AddLockEquipmentSlot(false, SlotType.MainHand)
            .AddRemoveFeatureOnApply(BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.BiteFeature)))
            .AddBuffActions(deactivated: applyEvolutionBiteBite)
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
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonAgathionSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDaemonSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDemonSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDevilSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDivSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonElementalSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonProteanSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonPsychopompSubtypeFeature")),
                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("GrandEidolonFeature")),
                };
                c.petType = PetTypeExtensions.Eidolon;
            })
            .AddComponent<AbilityCasterHasResource>(c =>
            {
                c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource"));
                c.resourceAmount = 1;
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
