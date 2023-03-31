﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    class Overstimulate
    {
        private static class InternalString
        {
            internal const string OverstimulateSpell = "OverstimulateSpell";
            internal static LocalizedString OverstimulateSpellName = Helpers.ObtainString(OverstimulateSpell + ".Name");
            internal static LocalizedString OverstimulateSpellDescription = Helpers.ObtainString(OverstimulateSpell + ".Description");
        }
        internal static BlueprintBuffReference overstimulateBuff = BlueprintTool.Get<BlueprintBuff>(GetGUID.OverstimulateBuff).ToReference<BlueprintBuffReference>();

        private static Dictionary<string, int> overstimulateSpellListComponents = new()
        {
            { CharacterClassRefs.AlchemistClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.BardClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.BloodragerClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.ClericClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.DruidClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.HunterClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.OracleClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.RangerClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.ShamanClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.SkaldClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.WarpriestClass.Reference.Guid.ToString(), 2 },
            { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 2 },
            { GetGUID.SummonerSpellbookSpellList, 2 }
        };
        public static void CreateOverstimulate()
        {
            var spell = AbilityConfigurator.New(InternalString.OverstimulateSpell, GetGUID.OverstimulateSpell)
                .CopyFrom(AbilityRefs.Rage, c => c is null)
                .AddContextRankConfig(ContextRankConfigs.CasterLevel())
                .AddAbilityEffectRunAction(
                ActionsBuilder.New()
                .ApplyBuff(overstimulateBuff,ContextDuration.Variable(ContextValues.Rank(),DurationRate.Rounds,true))
                .Build()
            );

            if (overstimulateSpellListComponents != null)
            {
                foreach (var spellList in overstimulateSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.Configure();
        }

    }
}