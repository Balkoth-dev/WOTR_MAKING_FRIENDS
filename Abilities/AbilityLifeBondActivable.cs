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
        internal static class IClass
        {
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeBondFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeBondFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeBondActivatableAbility";
        }
        public static void CreateLifeBondActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(IClass.ActivatableAbility, GetGUID.GUIDByName("SummonerLifeBondActivatableAbility"))
                                          .SetDisplayName(IClass.Name)
                                          .SetDescription(IClass.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName("SummonerLifeBondBuff")))
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetIsOnByDefault(true)
                                          .SetDoNotTurnOffOnRest(false)
                                          .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeBond.png"))
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .ConfigureWithLogging();
        }
    }
}
