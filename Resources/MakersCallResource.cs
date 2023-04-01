using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Resources
{
    class MakersCallResource
    {
        public static void CreateMakersCallResource()
        {
            var maxAmount = ResourceAmountBuilder.New(1).IncreaseByLevelStartPlusDivStep(new string[] { GetGUID.SummonerClass },startingLevel:6,levelsPerStep:4,bonusPerStep:1).Build();
            AbilityResourceConfigurator.New("SummonerMakersCallResource", GetGUID.SummonerMakersCallResource)
                .CopyFrom(AbilityResourceRefs.ItemBondResource, c => c is null)
                .SetMaxAmount(maxAmount)
                .Configure();
        }
    }
}
