using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Spells
{
    public class SpellBlackTentacles
    {
        private static class IClass
        {
            internal const string BlackTentaclesAreaEffectName = "BlackTentaclesAreaEffect";
            internal const string BlackTentaclesSpell = "BlackTentaclesSpell";
            internal static LocalizedString BlackTentaclesSpellName = Helpers.ObtainString("BlackTentaclesSpell.Name");
            internal static LocalizedString BlackTentaclesSpellDescription = Helpers.ObtainString("BlackTentaclesSpell.Description");
        }
        internal static BlueprintBuffReference blackTentaclesBuff = BlueprintTool.Get<BlueprintBuff>(GetGUID.GUIDByName("BlackTentaclesBuff")).ToReference<BlueprintBuffReference>();

        private static Dictionary<string, int> spellListComponents = new()
        {
            { CharacterClassRefs.ArcanistClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.BloodragerClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.MagusClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.SorcererClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.WitchClass.Reference.Guid.ToString(), 4 },
            { CharacterClassRefs.WizardClass.Reference.Guid.ToString(), 4 },
            { GetGUID.GUIDByName("SummonerSpellbookSpellList"), 4 }
        };
        public static void CreateBlackTentaclesSpell()
        {
            string sourceFx = "aa448b28b377b1c49b136d88fa346600";
            string newFx = GetGUID.GUIDByName("BlackTentaclesFx");

            AssetTool.RegisterDynamicPrefabLink(newFx, sourceFx, BlackTentaclesFx);

            ActionList grappleAction = ActionsBuilder.New()
                .ApplyBuffPermanent(blackTentaclesBuff)
                .Build();

            grappleAction.Actions = new GameAction[] {
                new BlackTentaclesGrappleAction {
                    Bonus = 5,
                    Success = ActionsBuilder.New()
                                    .Conditional(ConditionsBuilder.New()
                                                .HasBuff(blackTentaclesBuff),
                                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(buff: blackTentaclesBuff).Build()).Build(),
                    Failure = ActionsBuilder.New().RemoveBuff(buff: blackTentaclesBuff).Build(),
                    Value = ContextValues.Rank()
                    }
            };

            BlueprintAbilityAreaEffect areaEffect = AbilityAreaEffectConfigurator.New(IClass.BlackTentaclesAreaEffectName, GetGUID.GUIDByName("BlackTentaclesAreaEffect"))
              .SetAffectEnemies()
              .SetAggroEnemies()
              .SetSize(20.Feet())
              .AddContextRankConfig(ContextRankConfigs.CasterLevel())
              .AddAbilityAreaEffectRunAction(
                                unitEnter: grappleAction,
                                round: grappleAction,
                                unitExit: ActionsBuilder.New()
                                            .RemoveBuff(buff: blackTentaclesBuff)
                                            .RemoveBuff(BuffRefs.EntangleBuffDifficultTerrain.Cast<BlueprintBuffReference>().Reference)
                                            .Build())
              .SetShape(AreaEffectShape.Cylinder)
              .SetFx(newFx)
              .ConfigureWithLogging();

            AbilityConfigurator blackTentaclesSpell = AbilityConfigurator.New(IClass.BlackTentaclesSpell, GetGUID.GUIDByName("BlackTentaclesSpell"))
                .CopyFrom(AbilityRefs.SickeningEntanglement, c => c is not (AbilityEffectRunAction or AbilityAoERadius))
                .SetDisplayName(IClass.BlackTentaclesSpellName)
                .SetDescription(IClass.BlackTentaclesSpellDescription)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "BlackTentacles.png"))
                .AddAbilityEffectRunAction(actions: ActionsBuilder.New()
                                                    .SpawnAreaEffect(areaEffect: areaEffect,
                                                                     durationValue: ContextDuration.Variable(ContextValues.Rank())))
                .AddAbilityAoERadius(radius: 20.Feet());

            if (spellListComponents != null)
            {
                foreach (KeyValuePair<string, int> spellList in spellListComponents)
                {
                    blackTentaclesSpell.AddToSpellList(spellList.Value, BlueprintTool.GetRef<BlueprintSpellListReference>(spellList.Key), true);
                }
            }

            blackTentaclesSpell.ConfigureWithLogging();

        }
        private static void BlackTentaclesFx(GameObject gameObject)
        {
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_StinkingSmoke00").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_StinkingSmoke00_RotatableCopy").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_GrassLiana00_RotatableCopy").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_GrassLianaSingle00_RotatableCopy").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_GrassLiana00").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_GrassLianaSingle00").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_FireFliesGreen").gameObject);
            UnityEngine.Object.DestroyImmediate(gameObject.transform.Find("AnimationRoot/WaveAll_FireFliesViolet").gameObject);
            gameObject.transform.localScale = new(0.25f, 1.0f, 0.25f);
        }
    }
}
