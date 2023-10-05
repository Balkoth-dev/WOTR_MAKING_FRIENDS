using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureSuperiorSummoningMaster
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "SuperiorSummoningMaster";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.SuperiorSummoning.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassBuff
        {
            internal const string BuffName = "SuperiorSummoningMaster";
            internal const string Buff = BuffName + "Buff";
            internal const string BuffIsMaster = BuffName + "IsMasterBuff";
            internal const string ConditionalBuff = BuffName + "ConditionalBuff";
            internal const string AuraBuff = BuffName + "AuraBuff";
            internal const string AreaEffectBuff = BuffName + "AuraAreaEffectBuff";
        }
        public static void Create()
        {
            CreateFeature();
            CreateAuraBuff();
            CreateAreaEffectBuff();
            CreateConditionalBuff();
            CreateIsMasterBuff();
        }
        public static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetRanks(IClass.Ranks)
                .SetGroups(IClass.featureGroup)
                .AddAuraFeatureComponent(GetGUID.GUIDByName(IClassBuff.AuraBuff))
                .Configure();
        }

        private static void CreateAuraBuff()
        {
            BuffConfigurator.New(IClassBuff.AuraBuff, GetGUID.GUIDByName(IClassBuff.AuraBuff))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddAreaEffect(GetGUID.GUIDByName(IClassBuff.AreaEffectBuff))
                .SetStacking(StackingType.Ignore)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
        private static void CreateAreaEffectBuff()
        {
            AbilityAreaEffectConfigurator.New(IClassBuff.AreaEffectBuff, GetGUID.GUIDByName(IClassBuff.AreaEffectBuff))
                .CopyFrom(AbilityAreaEffectRefs.MartyrAuraOfHealthArea)
                .AddAbilityAreaEffectBuff(GetGUID.GUIDByName(IClassBuff.ConditionalBuff))
                .SetSize(30.Feet())
                .ConfigureWithLogging();
        }
        private static void CreateConditionalBuff()
        {
            var conditionBuilderIsMaster = ConditionsBuilder.New().Build();
            conditionBuilderIsMaster.Conditions = new Kingmaker.ElementsSystem.Condition[] { new ContextConditionIsMaster() };

            var actionsAddBuffBuilderIsMaster = ActionsBuilder.New()
                                    .Conditional(conditionBuilderIsMaster,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.GUIDByName(IClassBuff.BuffIsMaster), isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilderIsMaster = ActionsBuilder.New().RemoveBuff(GetGUID.GUIDByName(IClassBuff.BuffIsMaster)).Build();

            BuffConfigurator.New(IClassBuff.ConditionalBuff, GetGUID.GUIDByName(IClassBuff.ConditionalBuff))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetStacking(StackingType.Ignore)
                .AddBuffActions(actionsAddBuffBuilderIsMaster, actionsRemoveBuffBuilderIsMaster, actionsAddBuffBuilderIsMaster)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
        private static void CreateIsMasterBuff()
        {
            BuffConfigurator.New(IClassBuff.BuffIsMaster, GetGUID.GUIDByName(IClassBuff.BuffIsMaster))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(IClass.Icon)
                .AddFacts(new() { FeatureRefs.SuperiorSummoning.Cast<BlueprintUnitFactReference>() })
                .ConfigureWithLogging();
        }
    }
}
