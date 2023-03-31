using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Buffs
{
    class OverstimulateBuff
    {
        private static class InternalString
        {
            internal const string OverstimulateBuff = "OverstimulateBuff";
            internal static LocalizedString OverstimulateSpellName = Helpers.ObtainString("OverstimulateSpell.Name");
            internal static LocalizedString OverstimulateSpellDescription = Helpers.ObtainString("OverstimulateSpell.Description");
        }
        public static void CreateOverstimulateBuff()
        {
            BuffConfigurator.New(InternalString.OverstimulateBuff, GetGUID.OverstimulateBuff)
                .CopyFrom(BuffRefs.RageBuff, c => c is null)
                .SetDisplayName(InternalString.OverstimulateSpellName)
                .SetDescription(InternalString.OverstimulateSpellDescription)
                .AddContextRankConfig(ContextRankConfigs.CasterLevel())
                .AddMechanicsFeature(Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature.MechanicsFeatureType.Ferocity)
                .Configure();
        }
    }
}
