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

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("1b650f07db8e488d80e9fdca40158fec")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityCasterRankIsHigherThanFeatureAmount : BlueprintComponent, IAbilityCasterRestriction
    {
        public BlueprintFeatureReference[] hasFeatures;
        public BlueprintUnitFactReference greaterThanFact;

        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            if (hasFeatures == null || greaterThanFact == null)
            {
                return false;
            }
            if (!caster.Progression.Features.HasFact(greaterThanFact))
            {
                return false;
            }
            var i = 0;
            foreach (var feature in hasFeatures) {
                if (caster.Progression.Features.HasFact(feature)) { i++; }
            }
            return i < caster.Progression.Features.GetFact(greaterThanFact).GetRank();
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            return string.Empty;
        }
    }
}
