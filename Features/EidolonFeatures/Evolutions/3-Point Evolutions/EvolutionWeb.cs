using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions
{
    internal class EvolutionWeb
    {
        internal static class IClass
        {
            internal static Sprite icon = AbilityRefs.ArmySpiderWebCast.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionWeb";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
            internal const string WebAbility = Evolution + "WebAbility";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AddEvolutionWebAbility();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.WebAbility)) })
                .ConfigureWithLogging(true);
        }
        public static void AddEvolutionWebAbility()
        {
            AbilityConfigurator.New(IClass.WebAbility, GetGUID.GUIDByName(IClass.WebAbility))
                .CopyFrom(AbilityRefs.WebTiefling, c => c is not AbilityResourceLogic)
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
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDaemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonDemonSubtypeFeature")),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonProteanSubtypeFeature")),
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
