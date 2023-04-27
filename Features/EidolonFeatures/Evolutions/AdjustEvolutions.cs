using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions;
using static WOTR_MAKING_FRIENDS.SummonPools.CreateSummonPools;
using WOTR_MAKING_FRIENDS.GUIDs;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.ElementsSystem;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using WOTR_MAKING_FRIENDS.Utilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions
{
    public static class AdjustEvolutions
    {
        public static void Adjust()
        {
            EvolutionBite.Adjust();
            EvolutionClaws.Adjust();
            EvolutionImprovedDamage.Adjust();
            EvolutionMagicAttacks.Adjust();
            EvolutionNaturalArmor.Adjust();
            EvolutionPincers.Adjust();
            EvolutionReach.Adjust();
            EvolutionResistance.Adjust();
            EvolutionScent.Adjust();
            EvolutionSkilled.Adjust();
            EvolutionSlam.Adjust();
            EvolutionSting.Adjust();
            EvolutionTail.Adjust();
            EvolutionTentacle.Adjust();
            EvolutionTentacleMass.Adjust();
            EvolutionWingBuffet.Adjust();

            EvolutionLimbsArms.Adjust();
        }

        public static BlueprintFeatureReference[] addAbilityMultipleRanks(string evolutionName, int ranks)
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(evolutionName + "Ability"))
                .RemoveComponents(c => c is AbilityEffectRunAction)
                .ConfigureWithLogging(true);

            string originalFeatureName = evolutionName + "Feature";
            BlueprintFeatureReference[] blueprintFeatureReferences = new BlueprintFeatureReference[ranks+1];
            blueprintFeatureReferences[0] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(originalFeatureName));
            for (var i = 1; i <= ranks; i++)
            {
                string fullFeatureName = evolutionName + i + "Feature";
                blueprintFeatureReferences[i] = BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName(fullFeatureName));

            }

            var action = ActionsBuilder.New().Add<ContextActionAddFeatureIfPrevious>(c => { c.m_PermanentFeatures = blueprintFeatureReferences; })
                                             .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("SummonerEvolutionPointsResource")))
                                             .RestoreResource(BlueprintTool.GetRef<BlueprintAbilityResourceReference>(GetGUID.GUIDByName("EidolonMaxAttacksResource")));



            AbilityConfigurator.For(GetGUID.GUIDByName(evolutionName + "Ability"))
                .AddAbilityEffectRunAction(action.Build())
                .ConfigureWithLogging(true);

            return blueprintFeatureReferences;
        }

        public static void createEvolutionCopies(string evolutionName, int ranks)
        {
            string origininalFeatureName = evolutionName + "Feature";
            for (var i = 1; i <= ranks; i++)
            {
                string fullFeatureName = evolutionName + i + "Feature";

                FeatureConfigurator.New(fullFeatureName, GetGUID.GUIDByName(fullFeatureName)).CopyFrom(origininalFeatureName, c => true).ConfigureWithLogging();
            }
        }

    }

}
