using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureMageLight
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "MageLight";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = AbilityRefs.MageLight.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassBuff
        {
            internal static string Buff = IClass.ProgressionFeature + "Buff";
            internal static string Guid = GetGUID.GUIDByName(Buff);
            internal static string Name = Helpers.ObtainString(Buff + ".Name");
            internal static string Description = Helpers.ObtainString(Buff + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
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
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassBuff.Guid) })
                    .SetGroups(IClass.featureGroup)

                    .ConfigureWithLogging();
        }
        internal static void CreateBuff()
        {

            BuffConfigurator.New(IClassBuff.Buff, IClassBuff.Guid)
                .CopyFrom(BuffRefs.MageLightBuff, c => true)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .ConfigureWithLogging();
        }
    }
}
