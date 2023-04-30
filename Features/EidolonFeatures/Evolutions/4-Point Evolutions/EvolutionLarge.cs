using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Microsoft.Build.Framework.XamlTypes;
using Owlcat.Runtime.Visual.RenderPipeline.PostProcess.HBAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.BlueprintAbilityResource;
using static Kingmaker.GameModes.GameModeType;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._4_Point_Evolutions
{
    internal class EvolutionLarge
    {
        private static class InternalString
        {
            internal static Sprite icon = AbilityRefs.LegendaryProportions.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionLarge";
            internal const string EvolutionSizeChange = "EvolutionSizeChange";
            internal const string Feature = Evolution + "Feature";
            internal const string Ability = Evolution + "Ability";
        }
        internal static BlueprintFeatureReference[] blueprintUnitFactReferences = new BlueprintFeatureReference[7];
        public static void Adjust()
        {
            AdjustFeature();
            AddSizeChangeFeatures();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalString.Feature))
                .SetIcon(InternalString.icon)
                .SetRanks(2)
                .ConfigureWithLogging(true);
        }
        public static void AddSizeChangeFeatures()
        {
            int mediumInt = (int)Size.Medium;
            int arrayInt = 0;
            foreach (Size enumValue in System.Enum.GetValues(typeof(Size)))
            {
                try
                {
                    var eidolonFeatureName = InternalString.EvolutionSizeChange + System.Enum.GetName(typeof(Size), enumValue) + "Feature";
                    var eidolonFeatureGuid = GetGUID.GUIDByName(eidolonFeatureName);

                    int sizeInt = (int)enumValue;
                    int diff = mediumInt - sizeInt;

                    var feature = FeatureConfigurator.New(eidolonFeatureName, GetGUID.GUIDByName(eidolonFeatureName))
                        .SetIcon(InternalString.icon)
                        .SetDisplayName(Helpers.ObtainString(eidolonFeatureName + ".Name"))
                        .SetDescription(Helpers.ObtainString(eidolonFeatureName + ".Description"))
                        .SetRanks(1)
                        .AddChangeUnitSize(size: enumValue, type: ChangeUnitSize.ChangeType.Value);

                    if (diff > 0)
                    {
                        feature.AddComponent<WeaponSizeChangeWeaponGroup>(c => { 
                            c.ignoreWeaponGroup = true; 
                            c.SizeCategoryChange = diff;
                            c.plusFeatureRanks = true;
                            c.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(InternalString.Feature));
                        });
                    }

                    feature.ConfigureWithLogging();

                    blueprintUnitFactReferences[arrayInt] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(eidolonFeatureName));
                    arrayInt++;

                }
                catch (Exception ex)
                {
                    Main.Log(e: ex);
                }
            }
        }

        public static void AdjustAbility()
        {

            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .RemoveComponents(c => c is AbilityEffectRunAction)
                .ConfigureWithLogging(true);
            
            var action = ActionsBuilder.New().AddFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(InternalString.Feature)))
                                             .Add<ContextActionAddRemoveFeature>(c => { 
                                                                                 c.m_Features = blueprintUnitFactReferences; 
                                                                                 c.m_Default_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(InternalString.EvolutionSizeChange+"LargeFeature")); })                          
                                             .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")))
                                             .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")));

            AbilityConfigurator.For(GetGUID.GUIDByName(InternalString.Ability))
                .SetIcon(InternalString.icon)
                .AddAbilityEffectRunAction(action.Build())
                .AddComponent<AbilityCasterHasFactRank>(c => {
                    c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalString.Feature));
                    c.maxRank = 2;
                    c.numLevelsBetweenRanks = 0;
                    c.startLevel = 0;
                })
                .ConfigureWithLogging(true);
        }
    }
}
