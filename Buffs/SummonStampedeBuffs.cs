﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    class SummonStampedeBuffs
    {
        public static void CreateStampedeTrampleDamageImmunityBuff()
        {
            BuffConfigurator.New("StampedeTrampleDamageImmunityBuff", GetGUID.StampedeTrampleDamageImmunityBuff)
                .Configure();
        }

        public static void CreateStampedeAttackBuff()
        {
            var conditionalDamage = ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New()
                            .HasFact(BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.StampedeTrampleDamageImmunityBuff)),
                            null,
                            ActionsBuilder.New().DealDamage(damageType: DamageTypes.Physical(form: PhysicalDamageForm.Bludgeoning), value: ContextDice.Value(DiceType.D6, diceCount: ContextValues.Constant(4), bonus: 9))
                            ).Build();

            var damageBuff = BuffConfigurator.New("StampedeTrampleDamageBuff", GetGUID.StampedeTrampleDamageBuff)
                .AddNewRoundTrigger(newRoundActions: conditionalDamage)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();

            var area = AbilityAreaEffectConfigurator.New("StampedeTrampleDamageAreaEffect", GetGUID.StampedeTrampleDamageAreaEffect)
                .SetAffectEnemies(true)
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Any)
                .SetSize(2.Feet())
                .SetShape(AreaEffectShape.Cylinder)
                .AddAbilityAreaEffectRunAction(
                        unitEnter: ActionsBuilder.New().ApplyBuff(buff: damageBuff, ContextDuration.Fixed(1, rate: DurationRate.Days)).Build(),
                        unitExit: ActionsBuilder.New().RemoveBuff(buff: damageBuff).Build()
                ).Configure();

            BuffConfigurator.New("StampedeTrampleDamageAreaBuff", GetGUID.StampedeTrampleDamageAreaBuff)
                .AddAreaEffect(areaEffect: area)
                .SetFlags(new BlueprintBuff.Flags[] { BlueprintBuff.Flags.HiddenInUi })
                .Configure();
        }
    }
}