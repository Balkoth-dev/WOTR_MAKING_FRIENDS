using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    internal class FeatureCreateAllEvolutions
    {
        public static void Create()
        {
            CreateAllEvolutions();
            CreateAllEvolutionBaseAbilities();
            CreateAddBaseAbiltiesFeature();
            AdjustEvolutions.Adjust();
            CreateAllBaseEvolutions();
        }
        internal static void CreateAllEvolutions()
        {
            var amount = 0;
            foreach (var level in Evolutions)
            {
                amount++;

                FeatureConfigurator.New("EvolutionCost" + amount + "Feature", GetGUID.GUIDByName("EvolutionCost" + amount + "Feature"))
                        .SetDisplayName(Helpers.ObtainString("EvolutionCost" + amount + "Feature" + ".Name"))
                        .SetDescription(Helpers.ObtainString("EvolutionCost" + amount + "Feature" + ".Description"))
                        .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                        .SetRanks(100)
                        .SetGroups(FeatureGroupExtension.EvolutionTransmogrifiable)
                        .AddIncreaseResourceAmount(GetGUID.GUIDByName("SummonerEvolutionPointsResource"), -amount)
                        .ConfigureWithLogging();

                foreach (var evolution in level.Value)
                {
                    var featureAction = ActionsBuilder.New().RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")), 99)
                                                     .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")), 99)
                                                     .Build();

                    var featureName = evolution + "Feature";
                    FeatureConfigurator.New(featureName, GetGUID.GUIDByName(featureName))
                        .SetDisplayName(Helpers.ObtainString(featureName + ".Name"))
                        .SetDescription(Helpers.ObtainString(featureName + ".Description"))
                        .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                        .SetRanks(1)
                        .SetGroups(FeatureGroupExtension.EvolutionTransmogrifiable)
                        .AddActionsOnBuffApply(actions: featureAction)
                        .ConfigureWithLogging();

                    var abilityAction = ActionsBuilder.New().AddFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(featureName)))
                                                     .AddFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionCost" + amount + "Feature")))
                                                     .Add<AddContextFeatureToPet>(c =>
                                                     {
                                                         c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionCost" + amount + "Feature"));
                                                         c.m_ReplaceFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EvolutionCost" + Math.Max(1, Math.Ceiling((double)amount / 2)) + "Feature"));
                                                         c.m_HasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("SummonerAspectGreaterFeature"));
                                                     })
                                                     .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")), 99)
                                                     .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")), 99)
                                                     .Add<ContextRestoreResourceOnPets>(c => { c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")); c.m_IsFullRestoreAllResources = true; })
                                                     .Add<ContextRestoreResourceOnPets>(c => { c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")); c.m_IsFullRestoreAllResources = true; })
                                                     .Build();

                    var abilityName = evolution + "Ability";
                    AbilityConfigurator.New(abilityName, GetGUID.GUIDByName(abilityName))
                        .SetDisplayName(Helpers.ObtainString(featureName + ".Name"))
                        .SetDescription(Helpers.ObtainString(featureName + ".Description"))
                        .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon)
                        .SetType(AbilityType.Special)
                        .SetRange(AbilityRange.Personal)
                        .SetActionType(CommandType.Free)
                        .AddAbilityTargetHasFact(new() { GetGUID.GUIDByName("EidolonSubtypeFeature"), GetGUID.GUIDByName("SummonerAspectFeature"), GetGUID.GUIDByName("SummonerAspectGreaterFeature") })
                        .SetCanTargetFriends(false)
                        .SetCanTargetSelf(true)
                        .AddAbilityEffectRunAction(actions: abilityAction)
                        .AddAbilityResourceLogic(amount, isSpendResource: true, requiredResource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")))
                        .AddComponent<AbilityEidolonHasResource>(c =>
                        {
                            c.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource"));
                            c.resourceAmount = amount;
                        })
                        .ConfigureWithLogging();
                }
            }
        }
        internal static void CreateAllEvolutionBaseAbilities()
        {
            int i = 1;
            foreach (var level in Evolutions)
            {
                var name = "Evolution" + level.Key + "AbilityBase";
                var display = $"evolutioncost{i++}feature";
                var abilityBase = AbilityConfigurator.New(name, GetGUID.GUIDByName(name))
                    .SetDisplayName(Helpers.ObtainString(display + ".Name"))
                    .SetDescription(Helpers.ObtainString(display + ".Description"))
                    .SetIcon(AssetLoader.LoadInternal("Abilities", $"Evolutions{level.Key}.png"))
                    .SetType(AbilityType.Special)
                    .SetRange(AbilityRange.Touch)
                    .SetActionType(CommandType.Free)
                    .SetCanTargetSelf(true)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")));

                var abilities = new List<Blueprint<BlueprintAbilityReference>>();
                foreach (var evolution in level.Value)
                {
                    abilities.Add(BlueprintTool.GetRef<BlueprintAbilityReference>(GetGUID.GUIDByName(evolution + "Ability")));
                }
                abilityBase.AddAbilityVariants(abilities);

                abilityBase.ConfigureWithLogging();
            }
        }
        internal static void CreateAddBaseAbiltiesFeature()
        {

            var featureName = "EvolutionBaseAbilitiesFeature";
            var feature = FeatureConfigurator.New(featureName, GetGUID.GUIDByName(featureName))
                    .SetDisplayName(Helpers.ObtainString(featureName + ".Name"))
                    .SetDescription(Helpers.ObtainString(featureName + ".Description"))
                    .SetIcon(AbilityRefs.ElementalBodyIAir.Reference.Get().m_Icon);

            var abilities = new List<Blueprint<BlueprintUnitFactReference>>();
            foreach (var level in Evolutions)
            {
                var name = "Evolution" + level.Key + "AbilityBase";
                abilities.Add(BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(name)));
            }
            feature.AddFacts(abilities);
            feature.ConfigureWithLogging();
        }
        internal static void CreateAllBaseEvolutions()
        {
            foreach (var level in Evolutions)
            {
                foreach (var evolution in level.Value)
                {
                    var featureName = evolution + "Feature";
                    var baseFeatureName = evolution + "BaseFeature";
                    var feature = FeatureConfigurator.New(baseFeatureName, GetGUID.GUIDByName(baseFeatureName))
                        .SetGroups(FeatureGroupExtension.EvolutionBase);

                    if (baseFeatureName.Contains("EvolutionLimbsArms"))
                    {
                        feature.CopyFrom(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName(featureName))).SetHideInUI(true);
                    }
                    else
                    {
                        feature.CopyFrom(BlueprintTool.GetRef<BlueprintFeatureBaseReference>(GetGUID.GUIDByName(featureName)), c => true);
                    }

                    feature.ConfigureWithLogging();

                }
            }
        }
        public static Dictionary<string, List<string>> Evolutions = new Dictionary<string, List<string>>()
        {
            {
                "One",
                new List<string>
                            {
                                "EvolutionBite",
                                "EvolutionGore",
                                "EvolutionClaws",
                                "EvolutionMagicAttacks",
                                "EvolutionNaturalArmor",
                                "EvolutionPincers",
                                "EvolutionResistanceAcid",
                                "EvolutionResistanceCold",
                                "EvolutionResistanceElectricity",
                                "EvolutionResistanceFire",
                                "EvolutionResistanceSonic",
                                "EvolutionScent",
                                "EvolutionSkilledSkillPerception",
                                "EvolutionSkilledSkillThievery",
                                "EvolutionSkilledSkillUseMagicDevice",
                                "EvolutionSlam",
                                "EvolutionSpike",
                                "EvolutionTail",
                                "EvolutionTailSlap",
                                "EvolutionTentacle",
                                "EvolutionTentacleMass",
                                "EvolutionWingBuffet",
                            }
            },
            {
                "Two",
                new List<string>
                            {
                                "EvolutionAbilityIncreaseStrength",
                                "EvolutionAbilityIncreaseDexterity",
                                "EvolutionAbilityIncreaseConstitution",
                                "EvolutionAbilityIncreaseIntelligence",
                                "EvolutionAbilityIncreaseWisdom",
                                "EvolutionAbilityIncreaseCharisma",
                                "EvolutionBloodFrenzy",
                                "EvolutionEnergyAttacksAcid",
                                "EvolutionEnergyAttacksCold",
                                "EvolutionEnergyAttacksElectricity",
                                "EvolutionEnergyAttacksFire",
                                "EvolutionFlight",
                                "EvolutionImmunityAcid",
                                "EvolutionImmunityCold",
                                "EvolutionImmunityElectricity",
                                "EvolutionImmunityFire",
                                "EvolutionImmunitySonic",
                                "EvolutionLimbsArms",
                                "EvolutionLimbsLegs",
                                "EvolutionRend",
                                "EvolutionTrample",
                                "EvolutionTrip",
                                "EvolutionBullrush",
                                "EvolutionSunderarmor",
                            }
            },
            {
                "Three",
                new List<string>
                            {
                                "EvolutionDamageReduction",
                                "EvolutionPounce",
                                "EvolutionWeb",
                                "EvolutionImprovedDamage",
                                "EvolutionReach",
                                "EvolutionClawsLimbs",
                                "EvolutionPincersLimbs",
                                "EvolutionSlamLimbs",
                            }
            },
            {
                "Four",
                new List<string>
                            {
                                "EvolutionAmorphous",
                                "EvolutionBlindsight",
                                "EvolutionBreathWeaponAcid",
                                "EvolutionBreathWeaponCold",
                                "EvolutionBreathWeaponElectricity",
                                "EvolutionBreathWeaponFire",
                                "EvolutionFastHealing",
                                "EvolutionLarge",
                                "EvolutionSpellResistance"
                            }
            }
        };





    }
}
