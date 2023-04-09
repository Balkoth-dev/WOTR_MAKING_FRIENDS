using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class ShieldAllyGreaterFeature
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
            FeatureConfigurator.New(InternalString.Feature, GetGUID.SummonerShieldAllyGreaterFeature)
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddRemoveFeatureOnApply(GetGUID.SummonerShieldAllyFeature)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddFeatureToPet(GetGUID.SummonerShieldAllyGreaterAuraFeature, PetTypeExtensions.Eidolon)
                .Configure();

        }
        private static void CreateShieldAllyGreaterAuraFeature()
        {
            FeatureConfigurator.New(InternalString.AuraFeature, GetGUID.SummonerShieldAllyGreaterAuraFeature)
                .CopyFrom(FeatureRefs.CavalierSpiritualShield.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddAuraFeatureComponent(GetGUID.SummonerShieldAllyGreaterAuraBuff)
                .Configure();
        }
    }
}
