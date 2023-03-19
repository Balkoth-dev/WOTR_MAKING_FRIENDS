using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Brains
{
    class CreateBrains
    {
        public static readonly BlueprintAiActionReference attackAiAction = BlueprintTool.Get<BlueprintAiAttack>("866ffa6c34000cd4a86fb1671f86c7d8").ToReference<BlueprintAiActionReference>();
        public static void CreateAllBrains()
        {
            DraconicAllyBrain();
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
    }
}
