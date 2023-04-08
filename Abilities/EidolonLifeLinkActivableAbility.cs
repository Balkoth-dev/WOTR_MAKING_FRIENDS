using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WOTR_MAKING_FRIENDS.SummonPools.CreateSummonPools;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using Kingmaker.Localization;

namespace WOTR_MAKING_FRIENDS.Abilities
{
    internal class EidolonLifeLinkActivableAbility
    {
        private static class InternalString
        {
            internal static LocalizedString Name = Helpers.ObtainString("SummonerLifeLinkFeature.Name");
            internal static LocalizedString Description = Helpers.ObtainString("SummonerLifeLinkFeature.Description");
            internal const string ActivatableAbility = "SummonerLifeLinkActivatableAbility";
        }
        public static void CreateEidolonLifeLinkActivatableAbility()
        {
            ActivatableAbilityConfigurator.New(InternalString.ActivatableAbility, GetGUID.SummonerLifeLinkActivatableAbility)
                                          .SetDisplayName(InternalString.Name)
                                          .SetDescription(InternalString.Description)
                                          .SetBuff(BlueprintTool.GetRef<BlueprintBuffReference>(GetGUID.SummonerLifeLinkBuff))
                                          .SetIcon(AbilityRefs.OracleRevelationLifeLinkAbility.Cast<BlueprintAbilityReference>().Reference.Get().m_Icon)
                                          .SetDeactivateIfOwnerUnconscious(true)
                                          .SetDeactivateIfOwnerDisabled(true)
                                          .SetIsOnByDefault(true)
                                          .SetDoNotTurnOffOnRest(false)
                                          .SetIcon(AssetLoader.LoadInternal("Abilities", "LifeLink.png"))
                                          .SetActivationType(Kingmaker.UnitLogic.ActivatableAbilities.AbilityActivationType.Immediately)
                                          .Configure();
        }
    }
}
