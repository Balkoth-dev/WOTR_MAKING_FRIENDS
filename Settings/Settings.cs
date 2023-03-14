using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UI;
using ModMenu.Settings;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.Settings
{
    public static class Settings
    {
        public static BlueprintGuid BoonGuid;
        public static readonly string RootKey = "wotr-making-friends.settings";
        public static List<BlueprintDungeonBoon> editedBoons = new List<BlueprintDungeonBoon>();
        public static T GetSetting<T>(string key)
        {
            try
            {
                return ModMenu.ModMenu.GetSettingValue<T>(GetKey(key));
            }
            catch (Exception ex)
            {
                Main.Log(ex.ToString());
                return default(T);
            }
        }
        private static string GetKey(string partialKey)
        {
            Regex rgx = new Regex("[^a-z0-9-]");
            partialKey = rgx.Replace(partialKey.ToLower(), "");
            return $"{RootKey}.{partialKey}";
        }
    }
    class SettingsUI
    {
        private static readonly string RootKey = Settings.RootKey;
        private static readonly SettingsBuilder sb = SettingsBuilder.New(RootKey, GetString("title"));
        private static readonly Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference[] dungeonBoons = BlueprintTool.Get<BlueprintDungeonRoot>("096f36d4e55b49129ddd2211b2c50513").m_Boons;
        private static readonly List<LocalizedString> boons = new List<LocalizedString>();

        public static void Initialize()
        {
            sb.AddImage(ResourcesLibrary.TryGetResource<Sprite>("assets/Settings/makingfriends.png"), height: 200, imageScale: 0.75f);

            CreateSubHeader("patchessubheader");
            CreateToggle("aeongazepatch", true);
            CreateToggle("hellsauthoritypatch", true);

            ModMenu.ModMenu.AddSettings(sb);
        }
        private static void CreateSubHeader(string key)
        {
            GetString(key + ".value");
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
            Regex rgx = new Regex("[^a-z0-9-]");
            partialKey = rgx.Replace(partialKey.ToLower(), "");
            return $"{RootKey}.{partialKey}";
        }
        private static void OnToggle(bool value)
        {

        }
        private static LocalizedString GetString(string key, bool usePrefix = true)
        {
            var fullKey = usePrefix ? $"{Settings.RootKey}.{key}" : key;
            return LocalizationTool.GetString(fullKey);
        }
    }
}