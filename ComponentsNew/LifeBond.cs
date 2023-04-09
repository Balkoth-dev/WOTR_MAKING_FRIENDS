using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.Models.Log;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using System.Collections.Generic;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowMultipleComponents]
    public class LifeBond :
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
            List<UnitEntityData> eidolons = new();
            foreach (EntityPartRef<UnitEntityData, UnitPartPet> pet in Owner.Pets)
            {
                UnitPartPet entityPart = pet.EntityPart;

                bool flag = entityPart != null && entityPart.Type == PetTypeExtensions.Eidolon;
                if (flag)
                {
                    eidolons.Add(pet.Entity);
                }
            }

            foreach (var eidolon in eidolons)
            {
                if (eidolon.Stats.HitPoints - eidolon.Damage - (((Owner.Stats.HitPoints - Owner.Damage) * -1) + 1) < 1)
                {
                    eidolons.Remove(eidolon);
                }
            }
            if (eidolons.Count == 0)
            {
                return;
            }

            int ownerNum = 1;

            if (Owner.HPLeft > ownerNum)
            {
                return;
            }

            Main.Log("Hitpoints: " + (int)Owner.Stats.HitPoints + " Total Damage: " + Owner.Damage + " Damage Calc: " + (Owner.Stats.HitPoints - Owner.Damage));

            int eidolonDamage = ((Owner.Stats.HitPoints - Owner.Damage) * -1) + 1 / eidolons.Count;

            foreach (var eidolon in eidolons)
            {
                GameHelper.DealDirectDamage(evt != null ? evt.Initiator : Owner, eidolon, eidolonDamage);
            }
            Owner.Damage = (int)Owner.Stats.HitPoints - 1;
        }

        public void HandleUnitFailedToDie(UnitEntityData unit)
        {
            int damage = Owner.HPLeft - 1;
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
