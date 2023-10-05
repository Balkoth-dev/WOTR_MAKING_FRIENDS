using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FeatureShieldAlly
    {
        internal static class IClass
        {
            internal const string Feature = "SummonerShieldAllyFeature";
            internal const string AuraFeature = "SummonerShieldAllyAuraFeature";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerShieldAllyFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerShieldAllyFeature.Description");
        }
        public static void CreateShieldAlly()
        {
            CreateShieldAllyFeature();
            CreateShieldAllyAuraFeature();
        }
        private static void CreateShieldAllyFeature()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.GUIDByName("SummonerShieldAllyAuraFeature"), PetTypeExtensions.Eidolon)
                .ConfigureWithLogging();

        }
        private static void CreateShieldAllyAuraFeature()
        {
            FeatureConfigurator.New(IClass.AuraFeature, GetGUID.GUIDByName(IClass.AuraFeature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.GUIDByName("SummonerShieldAllyAuraBuff"))
                .ConfigureWithLogging();
        }
    }
}
