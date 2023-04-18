using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.CharacterClass;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Progressions
{
    internal class EidolonProgression
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
                entries.AddEntry(i, GetGUID.EidolonRankFeature);
            }
            ProgressionConfigurator.New(InternalString.Progression, GetGUID.EidolonProgression)
                .CopyFrom(ProgressionRefs.DruidAnimalCompanionProgression, c => c is null)
                .SetLevelEntries(entries)
                .SetClasses(GetGUID.SummonerClass)
                .SetUIGroups(new())
                .SetUIDeterminatorsGroup(new BlueprintCore.Utils.Blueprint<BlueprintFeatureBaseReference>[] { })
                .Configure();

        }
    }
}
