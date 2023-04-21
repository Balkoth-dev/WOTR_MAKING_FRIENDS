using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class AbilityLifeBondActivable
    {
        private static class InternalString
        {
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeBondFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeBondFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeBondActivatableAbility";
        }
        public static void CreateLifeBondActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(InternalString.ActivatableAbility, GetGUID.SummonerLifeBondActivatableAbility)
                                          .SetDisplayName(InternalString.Name)
                                          .SetDescription(InternalString.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.SummonerLifeBondBuff))
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetIsOnByDefault(true)
                                          .SetDoNotTurnOffOnRest(false)
                                          .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeBond.png"))
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .Configure();
        }
    }
}
