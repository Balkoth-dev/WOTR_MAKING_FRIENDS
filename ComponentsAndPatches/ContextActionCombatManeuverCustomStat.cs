using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UI.MVVM._PCView.Rest;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentAndPatches
{
        public class BlackTentaclesGrappleAction : ContextAction
        {
            public CombatManeuver Type = CombatManeuver.Grapple;
            public ContextValue Value;
            public ActionList Success;
            public ActionList Failure;
            public int Bonus;
        

            public override string GetCaption() => "Combat maneuver: " + this.Type.ToString();
        
            public override void RunAction()
            {

            if (this.Target.Unit == (UnitDescriptor)null)
                return;
            else if (this.Context.MaybeCaster == (UnitDescriptor)null)
                return;

            Main.Log("1");
            var ruleCombatManeuver = new RuleCombatManeuver(this.Context.MaybeCaster, this.Target.Unit, this.Type);

            Main.Log("2");
            ruleCombatManeuver.AdditionalBonus = Bonus;

            try
            {
                ruleCombatManeuver.ReplaceAttackBonus = this.Context.Params.CasterLevel;
            }
            catch(Exception e)
            {
                Main.Log(e: e);
            }

            Main.Log("4");
            if (this.Context.TriggerRule<RuleCombatManeuver>(ruleCombatManeuver).Success)
            {
                this.Success.Run();
            }
            else
                this.Failure.Run();
            }
        }
}
