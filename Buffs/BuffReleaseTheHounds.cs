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
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffReleaseTheHounds
    {
        internal static readonly BlueprintAbility iceBody = BlueprintTool.Get<BlueprintAbility>("89778dc261fe6094bb2445cb389842d2");
        public static void CreateReleaseTheHoundsBuff()
        {


            Kingmaker.ElementsSystem.ActionList conditionalDamage = ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New()
                            .IsEnemy(),
                            ActionsBuilder.New().DealDamage(damageType: DamageTypes.Energy(type: DamageEnergyType.Cold), value: ContextDice.Value(DiceType.D6, diceCount: ContextValues.Constant(3)))
                            .SavingThrow(type: Kingmaker.EntitySystem.Stats.SavingThrowType.Reflex, customDC: ContextValues.Rank(),
                            onResult:
                  ActionsBuilder.New()
                    .ConditionalSaved(
                      failed: ActionsBuilder.New().KnockdownTarget()).Build()
                            )).Build();

            BlueprintBuff damageBuff = BuffConfigurator.New("ReleaseTheHoundsDamageBuff", GetGUID.GUIDByName("ReleaseTheHoundsDamageBuff"))
                .AddNewRoundTrigger(newRoundActions: conditionalDamage)
                .SetStacking(StackingType.Rank)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .AddContextRankConfig(component: ContextRankConfigs.BuffRank(GetGUID.GUIDByName("ReleaseTheHoundsDamageBuff"), min: 20))
                .ConfigureWithLogging();

            BlueprintAbilityAreaEffect area = AbilityAreaEffectConfigurator.New("ReleaseTheHoundsDamageAreaEffect", GetGUID.GUIDByName("ReleaseTheHoundsDamageAreaEffect"))
                .SetAffectEnemies(true)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Any)
                .SetSize(1.Feet())
                .SetShape(AreaEffectShape.Cylinder)
                .AddAbilityAreaEffectRunAction(
                        unitEnter: ActionsBuilder.New().ApplyBuff(buff: damageBuff, ContextDuration.Fixed(1, rate: DurationRate.Days)).Build(),
                        unitExit: ActionsBuilder.New().RemoveBuff(buff: damageBuff).Build()
                )
                .ConfigureWithLogging();

            BuffConfigurator.New("ReleaseTheHoundsDamageAreaBuff", GetGUID.GUIDByName("ReleaseTheHoundsDamageAreaBuff"))
                .AddAreaEffect(areaEffect: area)
                .SetFxOnStart(iceBody.GetComponent<AbilitySpawnFx>().PrefabLink)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .ConfigureWithLogging();
        }
    }
}
