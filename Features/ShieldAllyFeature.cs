using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class ShieldAllyFeature
    {
        private static class InternalString
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
            FeatureConfigurator.New(InternalString.Feature, GetGUID.SummonerShieldAllyFeature)
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.SummonerShieldAllyAuraFeature, PetTypeExtensions.Eidolon)
                .Configure();

        }
        private static void CreateShieldAllyAuraFeature()
        {
            FeatureConfigurator.New(InternalString.AuraFeature, GetGUID.SummonerShieldAllyAuraFeature)
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.SummonerShieldAllyAuraBuff)
                .Configure();
        }
    }
}
