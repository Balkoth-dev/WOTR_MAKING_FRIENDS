using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffSummonerLifeBond
    {
        private static class InternalString
        {
            internal const string Buff = "SummonerLifeBondBuff";
            internal static LocalizedString Name = Helpers.ObtainString("summonerlifebondfeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("summonerlifebondfeature.Description");
        }
        public static void CreateSummonerLifeBondBuff()
        {
            BuffConfigurator.New(InternalString.Buff, GetGUID.GUIDByName("SummonerLifeBondBuff"))
                .CopyFrom(BuffRefs.OracleRevelationLifeLinkBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeBond.png"))
                .SetStacking(StackingType.Ignore)
                .AddComponent<LifeBond>()
                .Configure();
        }
    }
}
