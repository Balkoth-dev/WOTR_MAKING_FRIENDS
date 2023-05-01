using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.References;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.BlueprintPatches
{
    internal class BlueprintPatchAnimalCompanionClass
    {
        public static void PatchAnimalCompanionClass()
        {
            CharacterClassConfigurator.For(CharacterClassRefs.AnimalCompanionClass)
                .AddPrerequisiteNoFeature(GetGUID.GUIDByName("EidolonSubtypeFeature"))
                .ConfigureWithLogging(true);
        }
    }
}
