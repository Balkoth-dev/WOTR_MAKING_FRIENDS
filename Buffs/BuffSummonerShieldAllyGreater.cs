using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffSummonerShieldAllyGreater
    {
        internal static class IClass
        {
            internal const string Buff = "SummonerShieldAllyGreaterBuff";
            internal const string BuffIsMaster = "SummonerShieldAllyGreaterIsMasterBuff";
            internal const string ConditionalBuff = "SummonerShieldAllyGreaterConditionalBuff";
            internal const string AuraBuff = "SummonerShieldAllyGreaterAuraBuff";
            internal const string AreaEffectBuff = "SummonerShieldAllyGreaterAuraAreaEffectBuff";
            internal static LocalizedString Name = Helpers.ObtainString("summonerShieldAllyGreaterfeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("summonerShieldAllyGreaterfeature.Description");
        }
        public static void CreateShieldAllyGreaterBuffs()
        {
            CreateSummonerShieldAllyGreaterAuraBuff();
            CreateSummonerShieldAllyGreaterAuraAreaEffectBuff();
            CreateSummonerShieldAllyGreaterConditionalBuff();
            CreateSummonerShieldAllyGreaterBuff();
            CreateSummonerShieldAllyGreaterIsMasterBuff();
        }
        private static void CreateSummonerShieldAllyGreaterAuraBuff()
        {
            BuffConfigurator.New(IClass.AuraBuff, GetGUID.GUIDByName(IClass.AuraBuff))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .AddAreaEffect(GetGUID.GUIDByName("SummonerShieldAllyGreaterAuraAreaEffectBuff"))
                .SetStacking(StackingType.Ignore)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
        private static void CreateSummonerShieldAllyGreaterAuraAreaEffectBuff()
        {
            AbilityAreaEffectConfigurator.New(IClass.AreaEffectBuff, GetGUID.GUIDByName(IClass.AreaEffectBuff))
                .CopyFrom(AbilityAreaEffectRefs.MartyrAuraOfHealthArea)
                .AddAbilityAreaEffectBuff(GetGUID.GUIDByName("SummonerShieldAllyGreaterConditionalBuff"))
                .SetSize(7.Feet())
                .ConfigureWithLogging();
        }
        private static void CreateSummonerShieldAllyGreaterConditionalBuff()
        {
            var conditionBuilderIsAlly = ConditionsBuilder.New().Build();
            conditionBuilderIsAlly.Conditions = new Kingmaker.ElementsSystem.Condition[] { new ContextConditionIsMaster() { Not = true }, new ContextConditionIsAlly(), new ContextConditionIsCaster() { Not = true } };

            var actionsAddBuffBuilderIsAlly = ActionsBuilder.New()
                                    .Conditional(conditionBuilderIsAlly,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.GUIDByName("SummonerShieldAllyGreaterBuff"), isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilderIsAlly = ActionsBuilder.New().RemoveBuff(GetGUID.GUIDByName("SummonerShieldAllyGreaterBuff")).Build();

            var conditionBuilderIsMaster = ConditionsBuilder.New().Build();
            conditionBuilderIsMaster.Conditions = new Kingmaker.ElementsSystem.Condition[] { new ContextConditionIsMaster() };

            var actionsAddBuffBuilderIsMaster = ActionsBuilder.New()
                                    .Conditional(conditionBuilderIsMaster,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.GUIDByName("SummonerShieldAllyGreaterIsMasterBuff"), isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilderIsMaster = ActionsBuilder.New().RemoveBuff(GetGUID.GUIDByName("SummonerShieldAllyGreaterBuff")).Build();

            BuffConfigurator.New(IClass.ConditionalBuff, GetGUID.GUIDByName(IClass.ConditionalBuff))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetStacking(StackingType.Ignore)
                .AddBuffActions(actionsAddBuffBuilderIsAlly, actionsRemoveBuffBuilderIsAlly, actionsAddBuffBuilderIsAlly)
                .AddBuffActions(actionsAddBuffBuilderIsMaster, actionsRemoveBuffBuilderIsMaster, actionsAddBuffBuilderIsMaster)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
        private static void CreateSummonerShieldAllyGreaterBuff()
        {
            BuffConfigurator.New(IClass.Buff, GetGUID.GUIDByName(IClass.Buff))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddStatBonus(ModifierDescriptor.Shield, null, StatType.AC, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveFortitude, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveReflex, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveWill, 2)
                .ConfigureWithLogging();
        }
        private static void CreateSummonerShieldAllyGreaterIsMasterBuff()
        {
            BuffConfigurator.New(IClass.BuffIsMaster, GetGUID.GUIDByName(IClass.BuffIsMaster))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddStatBonus(ModifierDescriptor.Shield, null, StatType.AC, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveFortitude, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveReflex, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveWill, 4)
                .ConfigureWithLogging();
        }
    }
}
