using WOTR_MAKING_FRIENDS.Spells.Summoning;

namespace WOTR_MAKING_FRIENDS.Spells
{
    class CreateSpells
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
