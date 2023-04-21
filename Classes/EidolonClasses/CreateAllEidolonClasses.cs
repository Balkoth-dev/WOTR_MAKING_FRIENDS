using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root;
using System;
using WOTR_MAKING_FRIENDS.CharacterClass;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;
using static WOTR_MAKING_FRIENDS.SummonPools.CreateSummonPools;

namespace WOTR_MAKING_FRIENDS.Classes.EidolonClasses
{
    internal static class CreateAllEidolonClasses
    {
        internal static BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
        public static void Create()
        {
            foreach (var eidolonBaseForm in Enum.GetValues(typeof(EnumsEidolonBaseForm)))
            {
                foreach (var eidolonSubtype in Enum.GetValues(typeof(EnumsEidolonSubtype)))
                {
                    try
                    {
                        var characterClassName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + Enum.GetName(typeof(EnumsEidolonSubtype), eidolonSubtype) + "Class";
                        var characterClassGuid = GetGUID.GUIDByName(characterClassName);
                        var featureBaseForm = GetGUID.GUIDByName("Eidolon" + Enum.GetName(typeof(EnumsEidolonBaseForm), eidolonBaseForm) + "BaseFormFeature");
                        var featureSubtype = GetGUID.GUIDByName("Eidolon" + Enum.GetName(typeof(EnumsEidolonSubtype), eidolonSubtype) + "SubtypeFeature");
                        var progressionName = "Eidolon" + Enum.GetName(typeof(EnumsEidolonSubtype), eidolonSubtype) + "Progression";

                        var characterClass = CharacterClassConfigurator.New(characterClassName, characterClassGuid)
                            .CopyFrom(GetGUID.GUIDByName("EidolonBaseClass"), c => c is null)
                            .SetProgression(BlueprintTool.Get<BlueprintProgression>(GetGUID.GUIDByName(progressionName)))
                            .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(featureBaseForm))
                            .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(featureSubtype));


                        if ((EnumsEidolonBaseForm)eidolonBaseForm == EnumsEidolonBaseForm.Abberant)
                        {
                            characterClass.SetFortitudeSave(StatProgressionRefs.SavesHigh.Reference.Get())
                                          .SetReflexSave(StatProgressionRefs.SavesLow.Reference.Get())
                                          .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get());
                        }
                        else if ((EnumsEidolonBaseForm)eidolonBaseForm == EnumsEidolonBaseForm.Biped)
                        {
                            characterClass.SetFortitudeSave(StatProgressionRefs.SavesHigh.Reference.Get())
                                          .SetReflexSave(StatProgressionRefs.SavesLow.Reference.Get())
                                          .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get());
                        }
                        else if ((EnumsEidolonBaseForm)eidolonBaseForm == EnumsEidolonBaseForm.Quadruped)
                        {
                            characterClass.SetFortitudeSave(StatProgressionRefs.SavesHigh.Reference.Get())
                                          .SetReflexSave(StatProgressionRefs.SavesHigh.Reference.Get())
                                          .SetWillSave(StatProgressionRefs.SavesLow.Reference.Get());
                        }
                        else if ((EnumsEidolonBaseForm)eidolonBaseForm == EnumsEidolonBaseForm.Serpentine)
                        {
                            characterClass.SetFortitudeSave(StatProgressionRefs.SavesLow.Reference.Get())
                                          .SetReflexSave(StatProgressionRefs.SavesHigh.Reference.Get())
                                          .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get());
                        }

                        BlueprintCharacterClassReference classref = characterClass.Configure().ToReference<BlueprintCharacterClassReference>();
                        root.Progression.m_PetClasses = CommonTool.Append(root.Progression.m_PetClasses, classref);

                        Main.Log(characterClassName + " : " + characterClassGuid + " created.");
                    }
                    catch (Exception ex)
                    {
                        Main.Log(e: ex);
                    }
                }
            }
            }
        }
}
