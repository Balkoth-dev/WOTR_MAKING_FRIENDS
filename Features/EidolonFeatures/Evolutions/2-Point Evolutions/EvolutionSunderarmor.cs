using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.BlueprintAbilityResource;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionSunderarmor
    {
        private static class InternalClass
        {
            internal static Sprite icon = AbilityRefs.SunderAction.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionSunderarmor";
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
                .AddManeuverOnAttack(category:WeaponCategory.OtherNaturalWeapons,maneuver:CombatManeuver.SunderArmor)
                .ConfigureWithLogging(true);
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalClass.Ability))
                .SetIcon(InternalClass.icon)
                .AddComponent<AbilityCasterHasFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDaemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDevilSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDivSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonElementalSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonProteanSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonPsychopompSubtypeFeature")),
                    };
                })
                .AddComponent<AbilityCasterHasFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionPincersFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionPincersLimbsFeature")),
                    };
                })
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
