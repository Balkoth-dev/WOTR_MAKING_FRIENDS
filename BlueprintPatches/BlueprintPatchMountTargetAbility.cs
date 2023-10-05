using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.BlueprintPatches
{
    internal class BlueprintPatchMountTargetAbility
    {
        public static void Patch()
        {
            var feature = AbilityConfigurator.For(AbilityRefs.MountTargetAbility)
                .AddAbilityTargetHasFact(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EidolonSubtypeFeature")) }, inverted: true)
                .ConfigureWithLogging(true);
        }
    }
}
