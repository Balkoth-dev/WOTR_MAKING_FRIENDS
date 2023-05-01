using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class AbilityLifeLinkActivable
    {
        private static class IClass
        {
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeLinkActivatableAbility";
        }
        public static void CreateLifeLinkActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(IClass.ActivatableAbility, GetGUID.GUIDByName("SummonerLifeLinkActivatableAbility"))
                                          .SetDisplayName(IClass.Name)
                                          .SetDescription(IClass.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName("SummonerLifeLinkBuff")))
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetIsOnByDefault(true)
                                          .SetDoNotTurnOffOnRest(false)
                                          .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .ConfigureWithLogging();
        }
    }
}
