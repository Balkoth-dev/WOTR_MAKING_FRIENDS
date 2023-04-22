using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonBaseProgression
    {
        private static class InternalString
        {
            internal const string Progression = "EidolonBaseProgression";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonBaseProgression.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonBaseProgression.Description");
        }
        public static void CreateEidolonBaseProgression()
        {
            LevelEntryBuilder entries = LevelEntryBuilder.New();
            entries.AddEntry(2, FeatureRefs.Evasion.Cast<BlueprintFeatureBaseReference>().Reference);
            entries.AddEntry(6, FeatureRefs.AnimalCompanionDevotion.Cast<BlueprintFeatureBaseReference>().Reference);
            entries.AddEntry(9, FeatureRefs.Multiattack.Cast<BlueprintFeatureBaseReference>().Reference);
            entries.AddEntry(14, FeatureRefs.ImprovedEvasion.Cast<BlueprintFeatureBaseReference>().Reference);

            ProgressionConfigurator.New(InternalString.Progression, GetGUID.GUIDByName("EidolonBaseProgression"))
                .CopyFrom(ProgressionRefs.DruidAnimalCompanionProgression, c => c is null)
                .SetLevelEntries(entries)
                .SetClasses(GetGUID.GUIDByName("SummonerClass"))
                .SetUIGroups(new())
                .SetUIDeterminatorsGroup(new BlueprintCore.Utils.Blueprint<BlueprintFeatureBaseReference>[] { })
                .ConfigureWithLogging();

        }
    }
}
