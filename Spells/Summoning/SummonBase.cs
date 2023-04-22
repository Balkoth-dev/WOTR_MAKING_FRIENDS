using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    public static class SummonBase
    {

        public class SummonAbilityBase
        {
            /// <summary> GUID of the variant spell. </summary>
            internal string guid;
            /// <summary> Internal name of the ability </summary>
            internal string name;
            /// <summary> Duration that the player sees, shows on the ability. </summary>
            internal Duration localizationDuration;
            /// <summary> Action type used to for the ability. If IsFullRound true, it will use that instead. </summary>
            internal CommandType actionType = CommandType.Standard;
            /// <summary> Name of the ability that is shown to the player. </summary>
            internal LocalizedString m_DisplayName;
            /// <summary> Description of the ability that is shown to the player. </summary>
            internal LocalizedString m_Description;
            /// <summary> Icon of the ability that is shown to the player. </summary>
            internal Sprite m_icon;
            /// <summary>  IsFullRound true, it will use that instead of the action type. </summary>
            internal bool isFullRound;
            /// <summary> List of spell list components. This is grouped up because an ability can belong to multiple spell lists. </summary>
            internal Dictionary<string, int> spellListComponents;
        };

        public static SummonAbilityBase[] summonBaseAbilities =
            {
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterIBase"),
                    name = "SummonerSummonMonsterIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterISingle.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),1 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterIIBase"),
                    name = "SummonerSummonMonsterIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),2 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterIIIBase"),
                    name = "SummonerSummonMonsterIIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),3 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterIVBase"),
                    name = "SummonerSummonMonsterIVBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),4 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterVBase"),
                    name = "SummonerSummonMonsterVBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),5 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterVIBase"),
                    name = "SummonerSummonMonsterVIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),6 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterVIIBase"),
                    name = "SummonerSummonMonsterVIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),7 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterVIIIBase"),
                    name = "SummonerSummonMonsterVIIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),8 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonerSummonMonsterIXBase"),
                    name = "SummonerSummonMonsterIXBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_Icon,
                    spellListComponents = new() { {GetGUID.GUIDByName("SummonerSecondSpellbookSpellList"),9 } }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonMinorMonsterBase"),
                    name = "SummonMinorMonsterBase",
                    localizationDuration = Duration.RoundPerLevel,
                    isFullRound = true,
                    m_DisplayName = Helpers.ObtainString("summonminormonsterbase.name"),
                    m_Description = Helpers.ObtainString("summonminormonsterbase.description"),
                    m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon,
                    spellListComponents = new() {
                        { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.BardClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.ClericClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.OracleClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.SkaldClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.WarpriestClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 1 },
                        { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 1 },
                        { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 1 },
                    }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonDraconicAllyBase"),
                    name = "SummonDraconicAllyBase",
                    localizationDuration = Duration.RoundPerLevel,
                    isFullRound = true,
                    m_DisplayName = Helpers.ObtainString("SummonDraconicAllyBase.name"),
                    m_Description = Helpers.ObtainString("SummonDraconicAllyBase.description"),
                    m_icon = AbilityRefs.FormOfTheDragonI.Reference.Get().m_Icon,
                    spellListComponents = new() {
                        { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 3 },
                        { CharacterClassRefs.BloodragerClass.Reference.Guid.ToString(), 3 },
                        { CharacterClassRefs.PaladinClass.Reference.Guid.ToString(), 3 },
                        { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 3 },
                        { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 3 },
                        { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 3 },
                    }
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.GUIDByName("SummonLesserDemonBase"),
                    name = "SummonLesserDemonBase",
                    localizationDuration = Duration.RoundPerLevel,
                    isFullRound = true,
                    m_DisplayName = Helpers.ObtainString("SummonLesserDemonBase.name"),
                    m_Description = Helpers.ObtainString("SummonLesserDemonBase.description"),
                    m_icon = AbilityRefs.DemonicFormI.Reference.Get().m_Icon,
                    spellListComponents = new() {
                        { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.ClericClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.OracleClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.WarpriestClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 5 },
                        { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 5 },
                        { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 4 },
                    }
                }
            };
    }
}
