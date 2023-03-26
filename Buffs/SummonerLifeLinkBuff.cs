using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.ComponentsAndPatches.PetTypePatch;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    class SummonerLifeLinkBuff
    {
        private static class InternalString
        {
            internal const string Buff = "SummonerLifeLinkBuff";
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkBuff.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkBuff.Description");
        }
        public static void CreateSummonerLifeLinkBuff()
        {
            var shareValueCalc = ActionsBuilder.New()
                                               .Conditional(
                                                    ConditionsBuilder.New()
                                                        .SharedValueHigher(5,sharedValue: AbilitySharedValue.Damage).Build(),
                                                         ActionsBuilder.New().OnPets(ActionsBuilder.New()
                                                                                    .HealTarget(ContextDice.Value(DiceType.Zero,bonus: ContextValues.Constant(5)))
                                                                                    .OnContextCaster(
                                                                                            ActionsBuilder.New().DealDamage(
                                                                                                damageType: DamageTypes.Untyped(), value: ContextDice.Value(DiceType.Zero, bonus: 5)
                                                                                                ).Build()
                                                                                    )
                                                                                    .Build(), 
                                                                                    (Kingmaker.Enums.PetType)PetType.Eidolon).Build()
                                                )
                                               .Build();
                                               

            BuffConfigurator.New(InternalString.Buff, GetGUID.SummonerLifeLinkBuff)
                .CopyFrom(BuffRefs.OracleRevelationLifeLinkBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddContextCalculateSharedValue(1, ContextDice.Value(DiceType.Zero),AbilitySharedValue.Damage)
                .AddActionsOnBuffApply(shareValueCalc)
                .Configure();
        }
    }
}
