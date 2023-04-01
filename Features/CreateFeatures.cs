namespace WOTR_MAKING_FRIENDS.Features
{
    internal class CreateFeatures
    {
        public static void CreateAllFeatures()
        {
            EidolonLifeLink.CreateEidolonLifeLink();
            FakeEidolonFeature.CreateFakeEidolon();
            BondedSenses.CreateBondedSenses();
        }
    }
}
