using BlueprintCore.Blueprints.CustomConfigurators;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Resources
{
    internal class ResourceMaxAttacksResource
    {
        public static void Create()
        {
            Kingmaker.Blueprints.BlueprintAbilityResource.Amount maxAmount = ResourceAmountBuilder.New(3).Build();
            AbilityResourceConfigurator.New("EidolonMaxAttacksResource", GetGUID.GUIDByName("EidolonMaxAttacksResource"))
                .SetMaxAmount(maxAmount)
                .ConfigureWithLogging();
        }
    }
}
