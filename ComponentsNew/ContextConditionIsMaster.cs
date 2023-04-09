using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.UnitLogic.Mechanics.Conditions
{
    public class ContextConditionIsMaster : ContextCondition
    {
        public override string GetConditionCaption() => "Is Master";

        public override bool CheckCondition()
        {
            UnitEntityData maybeCaster = this.Context.MaybeCaster;
            if (maybeCaster == (UnitDescriptor)null)
            {
                return false;
            }
            UnitEntityData unit = this.Target.Unit;
            if (!(unit == (UnitDescriptor)null))
            {
                if (unit == maybeCaster.Master)
                    return true;
            }
            return false;
        }
    }
}
