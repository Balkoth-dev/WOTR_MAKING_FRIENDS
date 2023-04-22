using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal static class CreateAllEidolonProgressions
    {
        public static void Create()
        {
            foreach (var eidolonSubtype in EidolonSubtypeInfo.eidolonSubtypes)
            {
                try
                {
                    var name = "Eidolon" + eidolonSubtype.name + "Progression";
                    var guid = GetGUID.GUIDByName(name);

                    var progression = ProgressionConfigurator.New(name, guid)
                        .CopyFrom(BlueprintTool.Get<BlueprintProgression>(GetGUID.GUIDByName("EidolonBaseProgression")), c => c is null)
                        .SetClasses(GetGUID.GUIDByName("SummonerClass"))
                        .SetUIGroups(new())
                        .SetUIDeterminatorsGroup(new BlueprintCore.Utils.Blueprint<BlueprintFeatureBaseReference>[] { });

                    foreach (var entry in eidolonSubtype.levelEntries)
                    {
                        foreach (var bfbr in entry.Value)
                        {
                            progression.AddToLevelEntry(entry.Key, bfbr);
                        }
                    }

                    progression.Configure();
                }
                catch(Exception ex)
                {
                    Main.Log(e:ex);
                }
            }
        }
    }
}
