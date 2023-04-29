using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("b70b2cb73f3f47e58aa0b376366331e9")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [ComponentName("BuffMechanics/Extra Attack")]
    public class AddAdditionalBothHandsAttacksOrAddAdditionalLimbs : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public BlueprintItemWeaponReference blueprintItemWeaponReference;
        public int additionalLimbs = 1;
        public int rankStart = 1;
        public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt)
        {

            if (blueprintItemWeaponReference == null)
            {
                if (evt.Initiator.Body.PrimaryHand.HasWeapon && !evt.Initiator.Body.PrimaryHand.Weapon.Blueprint.IsNatural)
                {
                    for (var i = rankStart; i <= base.Fact.GetRank(); i++)
                    {
                        evt.Result.PrimaryHand.PenalizedAttacks++;
                    }
                }
                if (evt.Initiator.Body.SecondaryHand.HasWeapon && !evt.Initiator.Body.SecondaryHand.Weapon.Blueprint.IsNatural)
                {
                    for (var i = rankStart; i <= base.Fact.GetRank(); i++)
                    {
                        evt.Result.SecondaryHand.PenalizedAttacks++;
                    }
                }
            }
            else
            {
                for (var i = rankStart; i <= base.Fact.GetRank(); i++)
                {
                    for (var r = 1; r <= additionalLimbs; r++)
                    {
                        evt.Initiator.Body.AddAdditionalLimbItem(blueprintItemWeaponReference, true);
                    }
                }
            }
            //evt.Initiator.Body.FixAdditionalLimbs();
        }

        public void OnEventDidTrigger(RuleCalculateAttacksCount evt)
        {
        }
    }
}
