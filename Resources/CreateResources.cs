namespace WOTR_MAKING_FRIENDS.Resources
{
    internal class CreateResources
    {
        public static void CreateAllResources()
        {
            ResourceMakersCall.Create();
            ResourceEvolutionPoints.Create();
            ResourceMaxAttacksResource.Create();
        }
    }
}
