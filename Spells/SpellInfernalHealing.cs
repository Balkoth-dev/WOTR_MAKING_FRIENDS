using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using System.Collections.Generic;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    internal class SpellInfernalHealing
    {
        internal static class IClass
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
            { SpellListRefs.WizardSpellList.Reference.Guid.ToString(), 1 },
            { SpellListRefs.BloodragerSpellList.Reference.Guid.ToString(), 1 },
            { SpellListRefs.ClericSpellList.Reference.Guid.ToString(), 1 },
            { SpellListRefs.MagusSpellList.Reference.Guid.ToString(), 1 },
            { SpellListRefs.WarpriestSpelllist.Reference.Guid.ToString(), 1 },
            { SpellListRefs.WitchSpellList.Reference.Guid.ToString(), 1 },
            { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 1 }
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
            { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 4 }
        };
        public static void CreateInfernalHealing()
        {
            AbilityConfigurator spell = AbilityConfigurator.New(IClass.InfernalHealingSpellName, GetGUID.GUIDByName("InfernalHealingSpell"))
                .CopyFrom(AbilityRefs.CureLightWounds)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "InfernalHealing.png"))
                .SetDisplayName(IClass.InfernalHealingNameSpellName)
                .SetDescription(IClass.InfernalHealingNameSpellDescription)
                .AddSpellComponent(SpellSchool.Conjuration)
                .AddAbilityEffectRunAction(
                ActionsBuilder.New()
                .ApplyBuffWithDurationSeconds(BuffRefs.FastHealing1.Cast<BlueprintBuffReference>().Reference, 60)
                .Build()
            );

            if (infernalHealingSpellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in infernalHealingSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.ConfigureWithLogging();
        }
        public static void CreateGreaterInfernalHealing()
        {
            AbilityConfigurator spell = AbilityConfigurator.New(IClass.GreaterInfernalHealingSpellName, GetGUID.GUIDByName("GreaterInfernalHealingSpell"))
                .CopyFrom(AbilityRefs.CureLightWounds)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "InfernalHealingGreater.png"))
                .SetDisplayName(IClass.GreaterInfernalHealingNameSpellName)
                .SetDescription(IClass.GreaterInfernalHealingNameSpellDescription)
                .AddSpellComponent(SpellSchool.Conjuration)
                .AddAbilityEffectRunAction(
                ActionsBuilder.New()
                .ApplyBuffWithDurationSeconds(BuffRefs.FastHealing4.Cast<BlueprintBuffReference>().Reference, 60)
                .Build()
            );

            if (greaterInfernalHealingSpellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in greaterInfernalHealingSpellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.ConfigureWithLogging();
        }

    }
}
