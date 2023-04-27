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
                if(caster.Progression.CharacterLevel >= startLevel)
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
