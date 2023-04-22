using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using WOTR_MAKING_FRIENDS.CharacterClass;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace WOTR_MAKING_FRIENDS.Classes.EidolonClasses
{
    internal class EidolonBaseClass
    {
        private static class InternalString
        {
            internal const string ClassName = "EidolonBaseClass";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonBaseClass.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonBaseClass.Description");
        }
        public static void CreateEidolonBaseClass()
        {
            CharacterClassConfigurator.New(InternalString.ClassName, GetGUID.GUIDByName(InternalString.ClassName))
                .SetLocalizedName(InternalString.Name)
                .SetLocalizedDescription(InternalString.Description)
                .SetSkillPoints(3)
                .SetHitDie(DiceType.D10)
                .SetPrestigeClass(false)
                .SetIsMythic(false)
                .SetHideIfRestricted(true)
                .SetBaseAttackBonus(StatProgressionRefs.BABFull.Reference.Get())
                .SetIsDivineCaster(false)
                .SetIsArcaneCaster(false)
                .SetStartingGold(0)
                .SetDifficulty(1)
                .AddToClassSkills(
                StatType.SkillPerception)
                .AddPrerequisiteIsPet(group:GroupType.Any,checkInProgression:false,hideInUI:false,not:false)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonSubtypeFeature")))
                .ConfigureWithLogging();

        }
    }
}
