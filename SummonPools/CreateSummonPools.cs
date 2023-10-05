using BlueprintCore.Blueprints.Configurators;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.SummonPools
{
    internal class CreateSummonPools
    {
        internal static class IClass
        {
            internal const string SummonerPool = "SummonerPool";
            internal const string DraconicAllyPool = "DraconicAlly";
        }
        public static void CreateAllSummonPools()
        {
            CreateSummonerPool();
            CreateDraconicAllyPool();
        }
        public static void CreateSummonerPool()
        {
            SummonPoolConfigurator.New(IClass.SummonerPool, GetGUID.GUIDByName("SummonerPool")).ConfigureWithLogging();
        }
        public static void CreateDraconicAllyPool()
        {
            SummonPoolConfigurator.New(IClass.DraconicAllyPool, GetGUID.GUIDByName("DraconicAllyPool")).ConfigureWithLogging();
        }
    }
}
