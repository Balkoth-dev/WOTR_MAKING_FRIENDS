using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;

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
            foreach (var feature in hasFeatures)
            {
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
