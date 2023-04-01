using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    public class BlackTentaclesGrappleAction : ContextAction
    {
        public CombatManeuver Type = CombatManeuver.Grapple;
        public ContextValue Value;
        public ActionList Success;
        public ActionList Failure;
        public int Bonus;


        public override string GetCaption() => "Combat maneuver: " + Type.ToString();

        public override void RunAction()
        {

            if (Target.Unit == null)
            {
                return;
            }
            else if (Context.MaybeCaster == null)
            {
                return;
            }

            RuleCombatManeuver ruleCombatManeuver = new RuleCombatManeuver(Context.MaybeCaster, Target.Unit, Type);

            ruleCombatManeuver.AdditionalBonus = Bonus;

            try
            {
                ruleCombatManeuver.ReplaceAttackBonus = Context.Params.CasterLevel;
            }
            catch (Exception e)
            {
                Main.Log(e: e);
            }

            if (Context.TriggerRule(ruleCombatManeuver).Success)
            {
                Success.Run();
            }
            else
            {
                Failure.Run();
            }
        }
    }
}
