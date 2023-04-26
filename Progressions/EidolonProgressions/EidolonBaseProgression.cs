using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonBaseProgression
    {
        private static class InternalString
        {
            internal const string Progression = "EidolonBaseProgression";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonBaseProgression.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonBaseProgression.Description");
            internal static string ExtraEvolutionPoolFeature = GetGUID.GUIDByName("ExtraEvolutionPoolFeature");
            internal static string AddEvolutionPoolResource = GetGUID.GUIDByName("AddEvolutionPointsFeature");
        }
        public static void CreateEidolonBaseProgression()
        {
            LevelEntryBuilder entries = LevelEntryBuilder.New()
                                .AddEntry(1,
                                         BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddEvolutionPointsFeature")),
                                         BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddMaxAttacksFeature")),
                                         BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("EvolutionBaseAbilitiesFeature")),
                                         BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("EidolonSubtypeSelectionFeature"))
                                         )
                                .AddEntry(2, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(3, FeatureRefs.Evasion.Cast<BlueprintFeatureBaseReference>().Reference, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(4, InternalString.ExtraEvolutionPoolFeature, BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddMaxAttacksStepFeature")))
                                .AddEntry(5, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(6, FeatureRefs.AnimalCompanionDevotion.Cast<BlueprintFeatureBaseReference>().Reference, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(7, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(9, FeatureRefs.Multiattack.Cast<BlueprintFeatureBaseReference>().Reference, InternalString.ExtraEvolutionPoolFeature, BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddMaxAttacksStepFeature")))
                                .AddEntry(10, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(11, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(13, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(14, FeatureRefs.ImprovedEvasion.Cast<BlueprintFeatureBaseReference>().Reference, InternalString.ExtraEvolutionPoolFeature, BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddMaxAttacksStepFeature")))
                                .AddEntry(15, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(17, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(18, InternalString.ExtraEvolutionPoolFeature)
                                .AddEntry(19, InternalString.ExtraEvolutionPoolFeature, BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName("AddMaxAttacksStepFeature")));

            var progression = ProgressionConfigurator.New(InternalString.Progression, GetGUID.GUIDByName("EidolonBaseProgression"))
                                                     .SetLevelEntries(entries)
                                                     .SetIsClassFeature(true)
                                                     .SetRanks(1)
                                                     .SetClasses(GetGUID.GUIDByName("SummonerClass"));

            foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonBaseForm)))
            {
                try
                {
                    var characterClassName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + "Class";
                    var characterClassGuid = GetGUID.GUIDByName(characterClassName);
                    progression.AddToClasses(BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClassGuid));
                }
                catch { }
            }

            progression.ConfigureWithLogging();

        }
    }
}
