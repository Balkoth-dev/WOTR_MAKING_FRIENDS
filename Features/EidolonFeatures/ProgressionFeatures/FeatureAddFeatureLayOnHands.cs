using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine; using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureAddFeatureLayOnHands
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddFeatureLayOnHands";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        internal static class IClassFeature
        {
            internal static string Ability = IClass.ProgressionFeature + "AddedFeature";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static string Name = Helpers.ObtainString(Ability + ".Name");
            internal static string Description = Helpers.ObtainString(Ability + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public void Create()
        {
            CreateFeature();
            CreateAbility();
        }
        internal void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassFeature.Guid) })
                    .ConfigureWithLogging();
        }
        internal void CreateAbility()
        {
            FeatureConfigurator.New(IClassFeature.Ability, IClassFeature.Guid)
                .CopyFrom(FeatureRefs.LayOnHandsFeature, c => true)
                .AddAbilityResources(3, AbilityResourceRefs.LayOnHandsResource.Cast<BlueprintAbilityResourceReference>(), true, true, true)
                .ConfigureWithLogging();
        }
    }
}
