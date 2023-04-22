using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Progressions
{
    internal class ProgressionEidolon
    {
        private static class InternalString
        {
            internal const string Progression = "EidolonProgression";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonProgression.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonProgression.Description");
        }
        public static void CreateEidolonProgression()
        {
            LevelEntryBuilder entries = LevelEntryBuilder.New();

            for (var i = 2; i <= 20; i++)
            {
                entries.AddEntry(i, GetGUID.GUIDByName("EidolonRankFeature"));
            }
            ProgressionConfigurator.New(InternalString.Progression, GetGUID.GUIDByName("EidolonProgression"))
                .CopyFrom(ProgressionRefs.DruidAnimalCompanionProgression, c => c is null)
                .SetLevelEntries(entries)
                .SetClasses(GetGUID.GUIDByName("SummonerClass"))
                .SetUIGroups(new())
                .SetUIDeterminatorsGroup(new BlueprintCore.Utils.Blueprint<BlueprintFeatureBaseReference>[] { })
                .Configure();

        }
    }
}
