namespace WOTR_MAKING_FRIENDS.Features
{
    internal class CreateFeatures
    {
        public static void CreateAllFeatures()
        {
            LifeLinkFeature.CreateEidolonLifeLink();
            FakeEidolonFeature.CreateFakeEidolon();
            BondedSensesFeature.CreateBondedSenses();
            MakersCallFeature.CreateMakersCall();
            TranspositionFeature.CreateTransposition();
            ShieldAllyFeature.CreateShieldAlly();
            ShieldAllyGreaterFeature.CreateShieldAllyGreater();
            LifeBondFeature.CreateEidolonLifeBond();
            EidolonRank.CreateEidolonRank();
        }
    }
}
