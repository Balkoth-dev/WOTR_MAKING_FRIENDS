using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;

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

            if (this.Target.Unit == null)
                return;
            else if (this.Context.MaybeCaster == null)
                return;

            var ruleCombatManeuver = new RuleCombatManeuver(this.Context.MaybeCaster, this.Target.Unit, this.Type);

            ruleCombatManeuver.AdditionalBonus = Bonus;

            try
            {
                ruleCombatManeuver.ReplaceAttackBonus = this.Context.Params.CasterLevel;
            }
            catch (Exception e)
            {
                Main.Log(e: e);
            }

            if (this.Context.TriggerRule(ruleCombatManeuver).Success)
            {
                this.Success.Run();
            }
            else
                this.Failure.Run();
        }
    }
}
