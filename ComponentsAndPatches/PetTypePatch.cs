using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOTR_MAKING_FRIENDS.ComponentsAndPatches
{
    [HarmonyPatch(typeof(Kingmaker.Enums.PetType))]
    public static class PetTypePatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Kingmaker.Enums.PetType.GetValues), MethodType.Getter)]
        public static Kingmaker.Enums.PetType[] AddNewPetType(Kingmaker.Enums.PetType[] __result)
        {
            // Create a new array to hold the existing pet types plus the new Eidolon value
            Kingmaker.Enums.PetType[] newResult = new Kingmaker.Enums.PetType[__result.Length + 1];

            // Copy the existing pet types into the new array
            for (int i = 0; i < __result.Length; i++)
            {
                newResult[i] = __result[i];
            }

            // Add the new Eidolon value to the end of the new array
            newResult[newResult.Length - 1] = (Kingmaker.Enums.PetType)PetType.Eidolon;

            // Return the new array
            return newResult;
        }

        public enum PetType
        {
            Eidolon = 604767
        }
    }

}
