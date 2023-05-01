using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionNaturalArmor
    {
        private static class InternalClass
        {
            internal static Sprite icon = AbilityRefs.Barkskin.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionNaturalArmor";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(InternalClass.Feature))
                .SetIcon(InternalClass.icon)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.NaturalArmor,stat:StatType.AC,value:2)
                .SetRanks(4)
                .ConfigureWithLogging(true);
        }
        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(InternalClass.Ability))
                .SetIcon(InternalClass.icon)
                .AddComponent<AbilityCasterHasFactRank>(c => {
                    c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(InternalClass.Feature));
                    c.maxRank = 4;
                    c.numLevelsBetweenRanks = 5;
                })
                .AddAbilityCasterHasFacts()
                .ConfigureWithLogging(true);
        }
    }
}
