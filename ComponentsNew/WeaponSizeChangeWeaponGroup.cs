using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Blueprints.Items.Weapons;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{

    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("90a4c1ac8a96d3f4482fb894883d7649")]
    [AllowMultipleComponents]
    [ComponentName("Melee weapon size change")]
    public class WeaponSizeChangeWeaponGroup : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public int SizeCategoryChange;
        public WeaponFighterGroup weaponGroup;
        public bool ignoreWeaponGroup;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if ((ignoreWeaponGroup || evt.Weapon.Blueprint.FighterGroup.Contains(this.weaponGroup)) && SizeCategoryChange != 0)
            {
                for (var i = 0; i < Math.Abs(SizeCategoryChange); i++)
                {
                    if (SizeCategoryChange > 0)
                    {
                        evt.IncreaseWeaponSize();
                    }
                    else
                    {
                        evt.DecreaseWeaponSize();
                    }
                }
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {
        }
    }
}
