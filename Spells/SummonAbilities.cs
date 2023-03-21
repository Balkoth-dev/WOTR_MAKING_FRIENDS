using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Spells
{
	public static class SummonAbilities
	{
		public class SummonAbility
		{
			/// <summary> GUID of the summon spell. </summary>
			internal string guid;
			/// <summary> Internal name of the ability </summary>
			internal string name;
			/// <summary> Guid of the spell that holds this variant, if any. </summary>
			internal string summonSpellBaseGuid;
			/// <summary>  IsFullRound true, it will use that instead of the action type. </summary>
			internal bool isFullRound;
			/// <summary>  Adds a crafting component to the spell. Defaulted to true, turn to false if creating an ability instead. </summary>
			internal bool craftingComponent = true;
			/// <summary> By default, summons use the Evil monster, this needs to be filled while the good monster does not. </summary>
			internal BlueprintUnitReference defaultMonster;
			/// <summary> Optional summon if a summon has a variant based on the alignment of the caster. Do not set if you only want the spell to summon a specific monster. </summary>
			internal BlueprintUnitReference goodMonster;
			/// <summary> Summon pool used by the ability. Various uses, mainly used for when the ability only has one summon at a time. </summary>
			internal BlueprintSummonPoolReference summonPool;
			/// <summary> The default summon buff. As far as I can tell it's used for the effects cast when they are summoned. </summary>
			internal BlueprintBuffReference[] summonBuff;
			/// <summary> Adds additional unit facts to the summon. In example the breath attacks for Draconic Ally. </summary>
			internal Blueprint<BlueprintUnitFactReference>[] blueprintUnitFactReferences;
			/// <summary> If the user is good/neutral, this adds another buff. Usually used for adding the celestial template. </summary>
			internal BlueprintBuffReference goodBuff;
			/// <summary> If the user is evil, this adds another buff. Usually used for adding the fiendish template. </summary>
			internal BlueprintBuffReference evilBuff;
			/// <summary> List of spell list components. This is grouped up because an ability can belong to multiple spell lists. </summary>
			internal Dictionary<string, int> spellListComponents;
			/// <summary> DiceType that determines the amount of summons. </summary>
			internal DiceType numberOfSummons;
			/// <summary> Number of bonus summons. Such as for spells that summon 1d4+1 monsters. </summary>
			internal int numberOfBonusSummons;
			/// <summary> DurationRate used to determined how many rounds/minutes/etc. are used per context rate. </summary>
			internal DurationRate durationRate;
			/// <summary> Duration that the player sees, shows on the ability. </summary>
			internal Duration localizationDuration;
			/// <summary> Action type used to for the ability. If IsFullRound true, it will use that instead. </summary>
			internal CommandType actionType;
			/// <summary> Name of the ability that is shown to the player. </summary>
			internal LocalizedString m_DisplayName;
			/// <summary> Description of the ability that is shown to the player. </summary>
			internal LocalizedString m_Description;
			/// <summary> Icon of the ability that is shown to the player. </summary>
			internal Sprite m_icon;
			/// <summary> Context Rank Config that will determine what the summon's duration is based off of.</summary>
			internal ContextRankConfig contextRankConfig;
			/// <summary> Material Component </summary>
			internal BlueprintAbility.MaterialComponentData materialComponent;

			public SummonAbility()
			{
				goodBuff = BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.DummyBuff);
				evilBuff = BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.DummyBuff);
				localizationDuration = Duration.RoundPerLevel;
			}

		};

		public static SummonAbility[] summonAbilities =
		{
			new SummonAbility
			{
				name = "SummonerSummonISingle",
				guid = GetGUID.SummonerSummonISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIBase,
				defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Description,
				actionType = CommandType.Standard,
				m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 1 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIISingle",
				guid = GetGUID.SummonerSummonIISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIBase,
				defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 2 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIId3",
				guid = GetGUID.SummonerSummonIId3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIBase,
				defaultMonster = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIId3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIId3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIId3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 2 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIIISingle",
				guid = GetGUID.SummonerSummonIIISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIIBase,
				defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIIISingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 3 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIIId3",
				guid = GetGUID.SummonerSummonIIId3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIIIBase,
				defaultMonster = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIIId3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 3 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIVSingle",
				guid = GetGUID.SummonerSummonIVSingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIVBase,
				defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 4 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIVd3",
				guid = GetGUID.SummonerSummonIVd3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIVBase,
				defaultMonster = UnitRefs.MonitorLizardSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIVd3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 4 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVSingle",
				guid = GetGUID.SummonerSummonVSingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVBase,
				defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVSingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 5 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVd3",
				guid = GetGUID.SummonerSummonVd3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVBase,
				defaultMonster = UnitRefs.DireWolfSummon.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVd3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVd3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVd3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 5 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVISingle",
				guid = GetGUID.SummonerSummonVISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIBase,
				defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVISingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 6 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVId3",
				guid = GetGUID.SummonerSummonVId3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIBase,
				defaultMonster = UnitRefs.RedcapSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.AzataBralaniSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyIV_VI.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVId3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVId3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVId3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 6 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVIISingle",
				guid = GetGUID.SummonerSummonVIISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIBase,
				defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				m_DisplayName = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVIISingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 7 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVIId3",
				guid = GetGUID.SummonerSummonVIId3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIBase,
				defaultMonster = UnitRefs.SoulEaterSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.AxiomiteSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVIId3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 7 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVIIISingle",
				guid = GetGUID.SummonerSummonVIIISingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIIBase,
				defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVIIISingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 8 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonVIIId3",
				guid = GetGUID.SummonerSummonVIIId3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterVIIIBase,
				defaultMonster = UnitRefs.BogeymanSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = null,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				m_DisplayName = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterVIIId3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 8 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIXSingle",
				guid = GetGUID.SummonerSummonIXSingle,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIXBase,
				defaultMonster = UnitRefs.ThanadaemonSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.AzataGhaelSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffII.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIXSingle.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 9 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonerSummonIXd3",
				guid = GetGUID.SummonerSummonIXd3,
				summonSpellBaseGuid = GetGUID.SummonerSummonMonsterIXBase,
				defaultMonster = UnitRefs.FrostGiantSummoned.Cast<BlueprintUnitReference>().Reference,
				goodMonster = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnAllyVI_IX.Cast<BlueprintBuffReference>().Reference },
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.SummonerPool),
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Minutes,
				localizationDuration = Duration.MinutePerLevel,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffII.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_DisplayName,
				m_Description = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_Description,
				m_icon = AbilityRefs.SummonMonsterIXd3.Reference.Get().m_Icon,
				actionType = CommandType.Standard,
				spellListComponents = new() { {GetGUID.SummonerSecondSpellbookSpellList, 9 } },
				contextRankConfig = ContextRankConfigs.ClassLevel(classes: new string[]{ GetGUID.SummonerClass }),
				craftingComponent = false
			},
			new SummonAbility
			{
				name = "SummonMinorMonsterRedPanda",
				guid = GetGUID.SummonMinorMonsterRedPanda,
				summonSpellBaseGuid = GetGUID.SummonMinorMonsterBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.RedPandaSummon),
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = Helpers.ObtainString("summonminormonsterredpanda.Name"),
				m_Description = Helpers.ObtainString("summonminormonsterredpanda.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonMinorMonsterCat",
				guid = GetGUID.SummonMinorMonsterCat,
				summonSpellBaseGuid = GetGUID.SummonMinorMonsterBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.CatSummon),
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				goodBuff = BuffRefs.SummonMonsterCelestialBuffI.Cast<BlueprintBuffReference>().Reference,
				evilBuff = BuffRefs.SummonMonsterFiendishBuffI.Cast<BlueprintBuffReference>().Reference,
				m_DisplayName = Helpers.ObtainString("SummonMinorMonsterCat.Name"),
				m_Description = Helpers.ObtainString("SummonMinorMonsterCat.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonCacodaemon",
				guid = GetGUID.SummonCacodaemon,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.CacodaemonSummon),
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonCacodaemon.Name"),
				m_Description = Helpers.ObtainString("SummonCacodaemon.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonCacodaemonGreater",
				guid = GetGUID.SummonCacodaemonGreater,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.CacodaemonSummon),
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference },
				numberOfSummons = DiceType.D4,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonCacodaemonGreater.Name"),
				m_Description = Helpers.ObtainString("SummonCacodaemonGreater.Description"),
				actionType = CommandType.Standard,
				numberOfBonusSummons = 1,
				isFullRound = true,
				m_icon = AbilityRefs.SummonMonsterIVSingle.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonSwarm",
				guid = GetGUID.SummonSwarm,
				defaultMonster = UnitRefs.CR1_SpiderSwarm.Cast<BlueprintUnitReference>().Reference,
				summonBuff = new BlueprintBuffReference[]{ BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference },
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonSwarm.Name"),
				m_Description = Helpers.ObtainString("SummonSwarm.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.SummonMonsterIISingle.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyBlack",
				guid = GetGUID.SummonDraconicAllyBlack,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonBlack),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIBlackBuff.Cast<BlueprintBuffReference>().Reference
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyBlack.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyBlack.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIBlack.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyBlue",
				guid = GetGUID.SummonDraconicAllyBlue,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonBlue),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIBlueBuff.Cast<BlueprintBuffReference>().Reference,
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyBlue.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyBlue.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIBlue.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyBrass",
				guid = GetGUID.SummonDraconicAllyBrass,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonBrass),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIBrassBuff.Cast<BlueprintBuffReference>().Reference
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyBrass.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyBrass.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIBrass.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyGreen",
				guid = GetGUID.SummonDraconicAllyGreen,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonGreen),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIGreenBuff.Cast<BlueprintBuffReference>().Reference
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyGreen.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyGreen.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIGreen.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyRed",
				guid = GetGUID.SummonDraconicAllyRed,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonRed),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIRedBuff.Cast<BlueprintBuffReference>().Reference
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyRed.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyRed.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIRed.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllySilver",
				guid = GetGUID.SummonDraconicAllySilver,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonSilver),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonISilverBuff.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonISilverBreathWeaponBuff.Cast<BlueprintBuffReference>().Reference,
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllySilver.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllySilver.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonISilver.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonDraconicAllyWhite",
				guid = GetGUID.SummonDraconicAllyWhite,
				summonSpellBaseGuid = GetGUID.SummonDraconicAllyBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.DraconicAllySummonWhite),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterI_III.Cast<BlueprintBuffReference>().Reference,
					BuffRefs.FormOfTheDragonIWhiteBuff.Cast<BlueprintBuffReference>().Reference
				},
				summonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(GetGUID.DraconicAllyPool),
				blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[] { AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference },
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.TenMinutes,
				localizationDuration = Duration.TenMinutesPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonDraconicAllyWhite.Name"),
				m_Description = Helpers.ObtainString("SummonDraconicAllyWhite.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.FormOfTheDragonIWhite.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel(),
				materialComponent = new BlueprintAbility.MaterialComponentData(){ m_Item = ItemRefs.DiamondDust.Cast<BlueprintItemReference>().Reference, Count = 5}
			},
			new SummonAbility
			{
				name = "SummonLesserDemonBrimorak",
				guid = GetGUID.SummonLesserDemonBrimorak,
				summonSpellBaseGuid = GetGUID.SummonLesserDemonBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.LesserDemonSummonBrimorak),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonLesserDemonBrimorak.Name"),
				m_Description = Helpers.ObtainString("SummonLesserDemonBrimorak.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.DemonicFormIBrimorak.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonLesserDemonIncubus",
				guid = GetGUID.SummonLesserDemonIncubus,
				summonSpellBaseGuid = GetGUID.SummonLesserDemonBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.LesserDemonSummonIncubus),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonLesserDemonIncubus.Name"),
				m_Description = Helpers.ObtainString("SummonLesserDemonIncubus.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.DemonicFormIBabau.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonLesserDemonSchir",
				guid = GetGUID.SummonLesserDemonSchir,
				summonSpellBaseGuid = GetGUID.SummonLesserDemonBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.LesserDemonSummonSchir),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.D3,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonLesserDemonSchir.Name"),
				m_Description = Helpers.ObtainString("SummonLesserDemonSchir.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.DemonicFormISchir.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonLesserDemonVermlek",
				guid = GetGUID.SummonLesserDemonVermlek,
				summonSpellBaseGuid = GetGUID.SummonLesserDemonBase,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.LesserDemonSummonVermlek),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.D4,
				numberOfBonusSummons = 1,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonLesserDemonVermlek.Name"),
				m_Description = Helpers.ObtainString("SummonLesserDemonVermlek.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.DemonicFormIIDerakni.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonStampede",
				guid = GetGUID.SummonStampede,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.StampedeSummonHorse),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.D4,
				numberOfBonusSummons = 4,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonStampede.Name"),
				m_Description = Helpers.ObtainString("SummonStampede.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.MountTargetAbility.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonReleaseTheHounds",
				guid = GetGUID.SummonReleaseTheHounds,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.ReleaseTheHoundsWolf),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.D4,
				numberOfBonusSummons = 4,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonReleaseTheHounds.Name"),
				m_Description = Helpers.ObtainString("SummonReleaseTheHounds.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.BalefulPolymorph.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
			new SummonAbility
			{
				name = "SummonErinyes",
				guid = GetGUID.SummonErinyes,
				defaultMonster = BlueprintTool.GetRef<BlueprintUnitReference>(GetGUID.ErinyesSummon),
				summonBuff = new BlueprintBuffReference[]{
					BuffRefs.SummonedCreatureSpawnMonsterIV_VI.Cast<BlueprintBuffReference>().Reference
				},
				numberOfSummons = DiceType.One,
				durationRate = DurationRate.Rounds,
				localizationDuration = Duration.RoundPerLevel,
				m_DisplayName = Helpers.ObtainString("SummonErinyes.Name"),
				m_Description = Helpers.ObtainString("SummonErinyes.Description"),
				actionType = CommandType.Standard,
				isFullRound = true,
				m_icon = AbilityRefs.HellsDecreeAbilityMagicConjuration.Reference.Get().m_Icon,
				spellListComponents = new() { },
				contextRankConfig = ContextRankConfigs.CasterLevel()
			},
		};
	}
}
