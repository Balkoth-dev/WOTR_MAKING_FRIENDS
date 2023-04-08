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
    internal class MakersCallAbility
    {
        private static readonly BlueprintAbility emergencySwapAbility = BlueprintTool.Get<BlueprintAbility>("b50ca9b5d6292fb42b8eab8e5d64842d");
        private static class InternalString
        {
            internal const string Ability = "SummonerMakersCallAbility";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerMakersCallFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerMakersCallFeature.Description");
        }
        public static void CreateMakersCallAbility()
        {
            AbilityCustomDimensionDoorSwap emergencySwapAbilityDimensionDoorSwap = emergencySwapAbility.GetComponent<AbilityCustomDimensionDoorSwap>();

            AbilityCustomDimensionDoorToCaster abilityCustomDimensionDoorToCaster = new AbilityCustomDimensionDoorToCaster()
            {
                PortalBone = emergencySwapAbilityDimensionDoorSwap.PortalBone,
                PortalFromPrefab = emergencySwapAbilityDimensionDoorSwap.PortalFromPrefab,
                DisappearFx = emergencySwapAbilityDimensionDoorSwap.DisappearFx,
                AppearFx = emergencySwapAbilityDimensionDoorSwap.AppearFx,
                m_AppearProjectile = ProjectileRefs.DimensionDoor00_CasterAppear.Cast<BlueprintProjectileReference>().Reference,
                m_DisappearProjectile = ProjectileRefs.DimensionDoor00_CasterDisappear.Cast<BlueprintProjectileReference>().Reference,
            };

            BlueprintAbility ability = AbilityConfigurator.New(InternalString.Ability, GetGUID.SummonerMakersCallAbility)
                .CopyFrom(AbilityRefs.ArcanistExploitDimensionalSlideAbility, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddComponent<AbilityTargetIsEidolon>()
                .SetCanTargetPoint(false)
                .SetCanTargetFriends(true)
                .SetCanTargetSelf(false)
                .SetRange(AbilityRange.Long)
                .SetIcon(FeatureRefs.DimensionalRideFeature.Reference.Get().m_Icon)
                .SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.SummonerMakersCallResource))
                .Configure();

            ability.AddComponents(abilityCustomDimensionDoorToCaster);

        }
    }
}
