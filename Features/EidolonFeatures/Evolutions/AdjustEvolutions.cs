using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions
{
    public static class AdjustEvolutions
    {
        public static void Adjust()
        {
            EvolutionBite.Adjust();
            EvolutionClaws.Adjust();
            EvolutionImprovedDamage.Adjust();
            EvolutionMagicAttacks.Adjust();
            EvolutionNaturalArmor.Adjust();
            EvolutionPincers.Adjust();
            EvolutionReach.Adjust();
            EvolutionResistance.Adjust();
            EvolutionScent.Adjust();
            EvolutionSkilled.Adjust();
            EvolutionSlam.Adjust();
            EvolutionSting.Adjust();
            EvolutionTail.Adjust();
            EvolutionTentacle.Adjust();
            EvolutionTentacleMass.Adjust();
            EvolutionWingBuffet.Adjust(); 
        }
    }
}
