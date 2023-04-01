﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features
{
    internal class FakeEidolonFeature
    {
        private static class InternalString
        {
            internal const string Feature = "FakeEidolonFeature";
            internal static LocalizedString Name = Helpers.ObtainString("FakeEidolonFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("FakeEidolonFeature.Description");
        }
        public static void CreateFakeEidolon()
        {
            CreateFakeEidolonFeature();
        }
        public static void CreateFakeEidolonFeature()
        {
            FeatureConfigurator.New(InternalString.Feature, GetGUID.FakeEidolonFeature)
                .CopyFrom(FeatureRefs.AnimalCompanionFeatureDog.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddPet(
                    type: PetTypeExtensions.Eidolon,
                    progressionType: PetProgressionType.AnimalCompanion,
                    levelRank: FeatureRefs.AnimalCompanionRank.Cast<BlueprintFeatureReference>().Reference,
                    pet: UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference
                )
                .Configure();

        }
    }
}
