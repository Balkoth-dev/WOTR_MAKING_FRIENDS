using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionFlight
    {
        internal static class IClass
        {
            internal static Sprite icon = ActivatableAbilityRefs.AbilityWingsAngel.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionFlight";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
            internal const string FlightBuff = Evolution + "FlightBuff";
            internal const string FlightFeature = Evolution + "FlightFeature";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AddEvolutionFlightBuff();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.FlightFeature)) })
                .ConfigureWithLogging(true);
        }
        public static void AddEvolutionFlightBuff()
        {
            FeatureConfigurator.New(IClass.FlightFeature, GetGUID.GUIDByName(IClass.FlightFeature))
                .CopyFrom(FeatureRefs.Airborne, c => true)
                .ConfigureWithLogging();
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasFactRank>(c =>
                {
                    c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Feature));
                    c.startLevel = 5;
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
