using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("79f47bdc467d47e8b33b2b5e8d000541")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityTargetHasFactRank : BlueprintComponent, IAbilityTargetRestriction
    {
        public BlueprintUnitFactReference m_UnitFact;

        public int numLevelsBetweenRanks = 0;

        public int maxRank = 0;

        public int startLevel = 0;

        bool CanTakeRank(int currentLevel, int currentRank)
        {
            if (currentRank >= maxRank)
            {
                return false;
            }
            int nextRankLevel = (1 + currentRank * numLevelsBetweenRanks)+ startLevel;

            return currentLevel >= nextRankLevel;
        }
        public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper target)
        {
            if (m_UnitFact == null)
            {
                return true;
            }
            if (!target.Unit.Progression.Features.HasFact(m_UnitFact))
            {
                if (target.Unit.Progression.CharacterLevel >= startLevel)
                {
                    return true;
                }
                else return false;
            }

            return CanTakeRank(target.Unit.Progression.CharacterLevel, target.Unit.Progression.Features.GetFact(m_UnitFact).GetRank());
        }
        public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target)
        {
            return string.Empty;
        }
    }
}
