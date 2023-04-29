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
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._4_Point_Evolutions;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._3_Point_Evolutions;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions
{
    public static class AdjustEvolutions
    {
        public static void Adjust()
        {
            EvolutionBite.Adjust();
            EvolutionClaws.Adjust();
            EvolutionGore.Adjust();
            EvolutionMagicAttacks.Adjust();
            EvolutionNaturalArmor.Adjust();
            EvolutionPincers.Adjust();
            EvolutionResistance.Adjust();
            EvolutionScent.Adjust();
            EvolutionSkilled.Adjust();
            EvolutionSlam.Adjust();
            EvolutionSpike.Adjust();
            EvolutionTail.Adjust();
            EvolutionTentacle.Adjust();
            EvolutionTentacleMass.Adjust();
            EvolutionWingBuffet.Adjust();

            EvolutionAbilityIncrease.Adjust();
            EvolutionBloodFrenzy.Adjust();
            EvolutionBullrush.Adjust();
            EvolutionEnergyAttacks.Adjust();
            EvolutionFlight.Adjust();
            EvolutionImmunity.Adjust();
            EvolutionLimbsArms.Adjust();
            EvolutionLimbsLegs.Adjust();
            EvolutionRend.Adjust();
            EvolutionSunderarmor.Adjust();
            EvolutionTrample.Adjust();
            EvolutionTrip.Adjust();

            EvolutionClawsLimbs.Adjust();
            EvolutionDamageReduction.Adjust();
            EvolutionImprovedDamage.Adjust();
            EvolutionPincersLimbs.Adjust();
            EvolutionPounce.Adjust();
            EvolutionReach.Adjust();
            EvolutionSlamLimbs.Adjust();
            EvolutionWeb.Adjust();
        }


        //To-Do: Delete below if not needed 
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
