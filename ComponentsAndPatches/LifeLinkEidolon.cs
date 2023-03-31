using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
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
            if (!this.Owner.IsPet && !this.Owner.IsReallyInFactPet)
            {
                return;
            }
            base.OnTurnOn();
            this.Owner.State.Features.Infallible.Retain();
            this.Owner.Stats.HitPoints.AddDependentComponent((EntityFactComponent)this.Runtime);
            this.TryReduceDamage();
        }

        public override void OnTurnOff()
        {
            base.OnTurnOff();
            this.Owner.State.Features.Infallible.Release();
            this.Owner.Stats.HitPoints.RemoveDependentComponent((EntityFactComponent)this.Runtime);
        }

        public void OnEventAboutToTrigger(RuleDealDamage evt)
        {
        }

        public void OnEventDidTrigger(RuleDealDamage evt) => this.TryReduceDamage(evt);

        private void TryReduceDamage(RuleDealDamage evt = null)
        {
            int ownerNum = Math.Min(1, (int)((double)(this.Owner.MaxHP * this.HealthPercent) * 0.00999999977648258));
            Main.Log(this.Owner.HPLeft + " : " + ownerNum);
            if (this.Owner.HPLeft > ownerNum)
                return;
            GameHelper.DealDirectDamage(evt != null ? evt.Initiator : this.Owner, this.Owner.Master, this.Owner.Damage - ((int)(ModifiableValue)this.Owner.Stats.HitPoints - ownerNum));
            this.Owner.Damage = (int)(ModifiableValue)this.Owner.Stats.HitPoints - ownerNum;
        }

        public void HandleUnitFailedToDie(UnitEntityData unit)
        {
            int damage = this.Owner.HPLeft - Math.Min(1, (int)((double)(this.Owner.MaxHP * this.HealthPercent) * 0.00999999977648258));
            if (damage <= 0)
                return;
            using (ContextData<GameLogDisabled>.Request())
                GameHelper.DealDirectDamage(unit, unit, damage);
        }

        public void HandleUnitHealthChanged(UnitEntityData unit, int previousTotalHP)
        {
            if (this.Owner != (UnitDescriptor)unit)
                return;
            this.TryReduceDamage();
        }
    }
}
