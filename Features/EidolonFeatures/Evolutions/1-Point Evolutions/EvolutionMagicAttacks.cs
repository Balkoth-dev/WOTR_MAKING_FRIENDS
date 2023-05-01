using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionMagicAttacks
    {
        private static class InternalClass
        {
            internal static Sprite icon = AbilityRefs.MagicWeapon.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionMagicAttacks";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalClass.Feature))
                .SetIcon(InternalClass.icon)
                .AddOutgoingPhysicalDamageProperty(addMagic:true,naturalAttacks:true)
                .ConfigureWithLogging(true);
        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalClass.Ability))
                .SetIcon(InternalClass.icon)
                .AddComponent<AbilityCasterHasNoFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.Feature)),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.BaseFeature))
                    };
                })
                .ConfigureWithLogging(true);
        }
    }
}
