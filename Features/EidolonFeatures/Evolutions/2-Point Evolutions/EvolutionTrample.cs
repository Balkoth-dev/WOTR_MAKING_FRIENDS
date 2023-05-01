using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionTrample
    {
        internal static class IClass
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
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.TrampleAbility)) })
                .ConfigureWithLogging(true);
        }
        public static void AddEvolutionTrampleAbility()
        {
            AbilityConfigurator.New(IClass.TrampleAbility, GetGUID.GUIDByName(IClass.TrampleAbility))
                .CopyFrom(AbilityRefs.TrampleAbility, c => true)
                .ConfigureWithLogging();
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonBipedBaseFormFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonQuadrupedBaseFormFeature")),
                    };
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
