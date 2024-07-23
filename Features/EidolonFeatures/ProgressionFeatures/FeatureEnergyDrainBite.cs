using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureEnergyDrainBite
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "EidolonEnergyDrainBite";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.EnergyDrain.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 2;
        }
        public static class IClassBuff
        {
            internal static string Buff = IClass.ProgressionFeature + "Buff";
            internal static string Guid = GetGUID.GUIDByName(Buff);
            internal static LocalizedString Name = IClass.Name;
            internal static LocalizedString Description = IClass.Description;
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 2;
        }
        public static void Create()
        {
            CreateFeature();
            CreateBuff();
        }
        internal static void CreateFeature()
        {

            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassBuff.Guid) })
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateBuff()
        {

            BuffConfigurator.New(IClassBuff.Buff, IClassBuff.Guid)
                .CopyFrom(BuffRefs.VrolikaiAspectEffectBuff, c => c is AddInitiatorAttackWithWeaponTrigger or AddAbilityUseTrigger)
                    .SetDisplayName(IClass.Name)
                    .SetDescription(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddContextRankConfig(ContextRankConfigs.FeatureRank(IClass.Guid))
                    .AddContextSetAbilityParams(add10ToDC: true, dC: ContextValues.Property(UnitProperty.Level))
                    .ConfigureWithLogging();
        }
    }
}
