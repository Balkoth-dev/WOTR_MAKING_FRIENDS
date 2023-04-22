using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffSummonStampede
    {
        public static void CreateStampedeTrampleDamageImmunityBuff()
        {
            BuffConfigurator.New("StampedeTrampleDamageImmunityBuff", GetGUID.GUIDByName("StampedeTrampleDamageImmunityBuff"))
                .ConfigureWithLogging();
        }

        public static void CreateStampedeAttackBuff()
        {
            Kingmaker.ElementsSystem.ActionList conditionalDamage = ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New()
                            .HasFact(BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("StampedeTrampleDamageImmunityBuff"))),
                            null,
                            ActionsBuilder.New().DealDamage(damageType: DamageTypes.Physical(form: PhysicalDamageForm.Bludgeoning), value: ContextDice.Value(DiceType.D6, diceCount: ContextValues.Constant(4), bonus: 9))
                            ).Build();

            BlueprintBuff damageBuff = BuffConfigurator.New("StampedeTrampleDamageBuff", GetGUID.GUIDByName("StampedeTrampleDamageBuff"))
                .AddNewRoundTrigger(newRoundActions: conditionalDamage)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();

            BlueprintAbilityAreaEffect area = AbilityAreaEffectConfigurator.New("StampedeTrampleDamageAreaEffect", GetGUID.GUIDByName("StampedeTrampleDamageAreaEffect"))
                .SetAffectEnemies(true)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Any)
                .SetSize(2.Feet())
                .SetShape(AreaEffectShape.Cylinder)
                .AddAbilityAreaEffectRunAction(
                        unitEnter: ActionsBuilder.New().ApplyBuff(buff: damageBuff, ContextDuration.Fixed(1, rate: DurationRate.Days)).Build(),
                        unitExit: ActionsBuilder.New().RemoveBuff(buff: damageBuff).Build()
                ).ConfigureWithLogging();

            BuffConfigurator.New("StampedeTrampleDamageAreaBuff", GetGUID.GUIDByName("StampedeTrampleDamageAreaBuff"))
                .AddAreaEffect(areaEffect: area)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
    }
}
