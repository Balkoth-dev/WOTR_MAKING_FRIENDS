using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionTail
    {
        internal static class IClass
        {
            internal static Sprite icon = AssetLoader.LoadInternal("Evolutions", "EvolutionTail.png");
            internal const string Evolution = "EvolutionTail";
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
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Racial, stat: StatType.SkillMobility, value: 2)
                .SetRanks(99)
                .ConfigureWithLogging(true);
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
                    };
                    c.petType = PetTypeExtensions.Eidolon;
                })
                .ConfigureWithLogging(true);
        }
    }
}
