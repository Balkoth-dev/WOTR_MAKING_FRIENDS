using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;
using Kingmaker.UnitLogic;
using Kingmaker.UI.Models.Log;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker;

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
        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            if (caster == null)
            {
                PFLog.Default.Error(this, "Caster is missing", Array.Empty<object>());
                return false;
            }
            if(m_Feature != null)
            {
                if(caster.Progression.Features.HasFact(m_Feature))
                {
                    if(caster.Progression.Features.GetFact(m_Feature).Rank <= featureRank)
                    {
                        return true;
                    }
                }
            }
            return caster.Descriptor.Resources.HasEnoughResource(m_Resource, resourceAmount);
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            Main.Log("Not Enough Resource");
            return "";
        }
    }
}
