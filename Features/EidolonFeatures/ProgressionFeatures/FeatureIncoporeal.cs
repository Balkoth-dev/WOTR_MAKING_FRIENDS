using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Buffs;
using WOTR_MAKING_FRIENDS.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    public static class FeatureAddAbilityIncoporeal
    {
        public static class IClass
        {
            internal static string ProgressionFeature = "Eidolon" + "AddAbilityIncoporeal";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.StygianSlayerShadowyMistForm.Reference.Get().m_Icon;
            internal static FeatureGroup featureGroup = FeatureGroupExtension.EvolutionBase;
            internal static int Ranks = 1;
        }
        public static class IClassBuff
        {
            internal static string Buff = IClass.ProgressionFeature + "Buff";
            internal static string Guid = GetGUID.GUIDByName(Buff);
            internal static string Name = Helpers.ObtainString(Buff + ".Name");
            internal static string Description = Helpers.ObtainString(Buff + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public static class IClassAbility
        {
            internal static string Ability = IClass.ProgressionFeature + "Ability";
            internal static string Guid = GetGUID.GUIDByName(Ability);
            internal static string Name = Helpers.ObtainString(Ability + ".Name");
            internal static string Description = Helpers.ObtainString(Ability + ".Description");
            internal static Sprite Icon = IClass.Icon;
            internal static int Ranks = 1;
        }
        public static void Create()
        {
            CreateFeature();
            CreateBuff();
            CreateAbility();
        }
        internal static void CreateFeature()
        {
            FeatureConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .AddFacts(new() { BlueprintTool.GetRef<BlueprintUnitFactReference>(IClassAbility.Guid) })
                    .SetGroups(IClass.featureGroup)
                    .ConfigureWithLogging();
        }
        internal static void CreateBuff()
        {
            BuffConfigurator.New(IClassBuff.Buff, IClassBuff.Guid)
                .CopyFrom(BuffRefs.BloodragerUndeadIncorporealBloodragerEffectBuff, c => true)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.CanNotAttack)
                .SetDisplayName(IClass.Name)
                .SetDisplayName(IClass.Description)
                .SetIcon(IClass.Icon)
                .ConfigureWithLogging();
        }
        internal static void CreateAbility()
        {
            ActivatableAbilityConfigurator.New(IClassAbility.Ability, IClassAbility.Guid)
                .SetDisplayName(IClass.Name)
                .SetDisplayName(IClass.Description)
                .SetIcon(IClass.Icon)
                .SetBuff(IClassBuff.Guid)
                .AddActivatableAbilityUnitCommand(type:Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard)
                .ConfigureWithLogging();
        }
    }
}
