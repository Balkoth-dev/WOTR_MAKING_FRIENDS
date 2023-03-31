using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.Models.Log;
using Kingmaker.UnitLogic;
using System;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsAndPatches
{
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowMultipleComponents]
    public class LifeLinkEidolon :
      UnitFactComponentDelegate,
      ITargetRulebookHandler<RuleDealDamage>,
      IRulebookHandler<RuleDealDamage>,
      ISubscriber,
      ITargetRulebookSubscriber,
      IFailedToDieHandler,
      IUnitSubscriber,
      IUnitHealthChangedHandler,
      IGlobalSubscriber
    {
        [Tooltip("0 means 1 HP")]
        public int HealthPercent = 0;

        public override void OnTurnOn()
        {
            if (!Owner.IsPet && !Owner.IsReallyInFactPet)
            {
                return;
            }
            base.OnTurnOn();
            Owner.State.Features.Infallible.Retain();
            Owner.Stats.HitPoints.AddDependentComponent(Runtime);
            TryReduceDamage();
        }

        public override void OnTurnOff()
        {
            base.OnTurnOff();
            Owner.State.Features.Infallible.Release();
            Owner.Stats.HitPoints.RemoveDependentComponent(Runtime);
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {
        }

        public void OnEventDidTrigger(RuleDealDamage evt) => TryReduceDamage(evt);

        private void TryReduceDamage(RuleDealDamage evt = null)
        {
            int ownerNum = Math.Min(1, (int)(Owner.MaxHP * HealthPercent * 0.00999999977648258));
            Main.Log(Owner.HPLeft + " : " + ownerNum);
            if (Owner.HPLeft > ownerNum)
            {
                return;
            }

            GameHelper.DealDirectDamage(evt != null ? evt.Initiator : Owner, Owner.Master, Owner.Damage - (Owner.Stats.HitPoints - ownerNum));
            Owner.Damage = Owner.Stats.HitPoints - ownerNum;
        }

        public void HandleUnitFailedToDie(UnitEntityData unit)
        {
            int damage = Owner.HPLeft - Math.Min(1, (int)(Owner.MaxHP * HealthPercent * 0.00999999977648258));
            if (damage <= 0)
            {
                return;
            }

            using (ContextData<GameLogDisabled>.Request())
            {
                GameHelper.DealDirectDamage(unit, unit, damage);
            }
        }

        public void HandleUnitHealthChanged(UnitEntityData unit, int previousTotalHP)
        {
            if (Owner != unit)
            {
                return;
            }

            TryReduceDamage();
        }
    }
}
