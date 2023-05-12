using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections;
using System;
using System.Collections.Generic;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Spells.Summoning
{
    internal class SpellTransmogrify
    {
        internal static class IClass
        {
            internal const string Spell = "TransmogrifySpell";
            internal static LocalizedString Name = Helpers.ObtainString(Spell + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Spell + ".Description");
            internal static string Guid = GetGUID.GUIDByName(Spell);
            internal const string EvolutionSizeChange = "EvolutionSizeChange";
        }

        private static Dictionary<string, int> spellListComponents = new()
        {
            { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 4 }
        };

        internal static BlueprintFeatureReference[] originalBlueprintUnitFactReferences = new BlueprintFeatureReference[Enum.GetValues(typeof(Size)).Length+1];
        internal static BlueprintFeatureReference[] newBlueprintUnitFactReferences = new BlueprintFeatureReference[Enum.GetValues(typeof(Size)).Length + 1];
        public static void Create()
        {
            int arrayInt = 0;
            foreach (Size enumValue in System.Enum.GetValues(typeof(Size)))
            {
                try
                {
                    var eidolonOriginalFeatureName = IClass.EvolutionSizeChange + System.Enum.GetName(typeof(Size), enumValue) + "OriginalFeature";
                    var eidolonFeatureName = IClass.EvolutionSizeChange + System.Enum.GetName(typeof(Size), enumValue) + "Feature";
                    originalBlueprintUnitFactReferences[arrayInt] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(eidolonOriginalFeatureName));
                    newBlueprintUnitFactReferences[arrayInt] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(eidolonFeatureName));
                    arrayInt++;

                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }

            originalBlueprintUnitFactReferences[arrayInt] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionLimbsArmsBaseFeature"));
            newBlueprintUnitFactReferences[arrayInt] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionLimbsArmsFeature"));

            AbilityConfigurator spell = AbilityConfigurator.New(IClass.Spell, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "Transmogrify.png"))
                .SetCanTargetFriends(true)
                .SetCanTargetSelf(true)
                .SetRange(AbilityRange.Touch)
                .AddSpellComponent(Kingmaker.Blueprints.Classes.Spells.SpellSchool.Transmutation)
                .AddPureRecommendation(priority:Kingmaker.Designers.Mechanics.Recommendations.RecommendationPriority.Good)
                
                .AddAbilityEffectRunAction(
                ActionsBuilder.New().Add<RemoveFactWithGroup>(c => { c.featureGroup = FeatureGroupExtension.EvolutionTransmogrifiable; c.affectCaster = true; })
                                    .Add<AddFactsOnArray>(c => { c.originalBlueprints = originalBlueprintUnitFactReferences; c.newBlueprints = newBlueprintUnitFactReferences; c.affectCaster = true; })
                                    .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")), 99)
                                    .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")), 99)
                .Build()
            );

            if (spellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in spellListComponents)
                {
                    spell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }
            spell.ConfigureWithLogging();
        }

    }
}
