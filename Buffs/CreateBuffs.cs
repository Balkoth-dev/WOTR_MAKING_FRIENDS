using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    class CreateBuffs
    {
        public static void CreateAllBuffs()
        {
            CreateDummyBuff();
            SummonStampedeBuffs.CreateStampedeTrampleDamageImmunityBuff();
            SummonStampedeBuffs.CreateStampedeAttackBuff();
            ReleaseTheHoundsBuffs.CreateReleaseTheHoundsBuff();
            BlackTentaclesBuffs.CreateBlackTentaclesBuff();
        }

        private static void CreateDummyBuff()
        {
            BuffConfigurator.New("dummyBuff", GetGUID.DummyBuff).Configure();
        }
    }
}
