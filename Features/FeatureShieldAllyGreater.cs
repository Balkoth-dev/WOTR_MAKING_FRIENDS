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
        private static class InternalString
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
            FeatureConfigurator.New(InternalString.Feature, GetGUID.GUIDByName(InternalString.Feature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddRemoveFeatureOnApply(GetGUID.GUIDByName("SummonerShieldAllyFeature"))
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.GUIDByName("SummonerShieldAllyGreaterAuraFeature"), PetTypeExtensions.Eidolon)
                .ConfigureWithLogging();

        }
        private static void CreateShieldAllyGreaterAuraFeature()
        {
            FeatureConfigurator.New(InternalString.AuraFeature, GetGUID.GUIDByName(InternalString.AuraFeature))
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.GUIDByName("SummonerShieldAllyGreaterAuraBuff"))
                .ConfigureWithLogging();
        }
    }
}
