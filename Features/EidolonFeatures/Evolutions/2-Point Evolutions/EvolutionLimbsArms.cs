using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.FactLogic.LockEquipmentSlot;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionLimbsArms
    {
        internal static class IClass
        {
            internal static Sprite icon = AssetLoader.LoadInternal("Evolutions", "EvolutionLimbsArms.png");
            internal const string Evolution = "EvolutionLimbsArms";
            internal static int Ranks = 10;
            internal const string Feature = Evolution + "Feature";
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
                .RemoveComponents(c => c is IncreaseResourceAmount)
                .AddComponent<AddAdditionalBothHandsAttacks>(c => { c.rankStart = 2; })
                .AddComponent<IncreaseResourceAmountRank>(c => { c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")); c.Rank = 2; c.Value = -2; })
                .SetRanks(IClass.Ranks)
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.MainHand; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.OffHand; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon1; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon2; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon3; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon4; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon5; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon6; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon7; })
                .AddComponent<UnlockEquipmentSlot>(c => { c.m_SlotType = (UnlockEquipmentSlot.SlotType)SlotType.Weapon8; })
                .ConfigureWithLogging(true);

        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasResource>(c =>
                {
                    c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource"));
                    c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(IClass.Feature);
                    c.featureRank = 1;
                    c.resourceAmount = 2;
                })
                .ConfigureWithLogging(true);
        }
    }
}
