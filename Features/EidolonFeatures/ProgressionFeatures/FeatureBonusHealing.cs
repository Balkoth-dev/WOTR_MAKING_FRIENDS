using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine; using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureBonusHealing
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddBreathOfLifeSpell";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 2;
        }
        internal static class IClassBuff
        {
            internal static string Ability = IClass.ProgressionFeature + "Buff";
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
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassBuff.Guid) })
                    .ConfigureWithLogging();
        }
        internal void CreateAbility()
        {
            BuffConfigurator.New(IClassBuff.Ability, IClassBuff.Guid)
                .CopyFrom(BuffRefs.CelestialTotemLesserBuff, c => c is not ContextRankConfig)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .AddContextRankConfig(ContextRankConfigs.FeatureRank(IClass.Feature, max: IClass.Ranks))
                .ConfigureWithLogging();
        }
    }
}
