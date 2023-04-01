namespace WOTR_MAKING_FRIENDS.Features
{
    internal class CreateFeatures
    {
        public static void CreateAllFeatures()
        {
            EidolonLifeLinkFeature.CreateEidolonLifeLink();
            FakeEidolonFeature.CreateFakeEidolon();
            BondedSensesFeature.CreateBondedSenses();
            MakersCallFeature.CreateMakersCall();
        }
    }
}
