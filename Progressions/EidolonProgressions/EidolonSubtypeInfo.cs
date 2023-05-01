using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonSubtypeInfo
    {
        public static EidolonSubtypeProgression[] eidolonSubtypes =
        {
            #region Aberrant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Aberrant,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Abberant,
                        EnumsEidolonBaseForm.Quadruped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },

            #endregion
            #region Aeon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Aeon,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1,  GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.Fortification50Feature),GetRefs.BFBRCast(FeatureRefs.TripImmunityFeature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(AbilityRefs.CrushingDespair))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.TrueStrike)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Agathion
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Agathion,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.LayOnHandsFeature))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.DREvil10)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Quadruped
                    }
                },
            #endregion
            #region Ancestor
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Ancestor,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.Fortification50Feature), GetRefs.BFBRCast(FeatureRefs.TripImmunityFeature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(AbilityRefs.CrushingDespair))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.TrueStrike)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped
                    }
                },
            #endregion
            #region Angel
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Angel,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1,
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4,
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ColdImmunity),
                                GetRefs.BFBRCast(FeatureRefs.AcidImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.HolyAura)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped
                    }
                },
            #endregion
            #region Archon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Archon,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity),
                                GetRefs.BFBRCast(AbilityRefs.FrightfulAspect))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.DimensionDoor)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped
                    }
                },
            #endregion
            #region Astral
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Astral,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Azata
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Azata,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Daemon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Daemon,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRGood5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.AcidImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.TrueStrike)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Abberant,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Deepwater
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Deepwater,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRMagic5))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ColdImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.FastHealing)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Demon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Demon,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRGood5))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.TrueSeeing)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Abberant,
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Quadruped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Devil
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Devil,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRGood5))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.FireImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.FastHealing)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Div
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Div,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRGood5))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.FireImmunity))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.DimensionDoor)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Elemental
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Elemental,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.UncannyDodge),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToBleed),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical),
                                GetRefs.BFBRCast(FeatureRefs.DRImmune_PrecisionDamage))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.TrueStrike)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Abberant,
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Genie
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Genie,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Inevitable
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Inevitable,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.DRChaotic10))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToAbilityDamage),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Kami
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Kami,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Kyton
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Kyton,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Plant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Plant,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.SonicImmunity),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)),
                    hide = true
                },
            #endregion
            #region Protean
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Protean,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRLawful15),
                                GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.AcidImmunity),
                                GetRefs.BFBRCast(FeatureRefs.AmorphousAnatomyFeature))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.FreedomOfMovement),
                                GetRefs.BFBRCast(AbilityRefs.PolymorphGreaterBase)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Psychopomp
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Psychopomp,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.DRAdamantine5))
                                    .AddEntry(16, GetRefs.BFBRCast(AbilityRefs.Invisibility))
                                    .AddEntry(20, GetRefs.BFBRCast(FeatureRefs.DRAdamantine10),
                                GetRefs.BFBRCast(FeatureRefs.ColdImmunity),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Quadruped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Radiant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Radiant,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain))
                                    .AddEntry(4, GetRefs.BFBRCast(AbilityRefs.MageLight))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.FastHealing))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Quadruped,
                    }
                },
            #endregion
            #region Shadow
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Shadow,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(AbilityRefs.Bane))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.DRMagic5))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.DRMagic10),
                                GetRefs.BFBRCast(FeatureRefs.SpellResistance10plusCR))
                                    .AddEntry(20, GetRefs.BFBRCast(AbilityRefs.DimensionDoor)),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Storykin
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Storykin,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                        EnumsEidolonBaseForm.Quadruped,
                        EnumsEidolonBaseForm.Serpentine,
                    }
                },
            #endregion
            #region Twinned
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Twinned,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
            #region Void
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Void,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1,GetRefs.BFBRCast(FeatureRefs.NegativeEnergyAffinity),
                                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain),
                                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison))
                                    .AddEntry(4, GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature))
                                    .AddEntry(8, GetRefs.BFBRCast(FeatureRefs.Airborne))
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.ColdImmunity), GetRefs.BFBRCast(FeatureRefs.DRAdamantine5))
                                    .AddEntry(16, GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical))
                                    .AddEntry(20, GetGUID.GUIDByName("dummyBuff")),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
        };
    }
}
