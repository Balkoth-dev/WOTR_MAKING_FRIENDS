﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureIncoporeal
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "Incoporeal";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            CreateFeature();
        }
        internal static void CreateFeature()
        {

            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .CopyFrom(FeatureRefs.StygianSlayerShadowyMistForm, c => true)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .SetGroups(IClass.featureGroup)
                    .AddAbilityResources(1,AbilityResourceRefs.StygianSlayerShadowyMistFormResource.Cast<BlueprintAbilityResourceReference>(),true,useThisAsResource:true)
                    .ConfigureWithLogging();
        }
    }
}