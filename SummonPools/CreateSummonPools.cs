using BlueprintCore.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.SummonPools
{
    class CreateSummonPools
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
            var summonerPool = SummonPoolConfigurator.New(InternalString.SummonerPool, GetGUID.SummonerPool).Configure();
        }
        public static void CreateDraconicAllyPool()
        {
            var summonerPool = SummonPoolConfigurator.New(InternalString.DraconicAllyPool, GetGUID.DraconicAllyPool).Configure();
        }
    }
}
