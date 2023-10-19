using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using Kingmaker.UI;
using ModMenu.Settings;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WOTR_MAKING_FRIENDS.Abilities;
using WOTR_MAKING_FRIENDS.AiActions;
using WOTR_MAKING_FRIENDS.BlueprintPatches;
using WOTR_MAKING_FRIENDS.Brains;
using WOTR_MAKING_FRIENDS.Buffs;
using WOTR_MAKING_FRIENDS.CharacterClass;
using WOTR_MAKING_FRIENDS.Classes;
using WOTR_MAKING_FRIENDS.Features;
using WOTR_MAKING_FRIENDS.Portraits;
using WOTR_MAKING_FRIENDS.Progressions;
using WOTR_MAKING_FRIENDS.Resources;
using WOTR_MAKING_FRIENDS.SpellBook;
using WOTR_MAKING_FRIENDS.Spells;
using WOTR_MAKING_FRIENDS.SummonPools;
using WOTR_MAKING_FRIENDS.Units;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Settings
{
    public static class Settings
    {
        public static readonly string RootKey = "wotr-making-friends.settings";
        public static readonly string PartialKey = "wotr-making-friends";
        public static T GetSetting<T>(string key)
        {
            try
            {
                return ModMenu.ModMenu.GetSettingValue<T>(GetKey(key));
            }
            catch (Exception ex)
            {
                Main.Log(ex.ToString());
                return default;
            }
        }
        private static string GetKey(string partialKey)
        {
            Regex rgx = new("[^a-z0-9-.]");
            partialKey = rgx.Replace(partialKey.ToLower(), "");
            return $"{RootKey}.{partialKey}";
        }
    }

    [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init))]
    internal static class BlueprintsCache_Postfix
    {
        private static bool Initialized;

        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        private static void Postfix()
        {
            if (Initialized)
            {
                return;
            }

            Initialized = true;

            // Load Localizations
            LocalizationTool.LoadEmbeddedLocalizationPacks(
              "WOTR_MAKING_FRIENDS.Output.Localizations.Settings.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.CharacterClasses.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Spells.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Scrolls.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Units.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Features.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Progression.json",
              "WOTR_MAKING_FRIENDS.Output.Localizations.Other.json");

            SettingsUI.Initialize();
            Main.Log("Settings Initialized");

            CreateBlueprintPatches.CreateAllBlueprintPatches();
            CreateFeatures.CreateAllFeatures();
            SummonerClass.CreateSummonerClass();
            CreateResources.CreateAllResources();
            CreateProgressions.CreateAllProgressions();
            CreateSpellbooks.CreateAllSpellbooks();
            CreateClasses.CreateAllClasses();
            CreateBuffs.CreateAllBuffs();
            CreateAbilities.CreateAllAbilities();
            CreateAiActions.CreateAllAiActions();
            CreateBrains.CreateAllBrains();
            CreateUnits.CreateAllUnits();
            CreateSummonPools.CreateAllSummonPools();
            CreateSpells.CreateAllSpells();
            CreatePortraits.CreateAllPortraits();
            Main.Log("Total number of new blueprints: " + RootConfiguratorExtensions.numberOfBlueprints);
        }

        private class SettingsUI
        {
            private static readonly string RootKey = Settings.RootKey;
            private static readonly SettingsBuilder sb = SettingsBuilder.New(RootKey, GetString("title"));
            public static void Initialize()
            {
                sb.AddImage(AssetLoader.LoadInternal("Settings", "makingfriends.png", 200, 200), 200);

                CreateSubHeader("rulechangesheader");
                CreateToggle("sharespellspatch", true);
                ModMenu.ModMenu.AddSettings(sb);
            }
            private static void CreateSubHeader(string key)
            {
                sb.AddSubHeader(GetString(key));
            }
            private static void CreateToggle(string key, bool defaultBool = false)
            {
                sb.AddToggle(Toggle.New(GetKey(key), defaultValue: defaultBool, GetString(key + ".description"))
                    .ShowVisualConnection()
                    .OnValueChanged(OnToggle)
                    .WithLongDescription(GetString(key + ".longDescription")));
            }
            private static void CreatePatchToggle(string key, bool defaultBool = false)
            {
                if (GetString(key + ".name") != null)
                {
                    sb.AddToggle(Toggle.New(GetKey(key), defaultValue: defaultBool, GetString(key + ".name"))
                        .ShowVisualConnection()
                        .OnValueChanged(OnToggle)
                    .WithLongDescription(GetString(key + ".longDescription")));
                    Main.Log(GetKey(key) + " Created");
                }
            }

            private static void CreateButton(string key, Action action)
            {
                sb.AddButton(Button.New(GetString(key + ".description"), GetString(key + ".name"), action)
                    .WithLongDescription(GetString(key + ".longDescription")));
            }
            private static void CreateDropdownButton(string key, Action<int> action, List<LocalizedString> list)
            {
                sb.AddDropdownButton(DropdownButton.New(GetKey(key), 0, GetString(key + ".description"), GetString(key + ".buttonText"), action, list)
                    .WithLongDescription(GetString(key + ".longDescription")));
            }
            private static void CreateDropdown(string key, List<LocalizedString> values, int defaultValue = 0)
            {
                sb.AddDropdownList(DropdownList.New(
                    GetKey(key),
                    defaultValue,
                    GetString(key + ".description"),
                    values
                    )
                    .WithLongDescription(GetString(key + ".longDescription")));

            }
            private static void CreateKeyBinding(string key, Action action, KeyboardAccess.GameModesGroup gamesModeGroup = KeyboardAccess.GameModesGroup.All, UnityEngine.KeyCode firstKey = UnityEngine.KeyCode.None, bool withctrl = false)
            {
                sb.AddKeyBinding(KeyBinding.New(GetKey(key), gamesModeGroup, GetString(key + ".description")).SetPrimaryBinding(firstKey, withctrl)
                    .WithLongDescription(GetString(key + ".longDescription")),
                    action);
            }
            private static string GetKey(string partialKey)
            {
                Regex rgx = new("[^a-z0-9-.]");
                partialKey = rgx.Replace(partialKey.ToLower(), "");
                return $"{RootKey}.{partialKey}";
            }
            private static void OnToggle(bool value)
            {

            }
            private static LocalizedString GetString(string key)
            {
                string fullKey = GetKey(key);
                return LocalizationTool.GetString(fullKey);
            }
        }
    }
}