using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class CreateFeatures
    {
        public static void CreateAllFeatures()
        {
            FeatureLifeLink.CreateEidolonLifeLink();
            FeatureFakeEidolon.CreateFakeEidolon();
            FeatureBondSenses.Create();
            FeatureMakersCall.CreateMakersCall();
            FeatureTransposition.CreateTransposition();
            FeatureShieldAlly.CreateShieldAlly();
            FeatureShieldAllyGreater.CreateShieldAllyGreater();
            FeatureLifeBond.CreateEidolonLifeBond();
            FeatureEidolonRank.CreateEidolonRank();
            FeatureArmorBonus.Create();
            FeatureAddEvolutionPoints.Create();
            CreateProgressionFeatures.Create();
            FeatureEidolonTypes.Create();
            FeatureEidolonSelection.Create();
            FeatureCreateAllEvolutions.Create();
            FeatureAddMaxAttacks.Create();
        }
    }
}
