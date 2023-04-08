using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
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
            AddEidolon addEidolon = new AddEidolon()
            {
                m_Pet = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                ProgressionType = PetProgressionType.AnimalCompanion,
                m_UseContextValueLevel = false,
                m_LevelRank = FeatureRefs.AnimalCompanionRank.Cast<BlueprintFeatureReference>().Reference,
                Type = PetTypeExtensions.Eidolon,
                m_ForceAutoLevelup = false
            };
            Kingmaker.Blueprints.Classes.BlueprintFeature fakeEidolon = FeatureConfigurator.New(InternalString.Feature, GetGUID.FakeEidolonFeature)
                .CopyFrom(FeatureRefs.AnimalCompanionFeatureDog.Cast<BlueprintFeatureReference>().Reference, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddFeatureOnApply(ProgressionRefs.DruidAnimalCompanionProgression.Cast<BlueprintFeatureReference>())
                .AddFeatureOnApply(FeatureRefs.AnimalCompanionRank.Cast<BlueprintFeatureReference>())
                /* .AddPet(
                     type: PetTypeExtensions.Eidolon,
                     progressionType: PetProgressionType.AnimalCompanion,
                     levelRank: FeatureRefs.AnimalCompanionRank.Cast<BlueprintFeatureReference>().Reference,
                     pet: UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference
                 )*/
                .Configure();

            fakeEidolon.AddComponents(new[] { addEidolon });

        }
    }
}
