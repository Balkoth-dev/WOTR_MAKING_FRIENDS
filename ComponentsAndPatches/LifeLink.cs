using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.Models.Log;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
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
        public int HealthPercent = 1;

        public override void OnTurnOn()
        {
            if(!this.Owner.IsPet && !this.Owner.IsReallyInFactPet)
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

        public void OnEventDidTrigger(RuleDealDamage evt) => this.TryReduceDamage();

        private void TryReduceDamage()
        {
            int num = Math.Min(1, (int)((double)(this.Owner.MaxHP * this.HealthPercent) * 0.00999999977648258));
            if (this.Owner.HPLeft > num)
                return;
            GameHelper.DealDirectDamage(this.Owner, this.Owner.Master, this.Owner.Damage-((int)(ModifiableValue)this.Owner.Stats.HitPoints - num));
            this.Owner.Damage = (int)(ModifiableValue)this.Owner.Stats.HitPoints - num;
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
