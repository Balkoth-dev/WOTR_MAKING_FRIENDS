using HarmonyLib;
using Kingmaker;
using Kingmaker.AreaLogic.SummonPool;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentPatches
{
    [HarmonyPatch(typeof(ContextActionClearSummonPool), "RunAction")]
    public class ContextActionClearSummonPoolPatch
    {
        static bool Prefix(ContextActionClearSummonPool __instance)
        {

            ISummonPool pool = Game.Instance.SummonPools.GetPool(__instance.SummonPool);
            if (pool == null)
                return false;
            foreach (UnitEntityData unit in pool.Units)
            {
                try
                {
                    var caster = unit.Descriptor.GetFact(BlueprintRoot.Instance.SystemMechanics.SummonedUnitBuff) is Buff fact ? fact.Context.MaybeCaster : null;
                    Main.Log(caster.CharacterName);
                    Main.Log(__instance.AbilityContext.MaybeCaster.CharacterName);
                    Main.Log((__instance.AbilityContext.MaybeCaster == caster) ? "True":"False");
                    Main.Log(pool.Blueprint.AssetGuid.m_Guid.ToString());

                    if (__instance.AbilityContext.MaybeCaster == caster)
                    {
                        unit.Descriptor.RemoveFact(Game.Instance.BlueprintRoot.SystemMechanics.SummonedUnitBuff);
                    }
                }
                catch (Exception e)
                {
                    Main.Log("", e);
                }
            }

            return false; // Skip the original method.
        }

        [HarmonyPatch(typeof(ContextActionClearSummonPool), "RunAction")]
        public class ContextActionClearSummonPoolPostfix
        {
            static void Postfix(ContextActionClearSummonPool __instance)
            {
                // Do nothing.
            }
        }
    }
}
