using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    class SummonerProgression
    {
        private static class Strings
        {
            public const string SummonerProgression = "SummonerProgression";
        }
        public static BlueprintProgression Initialize()
        {
        SummonerProficiencies.Initialize();
            SummonerSecondSpellbook.Initialize();

            var entries = LevelEntryBuilder.New()
                    .AddEntry(1, GetGUID.SummonerProficiencies, GetGUID.SummonerSecondSpellbookFeat, GetGUID.SummonerLifeLinkFeature, GetGUID.FakeEidolonFeature);

            return ProgressionConfigurator.New(Strings.SummonerProgression, GetGUID.SummonerProgression)
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .SetForAllOtherClasses(false)
                .SetLevelEntries(entries)
                .Configure();
        }
    }
}
