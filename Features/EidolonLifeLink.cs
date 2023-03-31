using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    class EidolonLifeLink
    {
        private static class InternalString
        {
            internal const string Feature = "SummonerLifeLinkFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeLinkActivatableAbility";
        }
        public static void CreateEidolonLifeLink()
        {
            CreateEidolonLifeLinkActivatableAbility();
            CreateEidolonLifeLinkFeature();
        }
        public static void CreateEidolonLifeLinkFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.SummonerLifeLinkFeature)
                .CopyFrom(FeatureRefs.OracleRevelationLifeLink.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.SummonerLifeLinkActivatableAbility) })
                .Configure();

        }
        public static void CreateEidolonLifeLinkActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(InternalString.ActivatableAbility, GetGUID.SummonerLifeLinkActivatableAbility)
                                          .SetDisplayName(InternalString.Name)
                                          .SetDescription(InternalString.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.SummonerLifeLinkBuff))
                                          .SetIcon(AbilityRefs.OracleRevelationLifeLinkAbility.Cast<BlueprintAbilityReference>().Reference.Get().m_Icon)
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .Configure();
        }
    }
}
