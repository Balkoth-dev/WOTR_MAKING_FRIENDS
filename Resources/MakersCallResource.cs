using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Resources
{
    internal class MakersCallResource
    {
        public static void CreateMakersCallResource()
        {
            Kingmaker.Blueprints.BlueprintAbilityResource.Amount maxAmount = ResourceAmountBuilder.New(1).IncreaseByLevelStartPlusDivStep(new string[] { GetGUID.GUIDByName("SummonerClass") }, startingLevel: 6, levelsPerStep: 4, bonusPerStep: 1).Build();
            AbilityResourceConfigurator.New("SummonerMakersCallResource", GetGUID.GUIDByName("SummonerMakersCallResource"))
                .CopyFrom(AbilityResourceRefs.ItemBondResource, c => c is null)
                .SetMaxAmount(maxAmount)
                .Configure();
        }
    }
}
