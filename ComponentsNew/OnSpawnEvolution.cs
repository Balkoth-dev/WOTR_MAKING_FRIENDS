using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using UnityEngine;
using UnityEngine.Serialization;
using WOTR_MAKING_FRIENDS.Enums;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("b207cc0c03c84df8966a32ee85397d13")]
    [AllowMultipleComponents]
    [ComponentName("Buff on spawned unit")]
    public class OnSpawnEvolution : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSummonUnit>, IRulebookHandler<RuleSummonUnit>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleSummonUnit evt)
        {
        }

        public void OnEventDidTrigger(RuleSummonUnit evt)
        {
            foreach (var pet in base.Owner.Pets)
            {
                if (pet.EntityPart.Type == PetTypeExtensions.Eidolon)
                {
                    foreach (var feature in pet.Entity.Progression.Features)
                    {
                        if ((feature.Blueprint.HasGroup(FeatureGroupExtension.EvolutionTransmogrifiable) || feature.Blueprint.HasGroup(FeatureGroupExtension.EvolutionBase)) && !feature.Blueprint.HasGroup(FeatureGroupExtension.EvolutionSizeChangeGroup))
                        {
                            for(var i = 0; i <= feature.GetRank()-1;i++)
                            {
                                evt.SummonedUnit.Progression.Features.AddFeature(feature.Blueprint);
                            }
                        }
                    }
                }
            }
        }
    }
}