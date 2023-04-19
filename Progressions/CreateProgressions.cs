using WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions;

namespace WOTR_MAKING_FRIENDS.Progressions
{
    internal class CreateProgressions
    {
        public static void CreateAllProgressions()
        {
            EidolonProgression.CreateEidolonProgression();
            EidolonBaseProgression.CreateEidolonBaseProgression();
            CreateAllEidolonProgressions.Create();
        }
    }
}
