using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using WOTR_MAKING_FRIENDS.CharacterClass;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace WOTR_MAKING_FRIENDS.Classes.EidolonClasses
{
    internal class EidolonBaseClass
    {
        private static class InternalClass
        {
            internal const string ClassName = "EidolonBaseClass";
            internal static LocalizedString Name = Helpers.ObtainString("EidolonBaseClass.Name");
            internal static LocalizedString Description = Helpers.ObtainString("EidolonBaseClass.Description");
        }
        public static void CreateEidolonBaseClass()
        {
            CharacterClassConfigurator.New(InternalClass.ClassName, GetGUID.GUIDByName(InternalClass.ClassName))
                .SetLocalizedName(InternalClass.Name)
                .SetLocalizedDescription(InternalClass.Description)
                .SetSkillPoints(3)
                .SetHitDie(DiceType.D10)
                .SetPrestigeClass(false)
                .SetIsMythic(false)
                .SetHideIfRestricted(true)
                .SetBaseAttackBonus(StatProgressionRefs.BABMedium.Reference.Get())
                .SetIsDivineCaster(false)
                .SetIsArcaneCaster(false)
                .SetStartingGold(0)
                .SetDifficulty(1)
                .SetProgression(GetGUID.GUIDByName("EidolonBaseProgression"))
                .AddToClassSkills(
                StatType.SkillPerception)
                .AddPrerequisiteIsPet(group:GroupType.Any,checkInProgression:false,hideInUI:false,not:false)
                .AddPrerequisiteFeature(BlueprintTool.GetRef<BlueprintFeatureReference>(GetGUID.GUIDByName("EidolonSubtypeFeature")))
                .ConfigureWithLogging();

        }
    }
}
