using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [TypeId("1a14ef5954ca40a49c5aa2ba2e965407")]
    public class ContextConditionCasterHasResource : ContextCondition
    {

        public override bool CheckCondition()
        {
            if (base.Context.MaybeCaster == null)
            {
                PFLog.Default.Error(this, "Caster is missing", Array.Empty<object>());
                return false;
            }
            return base.Context.MaybeCaster.Descriptor.Resources.HasEnoughResource(m_Resource, Amount);
        }

        public override string GetConditionCaption()
        {
            return "";
        }
        public BlueprintAbilityResourceReference m_Resource;
        public int Amount = 1;
    }
}
