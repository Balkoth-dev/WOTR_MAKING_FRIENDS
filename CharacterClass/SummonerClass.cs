﻿using BlueprintCore.Blueprints.Configurators.Classes;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using Kingmaker.RuleSystem;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    class SummonerClass
    {
        private static class InternalString
        {
            internal const string SummonerClass = "Summoner";
            internal static readonly LocalizedString SummonerClassName = Helpers.ObtainString(SummonerClass + ".Name");
            internal static readonly LocalizedString SummonerClassDescription = Helpers.ObtainString(SummonerClass + ".Description");
        }
        public static void CreateSummonerClass()
        {
            BlueprintCharacterClass summonerClass = CharacterClassConfigurator.New(InternalString.SummonerClass, GetGUID.SummonerClass).Configure();

            var summonerProgression = SummonerProgression.Initialize();
            var arcanistSpellbook = SpellbookRefs.ArcanistSpellbook.Reference.Get();

            CharacterClassConfigurator.For(GetGUID.SummonerClass)
                .SetLocalizedName(InternalString.SummonerClassName)
                .SetLocalizedDescription(InternalString.SummonerClassDescription)
                .SetSpellbook(arcanistSpellbook)
                .SetProgression(summonerProgression)
                .SetSkillPoints(1)
                .SetHitDie(DiceType.D8)
                .SetPrestigeClass(false)
                .SetIsMythic(false)
                .SetHideIfRestricted(false)
                .SetBaseAttackBonus(StatProgressionRefs.BABMedium.Reference.Get())
                .SetFortitudeSave(StatProgressionRefs.SavesLow.Reference.Get())
                .SetReflexSave(StatProgressionRefs.SavesLow.Reference.Get())
                .SetWillSave(StatProgressionRefs.SavesHigh.Reference.Get())
                .SetIsDivineCaster(false)
                .SetIsArcaneCaster(true)
                .SetStartingGold(111)
                .SetStartingItems(
                ItemWeaponRefs.ColdIronMasterworkHeavyCrossbow.Reference.Get(),
                ItemArmorRefs.LeatherStandard.Reference.Get(),
                ItemEquipmentUsableRefs.PotionOfCureLightWounds.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageArmor.Reference.Get(),
                ItemEquipmentUsableRefs.ScrollOfMageShield.Reference.Get())
                .SetPrimaryColor(0)
                .SetSecondaryColor(0)
                .SetDifficulty(1)
                .AddToMaleEquipmentEntities("65e7ae8b40be4d64ba07d50871719259", "04244d527b8a1f14db79374bc802aaaa")
                .AddToFemaleEquipmentEntities("11266d19b35cb714d96f4c9de08df48e", "64abd9c4d6565de419f394f71a2d496f")
                .AddToClassSkills(
                StatType.SkillMobility,
                StatType.SkillKnowledgeWorld,
                StatType.SkillKnowledgeArcana,
                StatType.SkillUseMagicDevice)
                .AddToRecommendedAttributes(StatType.Charisma)
                .AddPrerequisiteIsPet(false, Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite.GroupType.All, true, true)
                .Configure();


            BlueprintCharacterClassReference classref = summonerClass.ToReference<BlueprintCharacterClassReference>();
            BlueprintRoot root = BlueprintTool.Get<BlueprintRoot>("2d77316c72b9ed44f888ceefc2a131f6");
            root.Progression.m_CharacterClasses = CommonTool.Append(root.Progression.m_CharacterClasses, classref);
        }
    }
}