using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.IO;
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
                Main.Log("Localization " + key + " not found, replacing with temporary localization.");
                return CreateString(key, name);
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
    }
}
