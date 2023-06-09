﻿using HarmonyLib;
using Kingmaker;
using Kingmaker.AreaLogic.SummonPool;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;

namespace WOTR_MAKING_FRIENDS.ComponentAndPatches
{
    [HarmonyPatch(typeof(ContextActionClearSummonPool), "RunAction")]
    public class ContextActionClearSummonPoolPatch
    {
        [HarmonyReversePatch]
        [HarmonyPatch(typeof(ContextActionClearSummonPool), "RunAction")]
        private static void OriginalRunAction(ContextActionClearSummonPool __instance)
        {
            // The original method is empty because it is being replaced by the Prefix method.
        }

        private static bool Prefix(ContextActionClearSummonPool __instance)
        {

            ISummonPool pool = Game.Instance.SummonPools.GetPool(__instance.SummonPool);
            if (pool == null)
            {
                return false;
            }

            foreach (UnitEntityData unit in pool.Units)
            {
                try
                {
                    UnitEntityData caster = unit.Descriptor.GetFact(BlueprintRoot.Instance.SystemMechanics.SummonedUnitBuff) is Buff fact ? fact.Context.MaybeCaster : null;
                    Main.Log(caster.CharacterName);
                    Main.Log(__instance.AbilityContext.MaybeCaster.CharacterName);
                    Main.Log((__instance.AbilityContext.MaybeCaster == caster) ? "True" : "False");
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
    }
}
