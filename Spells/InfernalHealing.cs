using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    class InfernalHealing
    {
        private static class InternalString
        {
            internal const string InfernalHealingSpellName = "InfernalHealingSpell";
            internal static LocalizedString InfernalHealingNameSpellName = Helpers.ObtainString(InfernalHealingSpellName + ".Name");
            internal static LocalizedString InfernalHealingNameSpellDescription = Helpers.ObtainString(InfernalHealingSpellName + ".Description");
            internal const string GreaterInfernalHealingSpellName = "GreaterInfernalHealingSpell";
            internal static LocalizedString GreaterInfernalHealingNameSpellName = Helpers.ObtainString(GreaterInfernalHealingSpellName + ".Name");
            internal static LocalizedString GreaterInfernalHealingNameSpellDescription = Helpers.ObtainString(GreaterInfernalHealingSpellName + ".Description");
        }

        private static Dictionary<string, int> infernalHealingSpellListComponents = new()
        {
            { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.BloodragerClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.ClericClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.MagusClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.OracleClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.WarpriestClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 1 },
            { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 1 },
            { GetGUID.SummonerSpellbookSpellList, 1 }
        };
        private static Dictionary<string, int> greaterInfernalHealingSpellListComponents = new()
        {
            { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.ClericClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.MagusClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.OracleClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.WarpriestClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 4 },
            { GetGUID.SummonerSpellbookSpellList, 4 }
        };
        public static void CreateInfernalHealing()
        {
            var spell = AbilityConfigurator.New(InternalString.InfernalHealingSpellName, GetGUID.InfernalHealingSpell)
                .CopyFrom(AbilityRefs.CureLightWounds)
                .SetDisplayName(InternalString.InfernalHealingNameSpellName)
                .SetDescription(InternalString.InfernalHealingNameSpellDescription)
                .AddActionsOnBuffApply(
                ActionsBuilder.New()
                .ApplyBuffWithDurationSeconds(BuffRefs.FastHealing1.Cast<BlueprintBuffReference>().Reference, 60)
                .Build()
            );

            if (infernalHealingSpellListComponents != null)
            {
                foreach (var spellList in infernalHealingSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.Configure();
        }
        public static void CreateGreaterInfernalHealing()
        {
            var spell = AbilityConfigurator.New(InternalString.GreaterInfernalHealingSpellName, GetGUID.GreaterInfernalHealingSpell)
                .CopyFrom(AbilityRefs.CureLightWounds)
                .SetDisplayName(InternalString.GreaterInfernalHealingNameSpellName)
                .SetDescription(InternalString.GreaterInfernalHealingNameSpellDescription)
                .AddActionsOnBuffApply(
                ActionsBuilder.New()
                .ApplyBuffWithDurationSeconds(BuffRefs.FastHealing4.Cast<BlueprintBuffReference>().Reference, 60)
                .Build()
            );

            if (greaterInfernalHealingSpellListComponents != null)
            {
                foreach (var spellList in greaterInfernalHealingSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.Configure();
        }

    }
}
