using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class CreateFeatures
    {
        public static void CreateAllFeatures()
        {
            FeatureLifeLink.CreateEidolonLifeLink();
            FeatureFakeEidolon.CreateFakeEidolon();
            FeatureBondSenses.CreateBondedSenses();
            FeatureMakersCall.CreateMakersCall();
            FeatureTransposition.CreateTransposition();
            FeatureShieldAlly.CreateShieldAlly();
            FeatureShieldAllyGreater.CreateShieldAllyGreater();
            FeatureLifeBond.CreateEidolonLifeBond();
            FeatureEidolonRank.CreateEidolonRank();
            FeatureEidolonTypes.Create();
        }
    }
}
