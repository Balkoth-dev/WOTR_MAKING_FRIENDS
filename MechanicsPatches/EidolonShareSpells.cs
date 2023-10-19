using HarmonyLib;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using System;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.MechanicsPatches
{
    [HarmonyPatch(typeof(AbilityData))]
    public class EidolonShareSpellsPatch
    {
        private static Guid summonerSpellbookGuid = Guid.Parse(GetGUID.GUIDByName("SummonerSpellbookSpellBook"));

        [HarmonyBefore(new string[] { "CharacterOptionsPlus" })]
        [HarmonyPrefix, HarmonyPatch(nameof(AbilityData.CanTarget))]
        static bool CanTarget_patch(AbilityData __instance, TargetWrapper target, ref bool __result)
        {
            if (!Settings.Settings.GetSetting<bool>("sharespellspatch"))
            {
                return true;
            }

            if (__instance.Range == AbilityRange.Personal && __instance.Blueprint.Type == AbilityType.Spell)
            {
                if (__instance.SpellbookBlueprint?.AssetGuid.m_Guid != summonerSpellbookGuid)
                {
                    return true;
                }
                var petType = target?.Unit.Get<UnitPartPet>()?.Type;
                if (petType != null && petType == PetTypeExtensions.Eidolon) {
                    var master = target.Unit.Master;
                    if (master != null && master == __instance.Caster.Unit)
                    {
                        __result = true;
                        return false;
                    } else if (master != null && master != __instance.Caster.Unit)
                    {
                        __result = false;
                        return false;
                    }
                }

            }
            return true;
        }

        [HarmonyPrefix, HarmonyPatch(nameof(AbilityData.TargetAnchor), MethodType.Getter)]
        static bool TargetAnchor_getter_patch(AbilityData __instance, ref AbilityTargetAnchor __result)
        {
            if (!Settings.Settings.GetSetting<bool>("sharespellspatch"))
            {
                return true;
            }

            if (__instance.Range == AbilityRange.Personal && __instance.Blueprint.Type == AbilityType.Spell)
            {
                if (__instance.SpellbookBlueprint?.AssetGuid.m_Guid != summonerSpellbookGuid)
                {
                    return true;
                }
                if (__instance.Caster.Unit.Get<UnitPartPetMaster>() != null)
                {
                    __result = AbilityTargetAnchor.Unit;
                    return false;
                }
            }
            return true;
        }

    }
}
