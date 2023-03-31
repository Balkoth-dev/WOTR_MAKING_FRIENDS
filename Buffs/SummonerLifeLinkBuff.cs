using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using WOTR_MAKING_FRIENDS.ComponentsAndPatches;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    class SummonerLifeLinkBuff
    {
        private static class InternalString
        {
            internal const string Buff = "SummonerLifeLinkBuff";
            internal static LocalizedString Name = Helpers.ObtainString("summonerlifelinkfeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("summonerlifelinkfeature.Description");
        }
        public static void CreateSummonerLifeLinkBuff()
        {
            var applyLifeLink = ActionsBuilder.New().OnPets(ActionsBuilder.New()
                                                            .ApplyBuffPermanent(GetGUID.SummonerLifeLinkBuff, isNotDispelable: true)
                                                            .Build(),
                                                            PetTypeExtensions.Eidolon).Build();

            var disableLifeLink = ActionsBuilder.New().OnPets(ActionsBuilder.New()
                                                            .RemoveBuff(GetGUID.SummonerLifeLinkBuff)
                                                            .Build(),
                                                            PetTypeExtensions.Eidolon).Build();

            BuffConfigurator.New(InternalString.Buff, GetGUID.SummonerLifeLinkBuff)
                .CopyFrom(BuffRefs.OracleRevelationLifeLinkBuff, c => c is null)
                .SetDisplayName(InternalString.Name)
                .SetDescription(InternalString.Description)
                .AddBuffActions(applyLifeLink, disableLifeLink, applyLifeLink)
                .SetStacking(StackingType.Ignore)
                .AddComponent<LifeLinkEidolon>()
                .Configure();
        }
    }
}
