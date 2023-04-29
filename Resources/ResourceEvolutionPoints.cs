﻿using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Resources
{
    internal class ResourceEvolutionPoints
    {
        public static void Create()
        {
            Kingmaker.Blueprints.BlueprintAbilityResource.Amount maxAmount = ResourceAmountBuilder.New(1).Build();
            AbilityResourceConfigurator.New("SummonerEvolutionPointsResource", GetGUID.GUIDByName("SummonerEvolutionPointsResource"))
                .SetMaxAmount(maxAmount)
                .ConfigureWithLogging();
        }
    }
}