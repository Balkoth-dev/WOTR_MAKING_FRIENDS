using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("e566e0a0546b4780a30ca83383468394")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityCasterHasFactRank : BlueprintComponent, IAbilityCasterRestriction
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
            int nextRankLevel = 1 + currentRank * numLevelsBetweenRanks;

            return currentLevel >= nextRankLevel;
        }
        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            if (m_UnitFact == null)
            {
                return true;
            }
            if (!caster.Progression.Features.HasFact(m_UnitFact))
            {
                if (caster.Progression.CharacterLevel >= startLevel)
                    return true;
                else return false;
            }

            return CanTakeRank(caster.Progression.CharacterLevel, caster.Progression.Features.GetFact(m_UnitFact).GetRank());
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            return string.Empty;
        }
    }
}
