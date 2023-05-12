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
using Kingmaker.EntitySystem;
using Kingmaker.UnitLogic.Parts;
using WOTR_MAKING_FRIENDS.Enums;
using Kingmaker.Enums;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{

    [TypeId("8aeaeb9fbd9d431b972ac56354f34c46")]
    [AllowedOn(typeof(BlueprintAbility), false)]
    [AllowMultipleComponents]
    public class AbilityOwnerOrPetHasFacts : BlueprintComponent, IAbilityCasterRestriction
    {
        [SerializeField]
        [FormerlySerializedAs("Facts")]
        public BlueprintUnitFactReference[] m_Facts;
        public PetType? petType;

        public bool NeedsAll;

        public List<BlueprintUnitFact> m_FactsMissingCache;

        public ReferenceArrayProxy<BlueprintUnitFact, BlueprintUnitFactReference> Facts => m_Facts;

        public bool CheckPetFacts(UnitEntityData caster)
        {
            foreach (EntityPartRef<UnitEntityData, UnitPartPet> pet in caster.Pets)
            {
                UnitPartPet entityPart = pet.EntityPart;
                bool flag = entityPart != null && entityPart.Type == petType;
                if (flag)
                {
                    m_FactsMissingCache?.Clear();
                    foreach (BlueprintUnitFact fact in Facts)
                    {
                        if (pet.Entity.Descriptor.HasFact(fact))
                        {
                            if (!NeedsAll)
                            {
                                return true;
                            }

                            continue;
                        }

                        if (m_FactsMissingCache == null)
                        {
                            m_FactsMissingCache = new List<BlueprintUnitFact>();
                        }

                        m_FactsMissingCache.Add(fact);
                    }

                    if (m_FactsMissingCache != null)
                    {
                        return m_FactsMissingCache.Count == 0;
                    }

                    return true;

                }
            }
            return false;
        }

        public bool IsCasterRestrictionPassed(UnitEntityData caster)
        {
            if(petType != null && CheckPetFacts(caster))
            { return true; }

            m_FactsMissingCache?.Clear();
            foreach (BlueprintUnitFact fact in Facts)
            {
                if (caster.Descriptor.HasFact(fact))
                {
                    if (!NeedsAll)
                    {
                        return true;
                    }

                    continue;
                }

                if (m_FactsMissingCache == null)
                {
                    m_FactsMissingCache = new List<BlueprintUnitFact>();
                }

                m_FactsMissingCache.Add(fact);
            }

            if (m_FactsMissingCache != null)
            {
                return m_FactsMissingCache.Count == 0;
            }

            return true;
        }

        public string GetAbilityCasterRestrictionUIText()
        {
            if (m_FactsMissingCache == null || m_FactsMissingCache.Count == 0)
            {
                return LocalizedTexts.Instance.Reasons.NoRequiredCondition.ToString();
            }

            string conditions = string.Join(", ", m_FactsMissingCache.Select((BlueprintUnitFact _fact) => _fact.Name));
            return LocalizedTexts.Instance.Reasons.NoRequiredCondition.ToString(delegate
            {
                GameLogContext.Text = conditions;
            });
        }
    }
}
