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
    internal class BuffSummonerShieldAlly
    {
        private static class InternalString
        {
            internal const string Buff = "SummonerShieldAllyBuff";
            internal const string ConditionalBuff = "SummonerShieldAllyConditionalBuff";
            internal const string AuraBuff = "SummonerShieldAllyAuraBuff";
            internal const string AreaEffectBuff = "SummonerShieldAllyAuraAreaEffectBuff";
            internal static LocalizedString Name = Helpers.ObtainString("summonershieldallyfeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("summonershieldallyfeature.Description");
        }
        public static void CreateShieldAllyBuffs()
        {
            CreateSummonerShieldAllyAuraBuff();
            CreateSummonerShieldAllyAuraAreaEffectBuff();
            CreateSummonerShieldAllyConditionalBuff();
            CreateSummonerShieldAllyBuff();
        }
        private static void CreateSummonerShieldAllyAuraBuff()
        {
            BuffConfigurator.New(InternalString.AuraBuff, GetGUID.GUIDByName("SummonerShieldAllyAuraBuff"))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddAreaEffect(GetGUID.GUIDByName("SummonerShieldAllyAuraAreaEffectBuff"))
                .SetStacking(StackingType.Ignore)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();
        }
        private static void CreateSummonerShieldAllyAuraAreaEffectBuff()
        {
            AbilityAreaEffectConfigurator.New(InternalString.AreaEffectBuff, GetGUID.GUIDByName("SummonerShieldAllyAuraAreaEffectBuff"))
                .CopyFrom(AbilityAreaEffectRefs.MartyrAuraOfHealthArea, c => c is null)
                .AddAbilityAreaEffectBuff(GetGUID.GUIDByName("SummonerShieldAllyConditionalBuff"))
                .SetSize(7.Feet())
                .Configure();
        }
        private static void CreateSummonerShieldAllyConditionalBuff()
        {
            var conditionBuilder = ConditionsBuilder.New().Build();
            conditionBuilder.Conditions = new[] { new ContextConditionIsMaster() };

            var actionsAddBuffBuilder = ActionsBuilder.New()
                                    .Conditional(conditionBuilder,
                                                ActionsBuilder.New()
                                                .ApplyBuffPermanent(GetGUID.GUIDByName("SummonerShieldAllyBuff"), isNotDispelable: true))
                                    .Build();

            var actionsRemoveBuffBuilder = ActionsBuilder.New().RemoveBuff(GetGUID.GUIDByName("SummonerShieldAllyBuff")).Build();

            BuffConfigurator.New(InternalString.ConditionalBuff, GetGUID.GUIDByName("SummonerShieldAllyConditionalBuff"))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetStacking(StackingType.Ignore)
                .AddBuffActions(actionsAddBuffBuilder, actionsRemoveBuffBuilder, actionsAddBuffBuilder)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();
        }
        private static void CreateSummonerShieldAllyBuff()
        {
            BuffConfigurator.New(InternalString.Buff, GetGUID.GUIDByName("SummonerShieldAllyBuff"))
                .CopyFrom(BuffRefs.ShieldOfFaithBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetStacking(StackingType.Ignore)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "ShieldAlly.png"))
                .AddStatBonus(ModifierDescriptor.Shield, null, StatType.AC, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveFortitude, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveReflex, 2)
                .AddStatBonus(ModifierDescriptor.Circumstance, null, StatType.SaveWill, 2)
                .Configure();
        }
    }
}
