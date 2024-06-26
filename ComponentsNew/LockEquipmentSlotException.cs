﻿using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Items.Slots;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("537c8f834c094964db16dd2ba24fdb69")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowMultipleComponents]
    public class LockEquipmentSlotFactException : UnitFactComponentDelegate<LockEquipmentSlotData>
    {
        //Acts as LockEquipmentSlot but adds an exception if the unit has a certain fact
        public List<BlueprintUnitFactReference> m_Fact;
        public enum SlotType
        {
            Armor,
            MainHand,
            OffHand,
            Cloak,
            Bracers,
            Boots,
            Gloves,
            Ring1,
            Ring2,
            Necklace,
            Belt,
            Headgear,
            Weapon1,
            Weapon2,
            Weapon3,
            Weapon4,
            Weapon5,
            Weapon6,
            Weapon7,
            Weapon8,
            Glasses,
            Shirt
        }

        [SerializeField]
        [UsedImplicitly]
        public SlotType m_SlotType;

        [SerializeField]
        [UsedImplicitly]
        public bool m_Deactivate;

        public override void OnTurnOn()
        {
            foreach (var f in m_Fact)
            {
                if (base.Owner.Progression.Features.HasFact(f))
                {
                    return;
                }
            }
            base.Data.Slot = GetSlot();
            if (base.Data.Slot != null)
            {
                base.Data.Slot.Lock.Retain();
                if (m_Deactivate)
                {
                    base.Data.Slot.RetainDeactivateFlag();
                }
            }
        }

        public override void OnTurnOff()
        {
            if (base.Data.Slot != null)
            {
                base.Data.Slot.Lock.Release();
                if (m_Deactivate)
                {
                    base.Data.Slot.ReleaseDeactivateFlag();
                }

                base.Data.Slot = null;
            }
        }

        public ItemSlot GetSlot()
        {
            switch (m_SlotType)
            {
                case SlotType.Armor:
                    return base.Owner.Body.Armor;
                case SlotType.Shirt:
                    return base.Owner.Body.Shirt;
                case SlotType.MainHand:
                    return base.Owner.Body.PrimaryHand;
                case SlotType.OffHand:
                    return base.Owner.Body.SecondaryHand;
                case SlotType.Cloak:
                    return base.Owner.Body.Shoulders;
                case SlotType.Bracers:
                    return base.Owner.Body.Wrist;
                case SlotType.Boots:
                    return base.Owner.Body.Feet;
                case SlotType.Gloves:
                    return base.Owner.Body.Gloves;
                case SlotType.Ring1:
                    return base.Owner.Body.Ring1;
                case SlotType.Ring2:
                    return base.Owner.Body.Ring2;
                case SlotType.Necklace:
                    return base.Owner.Body.Neck;
                case SlotType.Belt:
                    return base.Owner.Body.Belt;
                case SlotType.Headgear:
                    return base.Owner.Body.Head;
                case SlotType.Glasses:
                    return base.Owner.Body.Glasses;
                case SlotType.Weapon1:
                    return base.Owner.Body.HandsEquipmentSets[0].PrimaryHand;
                case SlotType.Weapon2:
                    return base.Owner.Body.HandsEquipmentSets[0].SecondaryHand;
                case SlotType.Weapon3:
                    return base.Owner.Body.HandsEquipmentSets[1].PrimaryHand;
                case SlotType.Weapon4:
                    return base.Owner.Body.HandsEquipmentSets[1].SecondaryHand;
                case SlotType.Weapon5:
                    return base.Owner.Body.HandsEquipmentSets[2].PrimaryHand;
                case SlotType.Weapon6:
                    return base.Owner.Body.HandsEquipmentSets[2].SecondaryHand;
                case SlotType.Weapon7:
                    return base.Owner.Body.HandsEquipmentSets[3].PrimaryHand;
                case SlotType.Weapon8:
                    return base.Owner.Body.HandsEquipmentSets[3].SecondaryHand;
                default:
                    return null;
            }
        }
    }
}