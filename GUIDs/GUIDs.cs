using Epic.OnlineServices.AntiCheatServer;
using Epic.OnlineServices.Presence;
using Kingmaker.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using static UnityModManagerNet.UnityModManager;

namespace WOTR_MAKING_FRIENDS.GUIDs
{
    public static class GetGUID
    {
        public static ModEntry ModEntry;
        public static bool buildOnly = true;
        public static string json;
        
        public static string GUIDByName(string s)
        {
            var filePath = Path.Combine(ModEntry.Path, @"GUIDs\Guids.json");
            if (File.Exists(filePath))
            {
                if (!buildOnly)
                {
                    json = File.ReadAllText(filePath);
                }
                else if(json.IsNullOrEmpty())
                {
                    json = File.ReadAllText(filePath);
                }

                var oba = JArray.Parse(json).ToList();
                var value = (string)oba.FirstOrDefault(j => (string)j["name"] == s)?["guid"] ?? string.Empty;

                if (value != string.Empty)
                {
                    return value;
                }
                else
                {
                    buildOnly = false;
                    Main.Log("!!! Build Only Set To False!!!");
                }

                var newGuid = Guid.NewGuid().ToString().Replace(" ", "");
                var newObject = new JObject();
                newObject["name"] = s;
                newObject["guid"] = newGuid;

                oba.Add(newObject);
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };
                var newJson = JsonConvert.SerializeObject(oba, settings);

                File.WriteAllText(filePath, newJson);

                return newGuid;
            }
            Main.Log("File : " + filePath + "not found.");
            return string.Empty;
        }


    }
}

