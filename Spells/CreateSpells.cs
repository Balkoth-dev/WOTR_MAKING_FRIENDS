using WOTR_MAKING_FRIENDS.Spells.Summoning;

namespace WOTR_MAKING_FRIENDS.Spells
{
    internal class CreateSpells
    {
        public static void CreateAllSpells()
        {
            CreateSummonSpells.CreateSummoningSpells();
            BlackTentacles.CreateBlackTentaclesSpell();
            InfernalHealing.CreateInfernalHealing();
            InfernalHealing.CreateGreaterInfernalHealing();
            Overstimulate.CreateOverstimulate();
        }


    }
}
