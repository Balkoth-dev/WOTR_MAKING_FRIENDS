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
        public BlueprintFeatureReference prerequisiteFact;
        public BlueprintFeatureReference compareFact;

        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            if (caster.Progression.Features.HasFact(prerequisiteFact))
            {
                if(caster.Progression.Features.HasFact(compareFact))
                    return caster.Progression.Features.GetFact(prerequisiteFact).GetRank() > caster.Progression.Features.GetFact(compareFact).GetRank();
                return true;
            }
            return false;
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            return string.Empty;
        }
    }
}
