using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Progressions
{
    internal class ProgressionEidolon
    {
        internal static class IClass
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
            ProgressionConfigurator.New(IClass.Progression, GetGUID.GUIDByName("EidolonProgression"))
                .SetLevelEntries(entries)
                .SetClasses(GetGUID.GUIDByName("SummonerClass"))
                .SetIsClassFeature(true)
                .SetRanks(1)
                .SetHideInUI(true)
                .ConfigureWithLogging();

        }
    }
}
