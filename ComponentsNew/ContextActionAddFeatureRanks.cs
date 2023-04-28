using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using Kingmaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Serialization;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("936e80d100074b18a4545bfa4bf9f973")]
    public class ContextActionAddFeatureRanks : ContextAction
    {
        [SerializeField]
        [FormerlySerializedAs("PermanentFeature")]
        public BlueprintFeatureReference m_PermanentFeature;

        public int setRank = 0;

        public BlueprintFeature PermanentFeature => m_PermanentFeature?.Get();


        public override string GetCaption()
        {
            return "Add permanent feature.";
        }

        public override void RunAction()
        {
            if (base.Target.Unit == null)
            {
                PFLog.Default.Error(this, "Invalid target for effect '{0}'", GetType().Name);
                return;
            }

            FeatureCollection features = base.Target.Unit.Descriptor.Progression.Features;
            Feature feature = features.AddFeature(PermanentFeature);
            if (setRank != 0)
            {
                int rank = features.GetRank(m_PermanentFeature);
                feature.SetRank(rank + (setRank-1));
                
            }
        }
    }
}
