using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Brains
{
    class CreateBrains
    {
        internal static readonly BlueprintAiActionReference attackAiAction = BlueprintTool.Get<BlueprintAiAttack>("866ffa6c34000cd4a86fb1671f86c7d8").ToReference<BlueprintAiActionReference>();
        internal static readonly BlueprintAiActionReference vavakia_AiAction_Trample = BlueprintTool.Get<BlueprintAiCastSpell>("03464431e71d4d647ab3f659dcb52633").ToReference<BlueprintAiActionReference>();
        internal static readonly BlueprintAiActionReference followEnemyAiAction = BlueprintTool.Get<BlueprintAiFollow>("959d92846619fc846bef1e5360be9ce9").ToReference<BlueprintAiActionReference>();
        internal static readonly BlueprintAiActionReference cyborg_UnholyBlight_AiAction = BlueprintTool.Get<BlueprintAiCastSpell>("8a6057ac094344feb62c8e65eae40eb8").ToReference<BlueprintAiActionReference>();
        internal static readonly BlueprintAiActionReference fullCasterBoss_AiAction_HorridWilting = BlueprintTool.Get<BlueprintAiCastSpell>("f69c929cd1384ad1aef279d8d5315d84").ToReference<BlueprintAiActionReference>();
        internal static readonly BlueprintAiActionReference gibrilethWavesOfFatigueAIAction = BlueprintTool.Get<BlueprintAiCastSpell>("6d6cfd6430ef4ae9b99273f1bb7fe737").ToReference<BlueprintAiActionReference>();
        public static void CreateAllBrains()
        {
            DraconicAllyBrain();
            StampedeHorseBrain();
            MeladaemonBrain();
        }

        private static void DraconicAllyBrain()
        {
            var brain = BlueprintConfigurator<BlueprintBrain>.New("DraconicAllyBrain", GetGUID.DraconicAllyBrain).Configure();
            brain.m_Actions = new BlueprintAiActionReference[]
            {
                attackAiAction,
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonIGoldAiAction),
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonIBlackAiAction),
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonIBlueAiAction),
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonIBrassAiAction),
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonIGreenAiAction),
                BlueprintTool.GetRef<BlueprintAiActionReference>(GetGUID.FormOfTheDragonISilverAiAction)
            };
        }

        private static void StampedeHorseBrain()
        {
            var brain = BlueprintConfigurator<BlueprintBrain>.New("StampedeHorseBrain", GetGUID.StampedeHorseBrain).Configure();
            brain.m_Actions = new BlueprintAiActionReference[]
            {
                followEnemyAiAction
            };
        }

        private static void MeladaemonBrain()
        {
            var brain = BlueprintConfigurator<BlueprintBrain>.New("MeladaemonBrain", GetGUID.MeladaemonBrain).Configure();
            brain.m_Actions = new BlueprintAiActionReference[]
            {
                attackAiAction,
                cyborg_UnholyBlight_AiAction,
                fullCasterBoss_AiAction_HorridWilting,
                gibrilethWavesOfFatigueAIAction
            };
        }
    }
}
