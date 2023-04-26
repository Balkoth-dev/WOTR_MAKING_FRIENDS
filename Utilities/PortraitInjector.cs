using HarmonyLib;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//Source: https://github.com/ka-dyn/ExpandedContent/blob/7ae441e92dc0746f7df3ea9879f7111ccbc9e53d/ExpandedContent/Utilities/PortraitInjector.cs
namespace WOTR_MAKING_FRIENDS.Utilities
{
    [HarmonyPatch(typeof(PortraitData), nameof(PortraitData.FullLengthPortrait), MethodType.Getter)]
    public static class FullPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), nameof(PortraitData.HalfLengthPortrait), MethodType.Getter)]
    public static class HalfPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), nameof(PortraitData.SmallPortrait), MethodType.Getter)]
    public static class SmallPortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
    [HarmonyPatch(typeof(PortraitData), nameof(PortraitData.PetEyePortrait), MethodType.Getter)]
    public static class EyePortraitInjector
    {
        public static Dictionary<PortraitData, Sprite> Replacements = new();
        public static bool Prefix(PortraitData __instance, ref Sprite __result)
        {
            if (Replacements.TryGetValue(__instance, out __result))
                return false;
            return true;
        }
    }
}