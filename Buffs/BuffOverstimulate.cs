using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    internal class BuffOverstimulate
    {
        internal static class IClass
        {
            internal const string OverstimulateBuff = "OverstimulateBuff";
            internal static LocalizedString OverstimulateSpellName = Helpers.ObtainString("OverstimulateSpell.Name");
            internal static LocalizedString OverstimulateSpellDescription = Helpers.ObtainString("OverstimulateSpell.Description");
        }
        public static void CreateOverstimulateBuff()
        {
            BuffConfigurator.New(IClass.OverstimulateBuff, GetGUID.GUIDByName("OverstimulateBuff"))
                .CopyFrom(BuffRefs.RageBuff)
                .SetDisplayName(IClass.OverstimulateSpellName)
                .SetDescription(IClass.OverstimulateSpellDescription)
                .AddContextRankConfig(ContextRankConfigs.CasterLevel())
                .AddMechanicsFeature(Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature.MechanicsFeatureType.Ferocity)
                .ConfigureWithLogging();
        }
    }
}
