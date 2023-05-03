using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Owlcat.QA.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("e1a2e76c422b402b891ecc6c587a72bd")]
    public class AddFactsOnArray : ContextAction
    {
        public BlueprintFeatureReference[] originalBlueprints;
        public BlueprintFeatureReference[] newBlueprints;

        public override string GetCaption()
        {
            return "";
        }

        public override void RunAction()
        {
            if(originalBlueprints.Length != newBlueprints.Length)
            {
                return;
            }

            FeatureCollection features = base.Target.Unit.Descriptor.Progression.Features;
            for (var i = 0;  i < originalBlueprints.Length; i++)
            {
                Main.Log(originalBlueprints[i].Get().name + " : " + base.Target.Unit.Progression.Features.HasFact(originalBlueprints[i]));
                if (base.Target.Unit.Progression.Features.HasFact(originalBlueprints[i]))
                {
                    Main.Log("Has Fact");
                    features.AddFeature(newBlueprints[i]);
                }
            }
        }
    }
}
