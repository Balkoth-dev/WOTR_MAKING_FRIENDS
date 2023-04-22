using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.AiActions
{
    internal class CreateAiActions
    {
        internal static readonly BlueprintAiCastSpell redDragonWoundWorm_BreathAIAction = BlueprintTool.Get<BlueprintAiCastSpell>("c7ea84c0eda8155499bb5005103504cf");
        public static readonly BlueprintAiCastSpell chargeAiAction = BlueprintTool.Get<BlueprintAiCastSpell>("05003725a881c10419530387b6de5c9a");

        public static void CreateAllAiActions()
        {
            FormOfTheDragonIGoldAiAction();
            FormOfTheDragonISilverAiAction();
            FormOfTheDragonIBlackAiAction();
            FormOfTheDragonIBlueAiAction();
            FormOfTheDragonIBrassAiAction();
            FormOfTheDragonIGreenAiAction();
        }

        public static void FormOfTheDragonIGoldAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIGoldAiAction", GetGUID.GUIDByName("FormOfTheDragonIGoldAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonISilverAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonISilverAiAction", GetGUID.GUIDByName("FormOfTheDragonISilverAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBlackAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBlackAiAction", GetGUID.GUIDByName("FormOfTheDragonIBlackAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBlueAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBlueAiAction", GetGUID.GUIDByName("FormOfTheDragonIBlueAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBlueBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBrassAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBrassAiAction", GetGUID.GUIDByName("FormOfTheDragonIBrassAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBrassBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIGreenAiAction()
        {
            BlueprintAiCastSpell aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIGreenAiAction", GetGUID.GUIDByName("FormOfTheDragonIGreenAiAction")).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIGreenBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
    }
}
