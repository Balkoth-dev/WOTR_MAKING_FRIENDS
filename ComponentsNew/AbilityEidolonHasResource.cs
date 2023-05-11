using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Parts;
using System;
using System.Linq;
using WOTR_MAKING_FRIENDS.Enums;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("c33ae1bcd5d94b9eb2022c9187af9bf5")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityEidolonHasResource : BlueprintComponent, IAbilityCasterRestriction
    {
        public BlueprintAbilityResourceReference m_Resource;
        public BlueprintFeatureReference m_Feature;
        public int featureRank = 0;
        public int resourceAmount = 1;
        public bool useCostMultiplier = false;
        public int costMultiplierByRank = 0;
        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            int costBonus = 0;
            if (caster == null)
            {
                PFLog.Default.Error(this, "Caster is missing", Array.Empty<object>());
                return false;
            }
            if (caster.IsPet || caster.IsReallyInFactPet)
            {
                return true;
            }
            if (m_Feature != null)
            {
                if (caster.Progression.Features.HasFact(m_Feature))
                {
                    if (!useCostMultiplier && caster.Progression.Features.GetRank(m_Feature) <= featureRank)
                    {
                        return true;
                    }
                    costBonus = caster.Progression.Features.GetRank(m_Feature) * costMultiplierByRank;
                }
            }

            foreach (EntityPartRef<UnitEntityData, UnitPartPet> pet in caster.Pets)
            {
               UnitPartPet entityPart = pet.EntityPart;
               bool flag = entityPart != null && entityPart.Type == PetTypeExtensions.Eidolon;
               if (flag)
               {
                   return pet.Entity.Descriptor.Resources.HasEnoughResource(m_Resource, resourceAmount + costBonus);
               }
            }
            return false;
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            Main.Log("Not Enough Resource");
            return "";
        }
    }
}
