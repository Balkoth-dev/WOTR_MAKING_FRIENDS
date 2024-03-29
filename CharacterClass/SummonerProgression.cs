﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    internal class SummonerProgression
    {
        private static class Strings
        {
            public const string SummonerProgression = "SummonerProgression";
        }
        public static BlueprintProgression Initialize()
        {
            SummonerProficiencies.Initialize();
            SummonerSecondSpellbook.Initialize();

            LevelEntryBuilder entries = LevelEntryBuilder.New()
                    .AddEntry(1, GetGUID.GUIDByName("SummonerProficiencies"),
                                 GetGUID.GUIDByName("SummonerSecondSpellbookFeat"),
                                 GetGUID.GUIDByName("SummonerLifeLinkFeature"),
                                 GetGUID.GUIDByName("EidolonBaseFeatureSelection"),
                                 GetGUID.GUIDByName("EidolonProgression"),
                                 GetGUID.GUIDByName("EidolonRankFeature"),
                                 GetGUID.GUIDByName("EvolutionLimbsArmsFeature"),
                                 GetGUID.GUIDByName("EvolutionLimbsArmsBaseFeature"))
                    .AddEntry(2, GetGUID.GUIDByName("SummonerBondedSensesFeature"))
                    .AddEntry(4, GetGUID.GUIDByName("SummonerShieldAllyFeature"))
                    .AddEntry(6, GetGUID.GUIDByName("SummonerMakersCallFeature"))
                    .AddEntry(8, GetGUID.GUIDByName("SummonerTranspositionFeature"))
                    .AddEntry(10, GetGUID.GUIDByName("SummonerAspectFeature"))
                    .AddEntry(12, GetGUID.GUIDByName("SummonerShieldAllyGreaterFeature"))
                    .AddEntry(14, GetGUID.GUIDByName("SummonerLifeBondFeature"))
                    .AddEntry(18, GetGUID.GUIDByName("SummonerAspectGreaterFeature"));

            return ProgressionConfigurator.New(Strings.SummonerProgression, GetGUID.GUIDByName("SummonerProgression"))
                .SetAllowNonContextActions(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .SetHideNotAvailibleInUI(false)
                .SetRanks(1)
                .SetReapplyOnLevelUp(false)
                .SetIsClassFeature(false)
                .SetForAllOtherClasses(false)
                .SetClasses(GetGUID.GUIDByName("SummonerClass"))
                .SetLevelEntries(entries)
                .ConfigureWithLogging();
        }
    }
}
