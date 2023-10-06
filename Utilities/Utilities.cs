using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityModManagerNet.UnityModManager;

namespace WOTR_MAKING_FRIENDS.Utilities
{
    internal class AssetLoader
    {
        public static ModEntry ModEntry;
        public static Sprite LoadInternal(string folder, string file, int width = 64, int height = 64)
        {
            return Image2Sprite.Create($"{ModEntry.Path}Assets{Path.DirectorySeparatorChar}{folder}{Path.DirectorySeparatorChar}{file}", width, height);
        }
        // Loosely based on https://forum.unity.com/threads/generating-sprites-dynamically-from-png-or-jpeg-files-in-c.343735/
        public static class Image2Sprite
        {
            public static string icons_folder = "";
            public static Sprite Create(string filePath, int height = 64, int width = 64)
            {
                byte[] bytes = File.ReadAllBytes(icons_folder + filePath);
                Texture2D texture = new Texture2D(height, width, TextureFormat.RGBA32, false);
                _ = texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, height, width), new Vector2(0, 0));
                return sprite;
            }
        }
    }
    public static class Helpers
    {
        public static ModEntry ModEntry;
        private static Dictionary<string, LocalizedString> textToLocalizedString = new Dictionary<string, LocalizedString>();
        public static readonly Dictionary<BlueprintGuid, SimpleBlueprint> ModBlueprints = new Dictionary<BlueprintGuid, SimpleBlueprint>();

        private static readonly Dictionary<string, Guid> GuidsByName = new();

        public static T CreateCopy<T>(T original, Action<T> init = null)
        {
            T result = (T)ObjectDeepCopier.Clone(original);
            init?.Invoke(result);
            return result;
        }
        public static T Create<T>(Action<T> init = null) where T : new()
        {
            T result = new T();
            init?.Invoke(result);
            return result;
        }
        public static T GenericAction<T>(Action<T> init = null) where T : Kingmaker.ElementsSystem.GameAction, new()
        {
            T result = (T)Kingmaker.ElementsSystem.Element.CreateInstance(typeof(T));
            init?.Invoke(result);
            return result;
        }
        public static LocalizedString ObtainString(string name, string seperator = ".")
        {
            string partialKey = Settings.Settings.PartialKey;
            Regex rgx = new("[^a-z0-9-.]");
            string key = rgx.Replace(partialKey.ToLower() + seperator + name.ToLower(), "");
            try
            {
                return LocalizationTool.GetString(key);
            }
            catch
            {
                Main.Log("Localization " + key + " not found, replacing with temporary localization and writing to json.");
                return LocalizationByName(key, name);
            }
        }
        public static LocalizedString CreateString(string key, string value)
        {
            // See if we used the text previously.
            // (It's common for many features to use the same localized text.
            // In that case, we reuse the old entry instead of making a new one.)
            if (textToLocalizedString.TryGetValue(value, out LocalizedString localized))
            {
                return localized;
            }
            var strings = LocalizationManager.CurrentPack?.m_Strings;
            if (strings!.TryGetValue(key, out var oldValue) && value != oldValue.Text)
            {
                Main.Log($"Info: duplicate localized string `{key}`, different text.");
            }
            var sE = new Kingmaker.Localization.LocalizationPack.StringEntry();
            sE.Text = value;
            strings[key] = sE;
            localized = new LocalizedString
            {
                m_Key = key
            };
            textToLocalizedString[value] = localized;
            return localized;
        }

        public static LocalizedString LocalizationByName(string key, string value)
        {
            var filePath = "";

            if (key.ToLower().Contains("class"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\CharacterClasses.json");
            }
            else if (key.ToLower().Contains("feature"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Features.json");
            }
            else if (key.ToLower().Contains("progression"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Progression.json");
            }
            else if (key.ToLower().Contains("scroll"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Scrolls.json");
            }
            else if (key.ToLower().Contains("setting"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Settings.json");
            }
            else if (key.ToLower().Contains("spell"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Spells.json");
            }
            else if (key.ToLower().Contains("spellbook"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\SummonerSpellbook.json");
            }
            else if (key.ToLower().Contains("unit") || key.ToLower().Contains("eidolon"))
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Units.json");
            }
            else
            {
                filePath = Path.Combine(ModEntry.Path, @"Localizations\Other.json");
            }

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);

                var oba = JArray.Parse(json).ToList();
                var valueString = (string)oba.FirstOrDefault(j => (string)j["Key"] == key)?["enGB"] ?? string.Empty;

                if (valueString != string.Empty)
                {
                    return CreateString(key, valueString);
                }

                var newObject = new JObject();
                newObject["Key"] = key;
                newObject["enGB"] = value;

                oba.Add(newObject);
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };
                var newJson = JsonConvert.SerializeObject(oba, settings);

                File.WriteAllText(filePath, newJson);

                return CreateString(key, value);
            }
            Main.Log("File : " + filePath + "not found.");
            return null;
        }
    }
}
