using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System;
using System.Linq;

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

        public bool plusFeatureRanks;
        public BlueprintFeatureReference m_Feature;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            int bonusRanks = 0;
            Main.Log("Size Category Change: " + SizeCategoryChange);
            if (plusFeatureRanks)
            {
                Main.Log("Size Category Change: " + SizeCategoryChange);
                if (m_Feature != null)
                {
                    bonusRanks = evt.Initiator.Progression.Features.GetRank(m_Feature.Get());
                    Main.Log("Size Category Change: " + SizeCategoryChange);
                }
            }
            Main.Log("Size Category Change: " + SizeCategoryChange);

            if ((ignoreWeaponGroup || evt.Weapon.Blueprint.FighterGroup.Contains(this.weaponGroup)) && SizeCategoryChange != 0)
            {
                for (var i = 0; i < Math.Abs(SizeCategoryChange + bonusRanks); i++)
                {
                    if (SizeCategoryChange + bonusRanks > 0)
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
