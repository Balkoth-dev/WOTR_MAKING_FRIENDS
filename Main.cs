using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.PubSubSystem;
using System;
using UnityModManagerNet;
using WOTR_MAKING_FRIENDS.Other;
using WOTR_MAKING_FRIENDS.Settings;

namespace WOTR_MAKING_FRIENDS
{
    public class Main
    {
        public static UnityModManager.ModEntry modInfo = null;
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                modInfo = modEntry;
                Log("Patching...");
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll();

                EventBus.Subscribe(new BlueprintCacheInitHandler());

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
        class BlueprintCacheInitHandler : IBlueprintCacheInitHandler
        {
            private static bool Initialized = false;
            private static bool InitializeDelayed = false;

            public void AfterBlueprintCachePatches()
            {
                try
                {
                    if (InitializeDelayed)
                    {
                        Log("Already initialized blueprints cache.");
                        return;
                    }
                    InitializeDelayed = true;
                }
                catch (Exception e)
                {
                    Log("Delayed blueprint configuration failed.", e);
                }
            }

            public void BeforeBlueprintCacheInit() { }

            public void BeforeBlueprintCachePatches() { }

            public void AfterBlueprintCacheInit()
            {
                try
                {
                    if (Initialized)
                    {
                        Log("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;
                    // First strings
                    LocalizationTool.LoadEmbeddedLocalizationPacks(
                      "Localization.Settings.json");

                    // Then settings
                    SettingsUI.Initialize();

                }
                catch (Exception e)
                {
                    Log("Failed to initialize.", e);
                }
            }
        }
    }
}
