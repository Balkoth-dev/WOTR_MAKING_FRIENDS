using WOTR_MAKING_FRIENDS.Features.EidolonFeatures;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions;

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
            FeatureExtraEvolutionPool.Create();
            FeatureAddEvolutionPoints.Create();
            FeatureEidolonTypes.Create();
            FeatureEidolonSelection.Create();
            FeatureCreateAllEvolutions.Create();
            FeatureAddMaxAttacks.Create();
        }
    }
}
