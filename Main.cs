using HarmonyLib;
using System;
using System.Reflection;
using UnityModManagerNet;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS
{
#if DEBUG
    [EnableReloading]
#endif
    public class Main
    {
        private static Harmony harmony;
        public static UnityModManager.ModEntry modInfo = null;
        public class Settings : UnityModManager.ModSettings
        {
            public override void Save(UnityModManager.ModEntry modEntry)
            {
                Save(this, modEntry);
            }
        }
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            harmony = new Harmony(modEntry.Info.Id);
#if DEBUG
            modEntry.OnUnload = OnUnload;
#endif
            try
            {
                modInfo = modEntry;
                Log("Patching...");
                AssetLoader.ModEntry = modEntry;
                GetGUID.ModEntry = modEntry;
                Helpers.ModEntry = modEntry;
                harmony.PatchAll();

                Log("Finished patching.");
            }
            catch (Exception e)
            {
                Log("Failed to patch", e);
            }
            return true;
        }
        public static void Log(string msg = null, Exception e = null)
        {
#if DEBUG
            modInfo.Logger.Log(msg != null && e != null ? $"{msg}, Exception: {e}" : msg != null ? $"{msg}" : e != null ? $"Exception: {e}" : "");
#endif
        }

        private static bool OnUnload(UnityModManager.ModEntry modEntry)
        {
            harmony.UnpatchAll();
            return true;
        }

        public static void Reload()
        {
            Log("Reload Start");
            UnityModManager.ModEntry modEntry = modInfo;
            Log(modEntry.Info.Id);
            modEntry.GetType().GetMethod("Reload", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(modEntry, new object[] { });
        }
    }

}
