﻿using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffSummonerLifeLink
    {
        internal static class IClass
        {
            internal const string Buff = "SummonerLifeLinkBuff";
            internal static LocalizedString Name = Helpers.ObtainString("summonerlifelinkfeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("summonerlifelinkfeature.Description");
        }
        public static void CreateSummonerLifeLinkBuff()
        {
            Kingmaker.ElementsSystem.ActionList applyLifeLink = ActionsBuilder.New().OnPets(ActionsBuilder.New()
                                                            .ApplyBuffPermanent(GetGUID.GUIDByName("SummonerLifeLinkBuff"), isNotDispelable: true)
                                                            .Build(),
                                                            PetTypeExtensions.Eidolon).Build();
            ((ContextActionsOnPet)applyLifeLink.Actions[0]).AllPets = false;

            Kingmaker.ElementsSystem.ActionList disableLifeLink = ActionsBuilder.New().OnPets(ActionsBuilder.New()
                                                            .RemoveBuff(GetGUID.GUIDByName("SummonerLifeLinkBuff"))
                                                            .Build(),
                                                            PetTypeExtensions.Eidolon).Build();

            BuffConfigurator.New(IClass.Buff, GetGUID.GUIDByName("SummonerLifeLinkBuff"))
                .CopyFrom(BuffRefs.OracleRevelationLifeLinkBuff)
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                .AddBuffActions(applyLifeLink, disableLifeLink, applyLifeLink)
                .SetStacking(StackingType.Ignore)
                .AddComponent<LifeLinkEidolon>()
                .ConfigureWithLogging();
        }
    }
}
