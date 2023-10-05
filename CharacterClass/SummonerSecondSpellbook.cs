using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    internal class SummonerSecondSpellbook
    {
        internal static class IClass
        {
            internal const string SummonMonsterSpellbook = "SummonerSecondSpellbook";
            internal const string SummonMonsterSpellbookFeat = "SummonerSecondSpellbookFeat";
            internal static readonly LocalizedString SummonMonsterSpellbookName = Helpers.ObtainString(SummonMonsterSpellbook + ".Name");
            internal static readonly LocalizedString SummonMonsterSpellbookFeatName = Helpers.ObtainString(SummonMonsterSpellbookFeat + ".Name");
            internal static readonly LocalizedString SummonMonsterSpellbookFeatDescription = Helpers.ObtainString(SummonMonsterSpellbookFeat + ".Description");
        }

        // Taken from TTT-Core by Vek17
        public static SpellsLevelEntry CreateSpellLevelEntry(params int[] count)
        {
            SpellsLevelEntry entry = new SpellsLevelEntry
            {
                Count = count
            };
            return entry;
        }

        public static void ConfigureSpellSlotsTable()
        {
            SpellsTableConfigurator.New(IClass.SummonMonsterSpellbookName + "SpellsPerDayTable", GetGUID.GUIDByName("SummonerSecondSpellbookSpellsPerDay"))
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0,3),
                        CreateSpellLevelEntry(0,3),
                        CreateSpellLevelEntry(0,3,3),
                        CreateSpellLevelEntry(0,3,3),
                        CreateSpellLevelEntry(0,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3,3),
                        CreateSpellLevelEntry(0,3,3,3,3,3,3,3,3,3)
                })
                .ConfigureWithLogging();
        }

        public static void ConfigureSpellsKnownTable()
        {
            SpellsTableConfigurator.New(IClass.SummonMonsterSpellbook + ".SpellKnownTable", GetGUID.GUIDByName("SummonerSecondSpellbookSpellsKnown"))
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(0),
                        CreateSpellLevelEntry(0,1),
                        CreateSpellLevelEntry(0,1,1),
                        CreateSpellLevelEntry(0,1,1),
                        CreateSpellLevelEntry(0,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1,1),
                        CreateSpellLevelEntry(0,1,1,1,1,1,1,1,1,1)
                    })
                .ConfigureWithLogging();
        }

        public static SpellLevelList Create0thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(0);
            spelllist.m_Spells = new()
            {

            };
            return spelllist;
        }
        public static SpellLevelList Create1stLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(1);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create2ndLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(2);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create3rdLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(3);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create4thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create5thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(5);
            spelllist.m_Spells = new()
            {

            };
            return spelllist;
        }
        public static SpellLevelList Create6thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(6);
            spelllist.m_Spells = new()
            {

            };
            return spelllist;
        }
        public static SpellLevelList Create7thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(7);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create8thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(8);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }
        public static SpellLevelList Create9thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(9);
            spelllist.m_Spells = new()
            {
            };
            return spelllist;
        }


        public static void CreateSpellList()
        {
            SpellListConfigurator.New(IClass.SummonMonsterSpellbook + ".SpellList", GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"))
                .AddToSpellsByLevel(Create0thLevelSpells(),
                Create1stLevelSpells(),
                Create2ndLevelSpells(),
                Create3rdLevelSpells(),
                Create4thLevelSpells(),
                Create5thLevelSpells(),
                Create6thLevelSpells(),
                Create7thLevelSpells(),
                Create8thLevelSpells(),
                Create9thLevelSpells())
                .ConfigureWithLogging();
        }

        public static BlueprintSpellbook CreateSpellBook()
        {
            ConfigureSpellSlotsTable();
            ConfigureSpellsKnownTable();
            CreateSpellList();
            return SpellbookConfigurator.New(IClass.SummonMonsterSpellbook, GetGUID.GUIDByName("SummonerSecondSpellbookSpellBook"))
                .SetName(IClass.SummonMonsterSpellbookName)
                .SetCharacterClass(GetGUID.GUIDByName("SummonerClass"))
                .SetSpellsPerDay(GetGUID.GUIDByName("SummonerSecondSpellbookSpellsPerDay"))
                .SetSpellsKnown(GetGUID.GUIDByName("SummonerSecondSpellbookSpellsKnown"))
                .SetSpellList(GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"))
                .SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetIsArcane(false)
                .SetIsArcanist(false)
                .SetCanCopyScrolls(false)
                .SetAllSpellsKnown(true)
                .SetCasterLevelModifier(0)
                .ConfigureWithLogging();
        }

        public static BlueprintFeature Initialize()
        {
            CreateSpellBook();

            return FeatureConfigurator.New(IClass.SummonMonsterSpellbookFeat, GetGUID.GUIDByName("SummonerSecondSpellbookFeat"))
                .SetDisplayName(IClass.SummonMonsterSpellbookFeatName)
                .SetDescription(IClass.SummonMonsterSpellbookFeatDescription)
                .AddSpellbook(ContextValues.Rank(), spellbook: GetGUID.GUIDByName("SummonerSecondSpellbookSpellBook"))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(GetGUID.GUIDByName("SummonerClass")).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .SetIsClassFeature(true)
                .ConfigureWithLogging();
        }
    }
}
