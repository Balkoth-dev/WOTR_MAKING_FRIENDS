using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Critters;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Units
{
    public static class NewUnits
    {
        public class NewUnit
        {
            /// <summary> GUID of the variant spell. </summary>
            internal string guid;
            /// <summary> Internal name of the ability </summary>
            internal string name;
            /// <summary> Name of the ability that is shown to the player. </summary>
            internal LocalizedString m_DisplayName;
            /// <summary> Unit to copy from. Helpful for body/brain/etc. </summary>
            internal BlueprintUnitReference copiedUnit;
            /// <summary> Model used for the unit. Leave null if same as copied unit. </summary>
            internal AssetLink<UnitViewLink> prefab;
            /// <summary> Portrait used for the unit. Leave null if same as copied unit. </summary>
            internal Blueprint<BlueprintPortraitReference> portrait;
            internal Size? size;
            internal int? strength;
            internal int? dexterity;
            internal int? constitution;
            internal int? intelligence;
            internal int? wisdom;
            internal int? charisma;
            internal Blueprint<BlueprintUnitFactReference>[] blueprintUnitFactReferences;
        };

        public static NewUnit[] newUnits =
            {
                new NewUnit()
                {
                    guid = GetGUID.RedPandaSummon,
                    name = "RedPandaSummon",
                    m_DisplayName = Helpers.ObtainString("RedPandaSummon.Name"),
                    copiedUnit = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                    prefab = UnitRefs.RedPandaFamiliar.Reference.Get().Prefab,
                    size = Size.Tiny,
                    strength = 8,
                    dexterity = 16,
                    constitution = 11,
                    intelligence = 2,
                    wisdom = 13,
                    charisma = 5,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[] 
                                                  {
                                                    FeatureRefs.TripDefenseFourLegs.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.CatSummon,
                    name = "CatSummon",
                    m_DisplayName = Helpers.ObtainString("CatSummon.Name"),
                    copiedUnit = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                    prefab = UnitRefs.CatFamiliar.Reference.Get().Prefab,
                    size = Size.Tiny,
                    strength = 3,
                    dexterity = 15,
                    constitution = 8,
                    intelligence = 2,
                    wisdom = 12,
                    charisma = 7,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.TripDefenseFourLegs.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.CacodaemonSummon,
                    name = "CacodaemonSummon",
                    m_DisplayName = Helpers.ObtainString("CacodaemonSummon.Name"),
                    copiedUnit = UnitRefs.GibrilethSummon.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 12,
                    dexterity = 11,
                    constitution = 13,
                    intelligence = 8,
                    wisdom = 13,
                    charisma = 12,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.TripImmune.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeDaemon.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeEvil.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.DemonPlagueFeature.Cast<BlueprintUnitFactReference>().Reference,
                                                    UnitFactRefs.NaturalArmor4.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonBlack,
                    name = "DraconicAllySummonBlack",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonIBlackBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonBlue,
                    name = "DraconicAllySummonBlue",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonIBlueBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonBrass,
                    name = "DraconicAllySummonBrass",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonIBrassBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonGreen,
                    name = "DraconicAllySummonGreen",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonIGreenBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonRed,
                    name = "DraconicAllySummonRed",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonIGoldBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonSilver,
                    name = "DraconicAllySummonSilver",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.DraconicAllySummonWhite,
                    name = "DraconicAllySummonWhite",
                    m_DisplayName = Helpers.ObtainString("DraconicAllySummon.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Tiny,
                    strength = 7,
                    dexterity = 15,
                    constitution = 13,
                    intelligence = 10,
                    wisdom = 12,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToParalysis.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToSleep.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.FormOfTheDragonISilverBreathWeaponAbility.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.LesserDemonSummonBrimorak,
                    name = "LesserDemonSummonBrimorak",
                    copiedUnit = UnitRefs.CR5_BrimorakStandard.Cast<BlueprintUnitReference>().Reference
                },
                new NewUnit()
                {
                    guid = GetGUID.LesserDemonSummonIncubus,
                    name = "LesserDemonSummonIncubus",
                    copiedUnit = UnitRefs.CR6_IncubusStandard.Cast<BlueprintUnitReference>().Reference
                },
                new NewUnit()
                {
                    guid = GetGUID.LesserDemonSummonSchir,
                    name = "LesserDemonSummonSchir",
                    copiedUnit = UnitRefs.CR4_SchirStandard.Cast<BlueprintUnitReference>().Reference
                },
                new NewUnit()
                {
                    guid = GetGUID.LesserDemonSummonVermlek,
                    name = "LesserDemonSummonVermlek",
                    copiedUnit = UnitRefs.CR3_VermlekStandard.Cast<BlueprintUnitReference>().Reference
                },
                new NewUnit()
                {
                    guid = GetGUID.StampedeSummonHorse,
                    name = "StampedeSummonHorse",
                    copiedUnit = UnitRefs.HorseSummoned.Cast<BlueprintUnitReference>().Reference,
                    size = Size.Fine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.TripImmunityFeature.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference,
                                                    UnitFactRefs.ReducedReach.Cast<BlueprintUnitFactReference>().Reference,
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.StampedeTrampleDamageImmunityBuff),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.StampedeTrampleDamageAreaBuff)
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.ReleaseTheHoundsWolf,
                    name = "ReleaseTheHoundsWolf",
                    copiedUnit = UnitRefs.WolfSummon.Cast<BlueprintUnitReference>().Reference,
                    m_DisplayName = Helpers.ObtainString("ReleaseTheHoundsWolf.Name"),
                    size = Size.Fine,
                    strength = 20,
                    dexterity = 13,
                    constitution = 18,
                    intelligence = 9,
                    wisdom = 13,
                    charisma = 10,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.TripDefenseFourLegs.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.FireVulnerability.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ColdImmunity.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.TrippingBite.Cast<BlueprintUnitFactReference>().Reference,
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.ReleaseTheHoundsDamageAreaBuff)
                                                  }
                },
                new NewUnit()
                {
                    guid = GetGUID.ErinyesSummon,
                    name = "ErinyesSummon",
                    copiedUnit = UnitRefs.CR8_ErinyesDevilStandard.Cast<BlueprintUnitReference>().Reference
                },
                new NewUnit()
                {
                    guid = GetGUID.MeladaemonSummon,
                    name = "MeladaemonSummon",
                    copiedUnit = UnitRefs.CR7_Werewolf.Cast<BlueprintUnitReference>().Reference,
                    m_DisplayName = Helpers.ObtainString("MeladaemonSummon.Name"),
                    size = Size.Large,
                    strength = 22,
                    dexterity = 22,
                    constitution = 21,
                    intelligence = 21,
                    wisdom = 17,
                    charisma = 18,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.DRGood10.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeDaemon.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeEvil.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.AcidImmunity.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToCritical.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToDeathEffects.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToDisease.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ImmunityToPoison.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ColdResistance10.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.ElectricityResistance10.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.FireResistance10.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SpellResistance10plusCR.Cast<BlueprintUnitFactReference>().Reference,
                                                    BuffRefs.SeeInvisibilitytBuff.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.UnholyBlight.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.HorridWilting.Cast<BlueprintUnitFactReference>().Reference,
                                                    AbilityRefs.WavesOfFatigue.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                },
            };

    }
}
