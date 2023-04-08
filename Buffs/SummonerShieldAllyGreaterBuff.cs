using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Spells.Summoning.SummonAbilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class SummonerShieldAllyGreaterBuff
    {
        private static class InternalString
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
            BuffConfigurator.New(InternalString.AuraBuff, GetGUID.SummonerShieldAllyGreaterAuraBuff)
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddAreaEffect(GetGUID.SummonerShieldAllyGreaterAuraAreaEffectBuff)
                .SetStacking(StackingType.Ignore)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();
        }
        private static void CreateSummonerShieldAllyGreaterAuraAreaEffectBuff()
        {
            AbilityAreaEffectConfigurator.New(InternalString.AreaEffectBuff, GetGUID.SummonerShieldAllyGreaterAuraAreaEffectBuff)
                .CopyFrom(AbilityAreaEffectRefs.MartyrAuraOfHealthArea, c => c is null)
                .AddAbilityAreaEffectBuff(GetGUID.SummonerShieldAllyGreaterConditionalBuff)
                .SetSize(7.Feet())
                .Configure();
        }
        private static void CreateSummonerShieldAllyGreaterConditionalBuff()
        {
            var conditionBuilderIsAlly = ConditionsBuilder.New().Build();
            conditionBuilderIsAlly.Conditions = new Kingmaker.ElementsSystem.Condition[] { new ContextConditionIsMaster() { Not = true }, new ContextConditionIsAlly(), new ContextConditionIsCaster() { Not = true } };

            var actionsAddBuffBuilderIsAlly = ActionsBuilder.New()
                                    .Conditional(conditionBuilderIsAlly,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.SummonerShieldAllyGreaterBuff, isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilderIsAlly = ActionsBuilder.New().RemoveBuff(GetGUID.SummonerShieldAllyGreaterBuff).Build();

            var conditionBuilderIsMaster = ConditionsBuilder.New().Build();
            conditionBuilderIsMaster.Conditions = new Kingmaker.ElementsSystem.Condition[] { new ContextConditionIsMaster() };

            var actionsAddBuffBuilderIsMaster = ActionsBuilder.New()
                                    .Conditional(conditionBuilderIsMaster,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.SummonerShieldAllyGreaterIsMasterBuff, isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilderIsMaster = ActionsBuilder.New().RemoveBuff(GetGUID.SummonerShieldAllyGreaterBuff).Build();

            BuffConfigurator.New(InternalString.ConditionalBuff, GetGUID.SummonerShieldAllyGreaterConditionalBuff)
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetStacking(StackingType.Ignore)
                .AddBuffActions(actionsAddBuffBuilderIsAlly, actionsRemoveBuffBuilderIsAlly, actionsAddBuffBuilderIsAlly)
                .AddBuffActions(actionsAddBuffBuilderIsMaster, actionsRemoveBuffBuilderIsMaster, actionsAddBuffBuilderIsMaster)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();
        }
        private static void CreateSummonerShieldAllyGreaterBuff()
        {
            BuffConfigurator.New(InternalString.Buff, GetGUID.SummonerShieldAllyGreaterBuff)
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddStatBonus(ModifierDescriptor.Shield,null,StatType.AC, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveFortitude, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveReflex, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveWill, 2)
                .Configure();
        }
        private static void CreateSummonerShieldAllyGreaterIsMasterBuff()
        {
            BuffConfigurator.New(InternalString.BuffIsMaster, GetGUID.SummonerShieldAllyGreaterIsMasterBuff)
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddStatBonus(ModifierDescriptor.Shield, null, StatType.AC, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveFortitude, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveReflex, 4)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveWill, 4)
                .Configure();
        }
    }
}
