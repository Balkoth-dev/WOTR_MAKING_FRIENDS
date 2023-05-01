using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.SummonPools.CreateSummonPools;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureAddSpellBane
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "AddSpellBane";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static int Ranks = 1;
        }
        internal static class IClassAbility
        {
            internal static string Ability = IClass.ProgressionFeature + "Ability";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static string Name = Helpers.ObtainString(Ability + ".Name");
            internal static string Description = Helpers.ObtainString(Ability + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public void Create()
        {
            CreateFeature();
            CreateAbility();
        }
        internal void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbility.Guid) })
                    .ConfigureWithLogging();
        }
        internal void CreateAbility()
        {
            AbilityConfigurator.New(IClassAbility.Ability, IClassAbility.Guid)
                .CopyFrom(AbilityRefs.Bane, c => true)
                .ConfigureWithLogging();
        }
    }
}
