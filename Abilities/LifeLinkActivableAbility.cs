﻿using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class LifeLinkActivableAbility
    {
        private static class InternalString
        {
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeLinkActivatableAbility";
        }
        public static void CreateLifeLinkActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(InternalString.ActivatableAbility, GetGUID.SummonerLifeLinkActivatableAbility)
                                          .SetDisplayName(InternalString.Name)
                                          .SetDescription(InternalString.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.SummonerLifeLinkBuff))
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetIsOnByDefault(true)
                                          .SetDoNotTurnOffOnRest(false)
                                          .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .Configure();
        }
    }
}
