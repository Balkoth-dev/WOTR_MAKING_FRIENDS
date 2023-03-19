using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.AiActions
{
    class CreateAiActions
    {
        internal static readonly BlueprintAiCastSpell redDragonWoundWorm_BreathAIAction = BlueprintTool.Get<BlueprintAiCastSpell>("c7ea84c0eda8155499bb5005103504cf");
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
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIGoldAiAction", GetGUID.FormOfTheDragonIGoldAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonISilverAiAction()
        {
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonISilverAiAction", GetGUID.FormOfTheDragonISilverAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBlackAiAction()
        {
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBlackAiAction", GetGUID.FormOfTheDragonIBlackAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBlueAiAction()
        {
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBlueAiAction", GetGUID.FormOfTheDragonIBlueAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBlueBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIBrassAiAction()
        {
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIBrassAiAction", GetGUID.FormOfTheDragonIBrassAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIBrassBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
        public static void FormOfTheDragonIGreenAiAction()
        {
            var aiAction = BlueprintConfigurator<BlueprintAiCastSpell>.New("FormOfTheDragonIGreenAiAction", GetGUID.FormOfTheDragonIGreenAiAction).CopyFrom(redDragonWoundWorm_BreathAIAction).Configure();
            aiAction.m_Ability = AbilityRefs.FormOfTheDragonIGreenBreathWeaponAbility.Cast<BlueprintAbilityReference>().Reference;
        }
    }
}
