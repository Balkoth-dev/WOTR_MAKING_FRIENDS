using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.BlueprintPatches
{
    internal class BlueprintPatchAnimalCompanionClass
    {
        public static void PatchAnimalCompanionClass()
        {
            CharacterClassConfigurator.For(CharacterClassRefs.AnimalCompanionClass)
                .AddPrerequisiteNoFeature(GetGUID.EidolonSubtypeFeature)
                .Configure();
        }
    }
}
