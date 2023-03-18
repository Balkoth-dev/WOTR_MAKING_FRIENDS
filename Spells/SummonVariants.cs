using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Mechanics;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Spells
{
    public static class SummonVariants
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
        };

        public static SummonAbilityBase[] summonBaseAbilities =
            {
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterIBase,
                    name = "SummonerSummonMonsterIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterISingle.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterIIBase,
                    name = "SummonerSummonMonsterIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIIBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterIIIBase,
                    name = "SummonerSummonMonsterIIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIIIBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterIVBase,
                    name = "SummonerSummonMonsterIVBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIVBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterVBase,
                    name = "SummonerSummonMonsterVBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterVIBase,
                    name = "SummonerSummonMonsterVIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterVIIBase,
                    name = "SummonerSummonMonsterVIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIIBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterVIIIBase,
                    name = "SummonerSummonMonsterVIIIBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterVIIIBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonerSummonMonsterIXBase,
                    name = "SummonerSummonMonsterIXBase",
                    localizationDuration = Duration.MinutePerLevel,
                    m_DisplayName = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_DisplayName,
                    m_Description = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_Description,
                    m_icon = AbilityRefs.SummonMonsterIXBase.Reference.Get().m_Icon
                },
                new SummonAbilityBase()
                {
                    guid = GetGUID.SummonMinorMonsterBase,
                    name = "SummonMinorMonsterBase",
                    localizationDuration = Duration.RoundPerLevel,
                    isFullRound = true,
                    m_DisplayName = Helpers.ObtainString("summonminormonsterbase.name"),
                    m_Description = Helpers.ObtainString("summonminormonsterbase.description"),
                    m_icon = AbilityRefs.SummonMonsterISingle.Reference.Get().m_Icon
                },
            };
    }
}
