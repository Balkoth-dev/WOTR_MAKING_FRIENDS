using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonSubtypes
    {
        public static EidolonSubtypeProgression[] eidolonSubtypes =
        {
            #region Aberrant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Aberrant,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, FeatureResistance4Mind.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(8, FeatureImmunityMind.IClass.Guid)
                                    .AddEntry(12, FeatureDR5Slashing.IClass.Guid,GetGUID.GUIDByName("EvolutionScentBaseFeature"))
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionBlindsightBaseFeature"))
                                    .AddEntry(20, FeatureAddSpellTransmogrify.IClass.Guid),
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
                                    .AddEntry(1,  FeatureResistance4Mind.IClass.Guid)
                                    .AddEntry(4, FeatureModerateFortification.IClass.Guid,GetRefs.BFBRCast(FeatureRefs.TripImmunityFeature))
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, FeatureAeonSelectionFeature.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionAmorphousBaseFeature"),FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(20, FeatureAddSpellTrueStrike.IClass.Guid),
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
                                    .AddEntry(1, FeatureResistance4Poison.IClass.Guid, GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"))
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),GetGUID.GUIDByName("EvolutionResistanceSonicBaseFeature"))
                                    .AddEntry(8, FeatureAddFeatureLayOnHands.IClass.Guid)
                                    .AddEntry(12, FeatureDR5Evil.IClass.Guid,
                                                  FeatureImmunityPetrification.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityElectricity"))
                                    .AddEntry(20, FeatureDR10Evil.IClass.Guid),
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
                    },
                    hide = true
                },
            #endregion
            #region Angel
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Angel,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1,
                                GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"),
                                GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),
                                FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4,
                                GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),
                                GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, FeatureDR5Evil.IClass.Guid,
                                                  FeatureImmunityPetrification.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature"),
                                GetGUID.GUIDByName("EvolutionImmunityAcidBaseFeature"))
                                    .AddEntry(20, FeatureAddSpellHolyAura.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),
                                                 FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(8, FeatureAbilityIncreaseSelection.IClass.Guid)
                                    .AddEntry(12, FeatureDR5Evil.IClass.Guid,
                                                  FeatureImmunityPetrification.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityElectricityBaseFeature"),
                                                  FeatureFrightfulPresence.IClass.Guid)
                                    .AddEntry(20, FeatureAddSpellDimensionDoor.IClass.Guid),
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
                                    .AddEntry(1, FeatureResistance4Curses.IClass.Guid,FeatureResistance4Disease.IClass.Guid,FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, FeatureAugmentSummoningMaster.IClass.Guid)
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, FeatureSuperiorSummoningMaster.IClass.Guid)
                                    .AddEntry(16, FeatureImmunityCurse.IClass.Guid,FeatureImmunityDisease.IClass.Guid,FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(20, FeatureAscendantSummonsMaster.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),GetRefs.BFBRCast(FeatureRefs.MartialWeaponProficiency))
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, FeatureDR5Evil.IClass.Guid,
                                                  FeatureImmunityPetrification.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityElectricityBaseFeature"))
                                    .AddEntry(20, FeatureAddAbilityIncoporeal.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"),
                                                 FeatureResistance4Poison.IClass.Guid,FeatureResistance4Death.IClass.Guid,FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(12,FeatureDR5Good.IClass.Guid,
                                                 FeatureImmunityDeath.IClass.Guid,
                                                 FeatureImmunityDisease.IClass.Guid,
                                                 FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityAcidBaseFeature"))
                                    .AddEntry(20, FeatureAddAbilityConsumeFear.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"))
                                    .AddEntry(4, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, FeatureDR5Magic.IClass.Guid,GetGUID.GUIDByName("EvolutionRendBaseFeature"))
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature"))
                                    .AddEntry(20, GetGUID.GUIDByName("EvolutionFastHealingBaseFeature"),FeatureFreedomOfMovement.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),
                                GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),
                                FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"),GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"))
                                    .AddEntry(8, FeatureImmunityPoison.IClass.Guid,GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(12, FeatureDR5Good.IClass.Guid,FeatureAbilityIncreaseSelection.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityElectricityBaseFeature"))
                                    .AddEntry(20, FeatureAddSpellTrueSeeing.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),
                                                 FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"),
                                GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"))
                                    .AddEntry(8, FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(12, FeatureDR5Good.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityFireBaseFeature"))
                                    .AddEntry(20, GetGUID.GUIDByName("EvolutionFastHealingBaseFeature")),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),
                                                 FeatureResistance4Poison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"))
                                    .AddEntry(8, FeatureImmunityPoison.IClass.Guid,GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(12, FeatureDR5Good.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityFireBaseFeature"))
                                    .AddEntry(20, FeatureAddSpellDimensionDoor.IClass.Guid),
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
                                    .AddEntry(1, FeatureElemental1.IClass.Guid,
                                                 FeatureImmunityParalysis.IClass.Guid,
                                                 FeatureImmunitySleep.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(8, FeatureElemental8.IClass.Guid)
                                    .AddEntry(12, GetRefs.BFBRCast(FeatureRefs.UncannyDodge),
                                                  FeatureImmunityBleed.IClass.Guid,
                                                  FeatureImmunityPoison.IClass.Guid,
                                                  FeatureImmunityStun.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionAmorphousBaseFeature"))
                                    .AddEntry(20, FeatureElemental20.IClass.Guid),
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
                    },
                    hide = true
                },
            #endregion
            #region Inevitable
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Inevitable,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1, FeatureResistance4Death.IClass.Guid,FeatureResistance4Disease.IClass.Guid,FeatureResistance4Paralysis.IClass.Guid)
                                    .AddEntry(4, FeatureResistance4Mind.IClass.Guid)
                                    .AddEntry(8, FeatureImmunityDeath.IClass.Guid,
                                                 FeatureImmunityDisease.IClass.Guid,
                                                 FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(12, FeatureImmunitySleep.IClass.Guid,
                                                  FeatureDR5Chaotic.IClass.Guid)
                                    .AddEntry(16, FeatureImmunityAbilityDamage.IClass.Guid,
                                                  FeatureImmunityEnergyDrain.IClass.Guid)
                                    .AddEntry(20, FeatureImmunityParalysis.IClass.Guid,
                                                  FeatureImmunitySleep.IClass.Guid,
                                                  FeatureImmunityStun.IClass.Guid,
                                                  FeatureImmunityFortitudeSave.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceFireBaseFeature"),GetRefs.BFBRCast(FeatureRefs.MartialWeaponProficiency))
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"), GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"))
                                    .AddEntry(8, FeatureAddAbilityDivineTroth.IClass.Guid)
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, FeatureImmunityBleed.IClass.Guid, FeatureImmunityMind.IClass.Guid, FeatureImmunityPetrification.IClass.Guid)
                                    .AddEntry(20, GetGUID.GUIDByName("EvolutionFastHealingBaseFeature")),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"), GetRefs.BFBRCast(FeatureRefs.TongiProficiency))
                                    .AddEntry(4, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(8, FeatureAddAbilityUnnervingGaze.IClass.Guid)
                                    .AddEntry(12, FeatureAddAbilityUnnervingGazeArea.IClass.Guid,FeatureDR5Good.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature"), FeatureAddAbilityUnnervingGazeAreaStagger.IClass.Guid)
                                    .AddEntry(20, GetGUID.GUIDByName("EvolutionFastHealingBaseFeature")),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceAcidBaseFeature"))
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceSonicBaseFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(12, FeatureDR5Lawful.IClass.Guid,
                                                  GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityAcidBaseFeature"),
                                                  GetGUID.GUIDByName("EvolutionAmorphousBaseFeature"))
                                    .AddEntry(20, FeatureFreedomOfMovement.IClass.Guid),
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
                                    .AddEntry(1, FeatureImmunityDeath.IClass.Guid, FeatureImmunityDisease.IClass.Guid, FeatureImmunityPoison.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceElectrictyBaseFeature"))
                                    .AddEntry(8, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(12, FeatureDR5Adamantine.IClass.Guid)
                                    .AddEntry(16, FeatureAbilityIncreaseSelection.IClass.Guid, FeatureAddSpellInvisibility.IClass.Guid)
                                    .AddEntry(20, FeatureDR10Adamantine.IClass.Guid,
                                                  GetGUID.GUIDByName("EvolutionImmunityElectrictyBaseFeature"),
                                                  GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature")),
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
                                    .AddEntry(1, FeatureImmunityDeath.IClass.Guid, FeatureImmunityEnergyDrain.IClass.Guid, FeatureBonusHealing.IClass.Guid)
                                    .AddEntry(4, FeatureMageLight.IClassBuff.Guid, FeatureGhostTouch.IClassBuff.Guid)
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, GetGUID.GUIDByName("EvolutionFastHealingBaseFeature"))
                                    .AddEntry(16, FeatureAddSpellCureSeriousWounds.IClass.Guid, FeatureAddSpellBreathOfLife.IClass.Guid)
                                    .AddEntry(20, FeatureMaximizeHealing.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),
                                                 GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"),
                                                 FeatureAddSpellBane.IClass.Guid)
                                    .AddEntry(4, FeatureAddSpellBlur.IClass.Guid)
                                    .AddEntry(8, FeatureDR5Magic.IClass.Guid, GetGUID.GUIDByName("ExtraEvolutionPoolFeature"))
                                    .AddEntry(12, GetGUID.GUIDByName("dummyBuff"))
                                    .AddEntry(16, FeatureDR10Magic.IClass.Guid,
                                                  GetGUID.GUIDByName("EvolutionSpellResistanceBaseFeature"))
                                    .AddEntry(20, FeatureAddSpellDimensionDoor.IClass.Guid),
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
                                    .AddEntry(1, GetGUID.GUIDByName("EvolutionResistanceSonicBaseFeature"),FeatureStorykinBonusFeat.IClass.Guid)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"),GetGUID.GUIDByName("EvolutionResistanceElectricityBaseFeature"))
                                    .AddEntry(8, FeatureAbilityIncreaseSelection.IClass.Guid)
                                    .AddEntry(12, FeatureImmunityBleed.IClass.Guid,FeatureImmunityPoison.IClass.Guid,FeatureImmunityStun.IClass.Guid,FeatureDR5Adamantine.IClass.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunitySonicBaseFeature"),FeatureImmunityMind.IClass.Guid)
                                    .AddEntry(20, FeatureImmunityAbilityDamage.IClass.Guid,FeatureImmunityEnergyDrain.IClass.Guid,FeatureAbilityIncreaseSelection.IClass.Guid),
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
                    },
                    hide = true
                },
            #endregion
            #region Void
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Void,
                    levelEntries = LevelEntryBuilder.New()
                                    .AddEntry(1,FeatureImmunityDeath.IClass.Guid,FeatureImmunityDisease.IClass.Guid,FeatureImmunityEnergyDrain.IClass.Guid,FeatureImmunityPoison.IClass.Feature)
                                    .AddEntry(4, GetGUID.GUIDByName("EvolutionResistanceColdBaseFeature"), FeatureGhostTouch.IClass.Feature)
                                    .AddEntry(8, GetGUID.GUIDByName("EvolutionFlightBaseFeature"))
                                    .AddEntry(12, FeatureEnergyDrainBite.IClassBuff.Guid)
                                    .AddEntry(16, GetGUID.GUIDByName("EvolutionImmunityColdBaseFeature"), FeatureDR5Adamantine.IClass.Guid)
                                    .AddEntry(20, FeatureEnergyDrainBite.IClassBuff.Guid,FeatureDR10Adamantine.IClass.Guid),
                    baseForms = new()
                    {
                        EnumsEidolonBaseForm.Biped,
                    }
                },
            #endregion
        };
    }
}
