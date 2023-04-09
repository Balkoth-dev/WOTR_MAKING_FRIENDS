namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class CreateAbilities
    {
        public static void CreateAllAbilities()
        {
            LifeLinkActivableAbility.CreateLifeLinkActivatableAbility();
            MakersCallAbility.CreateMakersCallAbility();
            TranspositionAbility.CreateTranspositionAbility();
            LifeBondActivableAbility.CreateLifeBondActivatableAbility();
        }
    }
}
