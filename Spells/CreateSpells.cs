using WOTR_MAKING_FRIENDS.Spells.Summoning;

namespace WOTR_MAKING_FRIENDS.Spells
{
    internal class CreateSpells
    {
        public static void CreateAllSpells()
        {
            CreateSummonSpells.CreateSummoningSpells();
            SpellBlackTentacles.CreateBlackTentaclesSpell();
            SpellInfernalHealing.CreateInfernalHealing();
            SpellInfernalHealing.CreateGreaterInfernalHealing();
            SpellOverstimulate.CreateOverstimulate();
            SpellTransmogrify.Create();
        }


    }
}
