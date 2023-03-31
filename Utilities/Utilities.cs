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
    class AssetLoader
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
                var bytes = File.ReadAllBytes(icons_folder + filePath);
                var texture = new Texture2D(height, width, TextureFormat.RGBA32, false);
                _ = texture.LoadImage(bytes);
                var sprite = Sprite.Create(texture, new Rect(0, 0, height, width), new Vector2(0, 0));
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
            var result = (T)ObjectDeepCopier.Clone(original);
            init?.Invoke(result);
            return result;
        }
        public static T Create<T>(Action<T> init = null) where T : new()
        {
            var result = new T();
            init?.Invoke(result);
            return result;
        }
        public static T GenericAction<T>(Action<T> init = null) where T : Kingmaker.ElementsSystem.GameAction, new()
        {
            var result = (T)Kingmaker.ElementsSystem.Element.CreateInstance(typeof(T));
            init?.Invoke(result);
            return result;
        }
        public static LocalizedString ObtainString(string name, string seperator = ".")
        {
            try
            {
                var partialKey = Settings.Settings.PartialKey;
                Regex rgx = new("[^a-z0-9-.]");
                var key = rgx.Replace(partialKey.ToLower() + seperator + name.ToLower(), "");
                return LocalizationTool.GetString(key);
            }
            catch (Exception ex)
            {
                Main.Log(ex.Message);
                return null;
            }
        }
    }
}
