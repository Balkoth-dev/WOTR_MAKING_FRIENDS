using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    internal class SummonerSpellbook
    {
        private static class InternalString
        {
            internal const string SummonerSpellbook = "SummonerSpellbook";
            internal static readonly LocalizedString SummonerSpellbookName = Helpers.ObtainString(SummonerSpellbook + ".Name");
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
            SpellsTableConfigurator.New(InternalString.SummonerSpellbookName + "SpellsPerDayTable", GetGUID.SummonerSpellbookSpellsPerDay)
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(0,1),
                        CreateSpellLevelEntry(0,2),
                        CreateSpellLevelEntry(0,3),
                        CreateSpellLevelEntry(0,3,1),
                        CreateSpellLevelEntry(0,4,2),
                        CreateSpellLevelEntry(0,4,3),
                        CreateSpellLevelEntry(0,4,3,1),
                        CreateSpellLevelEntry(0,4,4,2),
                        CreateSpellLevelEntry(0,5,4,3),
                        CreateSpellLevelEntry(0,5,4,3,1),
                        CreateSpellLevelEntry(0,5,4,4,2),
                        CreateSpellLevelEntry(0,5,5,4,3),
                        CreateSpellLevelEntry(0,5,5,4,3,1),
                        CreateSpellLevelEntry(0,5,5,4,4,2),
                        CreateSpellLevelEntry(0,5,5,5,4,3),
                        CreateSpellLevelEntry(0,5,5,5,4,3,1),
                        CreateSpellLevelEntry(0,5,5,5,4,4,2),
                        CreateSpellLevelEntry(0,5,5,5,5,4,3),
                        CreateSpellLevelEntry(0,5,5,5,5,5,4),
                        CreateSpellLevelEntry(0,5,5,5,5,5,5),
                })
                .Configure();
        }

        public static void ConfigureSpellsKnownTable()
        {
            SpellsTableConfigurator.New(InternalString.SummonerSpellbook + ".SpellKnownTable", GetGUID.SummonerSpellbookSpellsKnown)
                .SetLevels(new SpellsLevelEntry[] {
                        CreateSpellLevelEntry(4,2),
                        CreateSpellLevelEntry(5,3),
                        CreateSpellLevelEntry(6,4),
                        CreateSpellLevelEntry(6,4,2),
                        CreateSpellLevelEntry(6,4,3),
                        CreateSpellLevelEntry(6,4,4),
                        CreateSpellLevelEntry(6,5,4,2),
                        CreateSpellLevelEntry(6,5,4,3),
                        CreateSpellLevelEntry(6,5,4,4),
                        CreateSpellLevelEntry(6,5,5,4,2),
                        CreateSpellLevelEntry(6,6,5,4,3),
                        CreateSpellLevelEntry(6,6,5,4,4),
                        CreateSpellLevelEntry(6,6,5,5,4,2),
                        CreateSpellLevelEntry(6,6,6,5,4,3),
                        CreateSpellLevelEntry(6,6,6,5,4,4),
                        CreateSpellLevelEntry(6,6,6,5,5,4,2),
                        CreateSpellLevelEntry(6,6,6,6,5,4,3),
                        CreateSpellLevelEntry(6,6,6,6,5,4,4),
                        CreateSpellLevelEntry(6,6,6,6,5,5,4),
                        CreateSpellLevelEntry(6,6,6,6,6,5,5)
                    })
                .Configure();
        }

        public static SpellLevelList Create0thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(0);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.AcidSplash.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Daze.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Guidance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MageLight.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Resistance.ToString())
            };
            return spelllist;
        }
        public static SpellLevelList Create1stLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(1);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EnlargePerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ExpeditiousRetreat.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Grease.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MageArmor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MagicFang.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromAlignment.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ReducePerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MageShield.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Snowball.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterISingle.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create2ndLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(2);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Barkskin.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BearsEndurance.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Blur.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BullsStrength.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CatsGrace.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CreatePit.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EaglesSplendor.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Glitterdust.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Invisibility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.OwlsWisdom.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromArrows.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromAlignmentCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.RayOfSickening.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ResistEnergy.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SeeInvisibility.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterIIBase.ToString())
            };
            return spelllist;
        }
        public static SpellLevelList Create3rdLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(3);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DispelMagic.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Displacement.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Haste.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Heroism.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.MagicFangGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromArrowsCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromAlignmentCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromEnergy.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Rage.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ResistEnergyCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Slow.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SpikedPit.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.StinkingCloud.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterIVBase.ToString())
            };
            return spelllist;
        }
        public static SpellLevelList Create4thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(4);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.AcidPit.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DimensionDoorBase.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EnlargePersonMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.InvisibilityGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ObsidianFlow.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ProtectionFromEnergyCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ReducePersonMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Stoneskin.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterVBase.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.ElementalWallFireAbility.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create5thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(5);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BalefulPolymorph.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Cloudkill.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Dismissal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.DispelMagicGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Eaglesoul.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Geniekind.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HoldPerson.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HungryPit.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.StoneskinCommunal.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterVIBase.ToString()),
            };
            return spelllist;
        }
        public static SpellLevelList Create6thLevelSpells()
        {
            SpellLevelList spelllist = new SpellLevelList(6);
            spelllist.m_Spells = new()
            {
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.AcidFog.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.Banishment.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BearsEnduranceMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.BullsStrengthMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CatsGraceMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.CreepingDoom.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.EaglesSplendorMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.FoxsCunningMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.HeroismGreater.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.InvisibilityMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.OwlsWisdomMass.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.SummonMonsterVIIBase.ToString()),
                BlueprintTool.GetRef<BlueprintAbilityReference>(AbilityRefs.TrueSeeing.ToString()),
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
            SpellListConfigurator.New(InternalString.SummonerSpellbook + ".SpellList", GetGUID.SummonerSpellbookSpellList)
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
            return SpellbookConfigurator.New(InternalString.SummonerSpellbook, GetGUID.SummonerSpellbookSpellBook)
                .SetName(InternalString.SummonerSpellbookName)
                .SetCharacterClass(GetGUID.SummonerClass)
                .SetSpellsPerDay(GetGUID.SummonerSpellbookSpellsPerDay)
                .SetSpellsKnown(GetGUID.SummonerSpellbookSpellsKnown)
                .SetSpellList(GetGUID.SummonerSpellbookSpellList)
                .SetCastingAttribute(Kingmaker.EntitySystem.Stats.StatType.Charisma)
                .SetIsMythic(false)
                .SetSpontaneous(true)
                .SetIsArcane(true)
                .SetIsArcanist(false)
                .SetCanCopyScrolls(false)
                .SetAllSpellsKnown(false)
                .SetCasterLevelModifier(0)
                .Configure();
        }
    }
}
