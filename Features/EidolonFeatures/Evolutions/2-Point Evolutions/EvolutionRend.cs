using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using UnityEngine;
using WOTR_MAKING_FRIENDS.ComponentsNew;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._2_Point_Evolutions
{
    internal class EvolutionRend
    {
        internal static class IClass
        {
            internal static Sprite icon = ActivatableAbilityRefs.TigerGrabActivatableAbility.Reference.Get().m_Icon;
            internal const string Evolution = "EvolutionRend";
            internal const string Feature = Evolution + "Feature";
            internal const string BaseFeature = Evolution + "BaseFeature";
            internal const string Ability = Evolution + "Ability";
        }
        public static void Adjust()
        {
            AdjustFeature();
            AdjustAbility();
        }
        public static void AdjustFeature()
        {
            FeatureConfigurator.For(GetGUID.GUIDByName(IClass.Feature))
                .SetIcon(IClass.icon)
                .AddComponent<WeaponRend>(c =>
                {
                    c.RendDamage = new DiceFormula { m_Rolls = 1, m_Dice = DiceType.D6 };
                    c.RendType = new DamageTypeDescription
                    {
                        Common = new DamageTypeDescription.CommomData(),
                        Energy = DamageEnergyType.Fire,
                        Type = DamageType.Physical,
                        Physical = new() { Material = 0, Form = PhysicalDamageForm.Slashing, Enhancement = 0, EnhancementTotal = 0 }
                    };
                    c.SpellDescriptor = SpellDescriptor.Polymorph;
                    c.CheckBuff = false;
                    c.CheckShapeshift = false;
                    c.Action = new ActionList();
                    c.Category = new WeaponCategory[] { WeaponCategory.Claw };
                    c.UseMythicLevel = false;
                    c.ApplyStrengthBonus = true;
                })
                .ConfigureWithLogging(true);
        }

        public static void AdjustAbility()
        {
            AbilityConfigurator.For(GetGUID.GUIDByName(IClass.Ability))
                .SetIcon(IClass.icon)
                .AddComponent<AbilityCasterHasFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionClawsFeature"))
                    };
                })
                .AddComponent<AbilityCasterHasFactRank>(c =>
                {
                    c.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Feature));
                    c.startLevel = 6;
                })
                .AddComponent<AbilityCasterHasNoFacts>(c =>
                {
                    c.m_Facts = new BlueprintUnitFactReference[]
                    {
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.Feature)),
                        BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName(IClass.BaseFeature))
                    };
                })
                .ConfigureWithLogging(true);
        }
    }
}
