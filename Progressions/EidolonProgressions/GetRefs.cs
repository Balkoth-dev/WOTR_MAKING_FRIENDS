using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal static class GetRefs
    {
        public static BlueprintFeatureBaseReference Cast(Blueprint<BlueprintReference<BlueprintFeature>> brb)
        {
            return brb.Cast<BlueprintFeatureBaseReference>().Reference;
        }
        public static BlueprintFeatureBaseReference Cast(Blueprint<BlueprintReference<BlueprintAbility>> brb)
        {
            return brb.Cast<BlueprintFeatureBaseReference>().Reference;
        }
        public static BlueprintFeatureBaseReference Cast(Blueprint<BlueprintReference<BlueprintAbilityResource>> brb)
        {
            return brb.Cast<BlueprintFeatureBaseReference>().Reference;
        }
        public static BlueprintFeatureBaseReference Cast(Blueprint<BlueprintReference<BlueprintBuff>> brb)
        {
            return brb.Cast<BlueprintFeatureBaseReference>().Reference;
        }
    }
}
