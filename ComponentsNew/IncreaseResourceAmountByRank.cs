﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using UnityEngine;
using UnityEngine.Serialization;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowMultipleComponents]
    [TypeId("c9e8881126c5418fb5d445a013960ee3")]
    public class IncreaseResourceAmountRank : UnitFactComponentDelegate, IResourceAmountBonusHandler, IUnitSubscriber, ISubscriber
    {
        [SerializeField]
        [FormerlySerializedAs("Resource")]
        public BlueprintAbilityResourceReference m_Resource;

        public int Value = 1;
        public int Rank = 1;

        public BlueprintAbilityResource Resource => m_Resource?.Get();

        public void CalculateMaxResourceAmount(BlueprintAbilityResource resource, ref int bonus)
        {
            if (base.Fact.GetRank() >= Rank)
            {
                if (base.Fact.Active && resource == Resource)
                {
                    bonus += Value * base.Fact.GetRank();
                }
            }
        }
    }
}
