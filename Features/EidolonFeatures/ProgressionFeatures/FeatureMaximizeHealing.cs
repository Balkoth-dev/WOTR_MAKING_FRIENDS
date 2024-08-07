﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Designers.Mechanics.Facts.AutoMetamagic;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureMaximizeHealing
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonMaximizeHealing";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.ArcaneMetamagicFeature.Reference.Get().m_Icon;
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
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddAutoMetamagic(descriptor: new SpellDescriptorWrapper() { m_IntValue = (long)SpellDescriptor.Cure }, metamagic: Metamagic.Maximize, allowedAbilities: AllowedType.Any)
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
    }
}
