using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureAspect
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerAspectFeature";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }
        public static void Create()
        {
            CreateFeature();
        }
        public static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(FeatureRefs.ChimericAspectFeature.Reference.Get().m_Icon)
                .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionOneAbilityBase")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionTwoAbilityBase")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("AddEvolutionPointsFeature")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("ExtraEvolutionPoolFeature")),
                                  BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("AddMaxAttacksFeatureAspect"))})
                .SetGroups(FeatureGroupExtension.SummonerFeatureGroup)
                .ConfigureWithLogging();

        }
    }
}
