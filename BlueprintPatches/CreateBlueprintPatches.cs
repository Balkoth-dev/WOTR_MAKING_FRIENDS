namespace WOTR_MAKING_FRIENDS.BlueprintPatches
{
    internal class CreateBlueprintPatches
    {
        public static void CreateAllBlueprintPatches()
        {
            BlueprintPatchAnimalCompanionClass.Patch();
            BlueprintPatchMountTargetAbility.Patch();
        }
    }
}
