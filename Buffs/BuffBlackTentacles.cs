using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffBlackTentacles
    {
        internal static class IClass
        {
            internal const string BlackTentaclesBuff = "BlackTentaclesBuff";
            internal static LocalizedString BlackTentaclesSpellName = Helpers.ObtainString("BlackTentaclesSpell.Name");
            internal static LocalizedString BlackTentaclesSpellDescription = Helpers.ObtainString("BlackTentaclesSpell.Description");
        }
        public static void CreateBlackTentaclesBuff()
        {
            BuffConfigurator.New(IClass.BlackTentaclesBuff, GetGUID.GUIDByName("BlackTentaclesBuff"))
                .CopyFrom(BuffRefs.OmoxGrappleBuff)
                .SetDisplayName(IClass.BlackTentaclesSpellName)
                .SetDescription(IClass.BlackTentaclesSpellDescription)
                .AddContextRankConfig(ContextRankConfigs.CasterLevel())
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.Entangled)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.CantMove)
                .AddActionsOnBuffApply(actions: ActionsBuilder.New()
                                                    .DealDamage(damageType: DamageTypes.Untyped(), value: ContextDice.Value(DiceType.D6, diceCount: ContextValues.Constant(1), bonus: 4))
                                                    .Build())
                .AddNewRoundTrigger(newRoundActions: ActionsBuilder.New()
                                                    .DealDamage(damageType: DamageTypes.Untyped(), value: ContextDice.Value(DiceType.D6, diceCount: ContextValues.Constant(1), bonus: 4))
                                                    .BreakFree(success: ActionsBuilder.New().RemoveSelf(), useCMB: true)
                                                    .Build())
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
    }
}
