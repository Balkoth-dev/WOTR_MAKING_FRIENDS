using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureShieldAllyGreater
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerShieldAllyGreaterFeature";
            internal const string AuraFeature = "SummonerShieldAllyGreaterAuraFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerShieldAllyGreaterFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerShieldAllyGreaterFeature.Description");
        }
        public static void CreateShieldAllyGreater()
        {
            CreateShieldAllyGreaterFeature();
            CreateShieldAllyGreaterAuraFeature();
        }
        private static void CreateShieldAllyGreaterFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddRemoveFeatureOnApply(GetGUID.GUIDByName("SummonerShieldAllyFeature"))
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.GUIDByName("SummonerShieldAllyGreaterAuraFeature"), PetTypeExtensions.Eidolon)
                .ConfigureWithLogging();

        }
        private static void CreateShieldAllyGreaterAuraFeature()
        {
            FeatureConfigurator.New(IClass.AuraFeature, GetGUID.GUIDByName(IClass.AuraFeature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.GUIDByName("SummonerShieldAllyGreaterAuraBuff"))
                .ConfigureWithLogging();
        }
    }
}
