using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Owlcat.QA.Validation;
using System.Collections.Generic;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("63bedbf5fa6040788ccb3a8ca7dd7e11")]
    public class RemoveFactWithGroup : ContextAction
    {
        [ValidateNotNull]
        [SerializeReference]
        public UnitEvaluator Unit;

        public FeatureGroup featureGroup;

        public bool affectCaster = false;

        public override string GetCaption()
        {
            return $"Remove Fact ({featureGroup} from {Unit})";
        }

        public override void RunAction()
        {
            var features = new List<Feature>();

            foreach (var feature in base.Target.Unit.Progression.Features)
            {
                if (feature.Blueprint.HasGroup(featureGroup))
                {
                    features.Add(feature);
                }
            }

            foreach (var fact in features)
            {
                Main.Log($"Fact: {fact.Blueprint.name}");
                if (fact.Blueprint.HasGroup(featureGroup))
                {
                    while (Target.Unit.Progression.Features.HasFact(fact))
                    {
                        base.Target.Unit.Progression.Features.RemoveFact(fact);
                    }
                }
            }

            if (affectCaster)
            {
                var casterFeatures = new List<Feature>();
                foreach (var feature in base.AbilityContext.Caster.Progression.Features)
                {
                    if (feature.Blueprint.HasGroup(featureGroup))
                    {
                        casterFeatures.Add(feature);
                    }
                }

                foreach (var fact in features)
                {
                    Main.Log($"Fact: {fact.Blueprint.name}");
                    if (fact.Blueprint.HasGroup(featureGroup))
                    {
                        while (base.AbilityContext.Caster.Progression.Features.HasFact(fact))
                        {
                            base.AbilityContext.Caster.Progression.Features.RemoveFact(fact);
                        }
                    }
                }
            }
        }
    }
}
