using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("f18368ca428447bd86eaffa2f0f4348e")]
    public class ContextActionAddRemoveFeature : ContextAction
    {
        public BlueprintFeatureReference[] m_Features;

        public BlueprintFeatureReference m_Default_Feature;

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

            for (var i = 1; i < m_Features.Length; i++)
            {
                Main.Log(m_Features[i].Get().Name);
                Main.Log(m_Features[i - 1].Get().Name);
                if (features.HasFact(m_Features[i - 1].Get()))
                {
                    features.RemoveFact(m_Features[i - 1].Get());
                    features.AddFeature(m_Features[i].Get());
                    return;
                }
            }
            features.AddFeature(m_Default_Feature.Get());

        }
    }
}
