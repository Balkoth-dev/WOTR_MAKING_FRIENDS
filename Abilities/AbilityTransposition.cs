using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class AbilityTransposition
    {
        internal static class IClass
        {
            internal const string Ability = "SummonerTranspositionAbility";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerTranspositionFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerTranspositionFeature.Description");
        }
        public static void CreateTranspositionAbility()
        {
            BlueprintAbility ability = AbilityConfigurator.New(IClass.Ability, GetGUID.GUIDByName("SummonerTranspositionAbility"))
                .CopyFrom(AbilityRefs.EmergencySwapAbility, c => c is AbilityCustomDimensionDoorSwap)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddComponent<AbilityTargetIsEidolon>()
                .SetCanTargetPoint(false)
                .SetCanTargetFriends(true)
                .SetCanTargetSelf(false)
                .SetRange(AbilityRange.Long)
                .SetIcon(FeatureRefs.SpellDanceFeature.Reference.Get().m_Icon)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerMakersCallResource")))
                .ConfigureWithLogging();
        }
    }
}
