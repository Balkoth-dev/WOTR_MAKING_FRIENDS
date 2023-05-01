using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._4_Point_Evolutions;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions
{
    public static class AdjustEvolutions
    {
        public static void Adjust()
        {
            //1-Point Evolutions
            EvolutionBite.Adjust();
            EvolutionClaws.Adjust();
            EvolutionGore.Adjust();
            EvolutionMagicAttacks.Adjust();
            EvolutionNaturalArmor.Adjust();
            EvolutionPincers.Adjust();
            EvolutionResistance.Adjust();
            EvolutionScent.Adjust();
            EvolutionSkilled.Adjust();
            EvolutionSlam.Adjust();
            EvolutionSpike.Adjust();
            EvolutionTail.Adjust();
            EvolutionTailSlap.Adjust();
            EvolutionTentacle.Adjust();
            EvolutionTentacleMass.Adjust();
            EvolutionWingBuffet.Adjust();

            //2-Point Evolutions
            EvolutionAbilityIncrease.Adjust();
            EvolutionBloodFrenzy.Adjust();
            EvolutionBullrush.Adjust();
            EvolutionEnergyAttacks.Adjust();
            EvolutionFlight.Adjust();
            EvolutionImmunity.Adjust();
            EvolutionLimbsArms.Adjust();
            EvolutionLimbsLegs.Adjust();
            EvolutionRend.Adjust();
            EvolutionSunderarmor.Adjust();
            EvolutionTrample.Adjust();
            EvolutionTrip.Adjust();

            //3-Point Evolutions
            EvolutionClawsLimbs.Adjust();
            EvolutionDamageReduction.Adjust();
            EvolutionImprovedDamage.Adjust();
            EvolutionPincersLimbs.Adjust();
            EvolutionPounce.Adjust();
            EvolutionReach.Adjust();
            EvolutionSlamLimbs.Adjust();
            EvolutionWeb.Adjust();

            //4-Point Evolutions
            EvolutionAmorphous.Adjust();
            EvolutionBlindsight.Adjust();
            EvolutionBreathWeapon.Adjust();
            EvolutionFastHealing.Adjust();
            EvolutionLarge.Adjust();
            EvolutionSpellResistance.Adjust();
        }

    }

}
