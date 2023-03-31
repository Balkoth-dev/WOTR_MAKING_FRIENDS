using BlueprintCore.Blueprints.Configurators;
using WOTR_MAKING_FRIENDS.GUIDs;

namespace WOTR_MAKING_FRIENDS.SummonPools
{
    internal class CreateSummonPools
    {
        internal static class InternalString
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
            SummonPoolConfigurator.New(InternalString.SummonerPool, GetGUID.SummonerPool).Configure();
        }
        public static void CreateDraconicAllyPool()
        {
            SummonPoolConfigurator.New(InternalString.DraconicAllyPool, GetGUID.DraconicAllyPool).Configure();
        }
    }
}
