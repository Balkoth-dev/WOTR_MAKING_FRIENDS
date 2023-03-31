using HarmonyLib;
using System;
using UnityModManagerNet;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS
{
    public class Main
    {
        public class Settings : UnityModManager.ModSettings
        {
            public override void Save(UnityModManager.ModEntry modEntry)
            {
                Save(this, modEntry);
            }
        }
        public static UnityModManager.ModEntry modInfo = null;
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                modInfo = modEntry;
                Log("Patching...");
                var harmony = new Harmony(modEntry.Info.Id);
                AssetLoader.ModEntry = modEntry;
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
    }

}
