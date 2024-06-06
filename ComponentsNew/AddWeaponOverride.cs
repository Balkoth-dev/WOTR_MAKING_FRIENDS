using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.Items.Slots;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Owlcat.QA.Validation;
using UnityEngine.Serialization;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
  public class AddWeaponOverride :
    UnitBuffComponentDelegate<AddKineticistBladeData>,
    IAreaActivationHandler,
    IGlobalSubscriber,
    ISubscriber
    {
        public BlueprintItemWeaponReference m_Blade;
        [SerializeField]
        public bool UseSecondaryHandInstead;

        public BlueprintItemWeapon Blade => this.m_Blade?.Get();

        public override void OnActivate()
        {
            base.OnActivate();
            this.Owner.MarkNotOptimizableInSave();
            this.Data.Applied = this.Blade.CreateEntity<ItemEntityWeapon>();
            this.Data.Applied.MakeNotLootable();
            HandSlot handSlot = this.UseSecondaryHandInstead ? this.Owner.Body.SecondaryHand : this.Owner.Body.PrimaryHand;

            while (!handSlot.CanInsertItem((ItemEntity)this.Data.Applied))
            {
                handSlot.Lock.Release();
                handSlot.RemoveItem();
            }

            using (ContextData<ItemsCollection.SuppressEvents>.Request())
            handSlot.InsertItem((ItemEntity)this.Data.Applied);
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            if (this.Data.Applied == null)
                return;
            this.Data.Applied.HoldingSlot?.RemoveItem();
            using (ContextData<ItemsCollection.SuppressEvents>.Request())
                this.Data.Applied.Collection?.Remove((ItemEntity)this.Data.Applied);
            this.Data.Applied = (ItemEntityWeapon)null;
        }

        public override void OnTurnOn() => this.Data.Applied?.HoldingSlot?.Lock.Retain();

        public override void OnTurnOff() => this.Data.Applied?.HoldingSlot?.Lock.Release();

        public void OnAreaActivated()
        {
            if (this.Data.Applied != null)
                return;
            this.OnActivate();
            this.OnTurnOn();
        }
    }
}
