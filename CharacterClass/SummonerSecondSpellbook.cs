using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Spells;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    class SummonerSecondSpellbook
    {
        private static class InternalString
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
            var entry = new SpellsLevelEntry
            {
                Count = count
            };
            return entry;
        }

        public static void ConfigureSpellSlotsTable()
        {
            SpellsTableConfigurator.New(InternalString.SummonMonsterSpellbookName + "SpellsPerDayTable", GetGUID.SummonerSecondSpellbookSpellsPerDay)
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
                .Configure();
        }

        public static void ConfigureSpellsKnownTable()
        {
            SpellsTableConfigurator.New(InternalString.SummonMonsterSpellbook + ".SpellKnownTable", GetGUID.SummonerSecondSpellbookSpellsKnown)
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
                .Configure();
        }

        public static SpellLevelList Create0thLevelSpells()
        {
            var spelllist = new SpellLevelList(0);
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
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterIBase),
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonMinorMonsterBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create2ndLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(2);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterIIBase),
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonCacodaemon),
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonSwarm)
            };
            return spelllist;
        }
        public static SpellLevelList Create3rdLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(3);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterIIIBase),
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonDraconicAllyBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create4thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterIVBase),
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonCacodaemonGreater)
            };
            return spelllist;
        }
        public static SpellLevelList Create5thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(5);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterVBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create6thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(6);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterVIBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create7thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(7);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterVIIBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create8thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(8);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterVIIIBase)
            };
            return spelllist;
        }
        public static SpellLevelList Create9thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(9);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.SummonerSummonMonsterIXBase)
            };
            return spelllist;
        }


        public static void CreateSpellList()
        {
            SpellListConfigurator.New(InternalString.SummonMonsterSpellbook + ".SpellList", GetGUID.SummonerSecondSpellbookSpellList)
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
                .Configure();
        }

        public static BlueprintSpellbook CreateSpellBook()
        {
            ConfigureSpellSlotsTable();
            ConfigureSpellsKnownTable();
            CreateSpellList();
            return SpellbookConfigurator.New(InternalString.SummonMonsterSpellbook, GetGUID.SummonerSecondSpellbookSpellBook)
                .SetName(InternalString.SummonMonsterSpellbookName)
                .SetCharacterClass(GetGUID.SummonerClass)
                .SetSpellsPerDay(GetGUID.SummonerSecondSpellbookSpellsPerDay)
                .SetSpellsKnown(GetGUID.SummonerSecondSpellbookSpellsKnown)
                .SetSpellList(GetGUID.SummonerSecondSpellbookSpellList)
                .SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetIsArcane(false)
                .SetIsArcanist(false)
                .SetCanCopyScrolls(false)
                .SetAllSpellsKnown(true)
                .SetCasterLevelModifier(0)
                .Configure();
        }

        public static BlueprintFeature Initialize()
        {
            CreateSpellBook();

            return FeatureConfigurator.New(InternalString.SummonMonsterSpellbookFeat, GetGUID.SummonerSecondSpellbookFeat)
                .SetDisplayName(InternalString.SummonMonsterSpellbookFeatName)
                .SetDescription(InternalString.SummonMonsterSpellbookFeatDescription)
                .AddSpellbook(ContextValues.Rank(), spellbook: GetGUID.SummonerSecondSpellbookSpellBook)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(GetGUID.SummonerClass).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
