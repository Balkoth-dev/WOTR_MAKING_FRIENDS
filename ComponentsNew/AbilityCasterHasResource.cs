using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using System;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("e187fa66def2416b99df66d7eba5a32c")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityCasterHasResource : BlueprintComponent, IAbilityCasterRestriction
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

            return caster.Descriptor.Resources.HasEnoughResource(m_Resource, resourceAmount + costBonus);
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            Main.Log("Not Enough Resource");
            return "";
        }
    }
}
