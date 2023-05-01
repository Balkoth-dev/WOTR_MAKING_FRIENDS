using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
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
    internal class EvolutionTrample
    {
        private static class InternalClass
        {
            internal static Sprite icon = AbilityRefs.TrampleAbility.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionTrample";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";            
            internal const string TrampleAbility = Evolution + "TrampleAbility";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AddEvolutionTrampleAbility();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalClass.Feature))
                .SetIcon(InternalClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.TrampleAbility)) })
                .ConfigureWithLogging(true);
        }
        public static void AddEvolutionTrampleAbility()
        {
            AbilityConfigurator.New(InternalClass.TrampleAbility, GetGUID.GUIDByName(InternalClass.TrampleAbility))
                .CopyFrom(AbilityRefs.TrampleAbility, c => true)
                .ConfigureWithLogging();
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalClass.Ability))
                .SetIcon(InternalClass.icon)
                .AddComponent<AbilityCasterHasFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonBipedBaseFormFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonQuadrupedBaseFormFeature")),
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
