using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.BlueprintPatches
{
    internal class CreateBlueprintPatches
    {
        public static void CreateAllBlueprintPatches()
        {
            BlueprintPatchAnimalCompanionClass.PatchAnimalCompanionClass();
        }
    }
}
