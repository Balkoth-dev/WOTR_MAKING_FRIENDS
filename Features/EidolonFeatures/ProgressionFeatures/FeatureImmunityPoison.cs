using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using UnityEngine; using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureImmunityPoison
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "ImmunityPoison";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public void Create()
        {
            CreateFeature();
        }
        internal void CreateFeature()
        {

            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .CopyFrom(FeatureRefs.ImmunityToPoison, c => true)
                    .ConfigureWithLogging();
        }
    }
}
