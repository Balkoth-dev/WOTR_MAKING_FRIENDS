using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Mechanics;
using System.Collections.Generic;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    internal class SpellOverstimulate
    {
        internal static class IClass
        {
            internal const string OverstimulateSpell = "OverstimulateSpell";
            internal static LocalizedString OverstimulateSpellName = Helpers.ObtainString(OverstimulateSpell + ".Name");
            internal static LocalizedString OverstimulateSpellDescription = Helpers.ObtainString(OverstimulateSpell + ".Description");
        }
        internal static BlueprintBuffReference overstimulateBuff = BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.GUIDByName("OverstimulateBuff"));

        private static Dictionary<string, int> overstimulateSpellListComponents = new()
        {
            { SpellListRefs.AlchemistSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.BardSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.BloodragerSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.ClericSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.DruidSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.HunterSpelllist.Reference.Guid.ToString(), 2 },
            { SpellListRefs.RangerSpellList.Reference.Guid.ToString(), 2 },
            { SpellListRefs.ShamanSpelllist.Reference.Guid.ToString(), 2 },
            { SpellListRefs.WarpriestSpelllist.Reference.Guid.ToString(), 2 },
            { SpellListRefs.WitchSpellList.Reference.Guid.ToString(), 2 }, 
            { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 2 }
        };
        public static void CreateOverstimulate()
        {
            AbilityConfigurator spell = AbilityConfigurator.New(IClass.OverstimulateSpell, GetGUID.GUIDByName("OverstimulateSpell"))
                .CopyFrom(AbilityRefs.Rage)
                .AddContextRankConfig(ContextRankConfigs.CasterLevel())
                .SetDisplayName(IClass.OverstimulateSpellName)
                .SetDescription(IClass.OverstimulateSpellDescription)
                .AddSpellComponent(SpellSchool.Transmutation)
                .AddAbilityEffectRunAction(
                ActionsBuilder.New()
                .ApplyBuff(overstimulateBuff, ContextDuration.Variable(ContextValues.Rank(), DurationRate.Rounds, true))
                .Build()
            );

            if (overstimulateSpellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in overstimulateSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.ConfigureWithLogging();
        }

    }
}
