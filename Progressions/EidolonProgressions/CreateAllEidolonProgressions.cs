using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

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
                        .SetUIDeterminatorsGroup(new Blueprint<BlueprintFeatureBaseReference>[] { })
                        .SetLevelEntries(eidolonSubtype.levelEntries);


                    foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonBaseForm)))
                    {
                            try
                            {
                                var characterClassName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + "Class";
                                var characterClassGuid = GetGUID.GUIDByName(characterClassName);
                                progression.AddToClasses(BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClassGuid));
                            }
                            catch { }
                    }

                    progression.ConfigureWithLogging();
                }
                catch(Exception ex)
                {
                    Main.Log(e:ex);
                }
            }
        }
    }
}
