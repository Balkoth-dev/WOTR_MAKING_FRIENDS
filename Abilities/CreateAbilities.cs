namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class CreateAbilities
    {
        public static void CreateAllAbilities()
        {
            AbilityLifeLinkActivable.CreateLifeLinkActivatableAbility();
            AbilityMakersCall.CreateMakersCallAbility();
            AbilityTransposition.CreateTranspositionAbility();
            AbilityLifeBondActivable.CreateLifeBondActivatableAbility();
        }
    }
}
