using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionSpike
    {
        internal static class IClass
        {
            internal static Sprite icon = ItemWeaponRefs.Spike1d4.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionSpike";
            internal static int Ranks = 10;
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
                .AddComponent<AddSecondaryAttacksItemsByRank>(c =>
                {
                    c.m_Weapon = ItemWeaponRefs.Spike1d4.Cast<BlueprintItemWeaponReference>().Reference;
                    c.limbCount = 1;
                    c.m_feature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(IClass.Feature));
                })
                .SetRanks(IClass.Ranks)
                .ConfigureWithLogging(true);

        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasResource>(c =>
                {
                    c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource"));
                    c.resourceAmount = 1;
                })
                .AddComponent<AbilityCasterRankIsHigherThanFeatureAmount>(c =>
                {
                    c.prerequisiteFact = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionTailFeature"));
                    c.compareFact = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(IClass.Feature));
                })
                .ConfigureWithLogging(true);
        }
    }
}
