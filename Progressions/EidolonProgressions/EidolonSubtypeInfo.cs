using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
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
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.VerminImmunities)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRSlashing5),
                                GetRefs.BFBRCast(FeatureRefs.FallenBlindsense)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Blindsight)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Aeon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Aeon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Fortification50Feature),
                                GetRefs.BFBRCast(FeatureRefs.TripImmunityFeature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Airborne)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.CrushingDespair)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.TrueStrike)
                                }
                        }

                    }
                },
            #endregion
            #region Agathion
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Agathion,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.LayOnHandsFeature),
                                GetRefs.BFBRCast(AbilityResourceRefs.LayOnHandsResource)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DREvil10)
                                }
                        }

                    }
                },
            #endregion
            #region Ancestor
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Ancestor,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Angel
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Angel,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Airborne)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdImmunity),
                                GetRefs.BFBRCast(FeatureRefs.AcidImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.HolyAura)
                                }
                        }

                    }
                },
            #endregion
            #region Archon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Archon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity),
                                GetRefs.BFBRCast(AbilityRefs.FrightfulAspect)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.DimensionDoor)
                                }
                        }

                    }
                },
            #endregion
            #region Astral
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Astral,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Azata
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Azata,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature)
                            }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Airborne)
                            }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DREvil5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPetrification)
                            }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)
                            }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{

                                }
                        }

                    }
                },
            #endregion
            #region Daemon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Daemon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRGood5),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Deepwater
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Deepwater,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRMagic5),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FastHealing),
                                }
                        }

                    }
                },
            #endregion
            #region Demon
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Demon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.TrueSeeing)
                                }
                        }

                    }
                },
            #endregion
            #region Devil
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Devil,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FastHealing)
                                }
                        }

                    }
                },
            #endregion
            #region Div
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Div,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FireImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.DimensionDoor)
                                }
                        }

                    }
                },
            #endregion
            #region Elemental
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Elemental,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.UncannyDodge),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToBleed),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToCritical),
                                GetRefs.BFBRCast(FeatureRefs.DRImmune_PrecisionDamage)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Genie
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Genie,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Inevitable
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Inevitable,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.DRChaotic10),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToAbilityDamage),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun)
                                }
                        }

                    }
                },
            #endregion
            #region Kami
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Kami,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Kyton
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Kyton,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Plant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Plant,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature),
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToSleep),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToStun),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.SonicImmunity),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)
                                }
                        }

                    }
                },
            #endregion
            #region Protean
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Protean,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.SonicResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRLawful15),
                                GetRefs.BFBRCast(FeatureRefs.Airborne),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.AcidImmunity),
                                GetRefs.BFBRCast(FeatureRefs.AmorphousAnatomyFeature)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.FreedomOfMovement),
                                GetRefs.BFBRCast(AbilityRefs.PolymorphGreaterBase),
                                }
                        }

                    }
                },
            #endregion
            #region Psychopomp
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Psychopomp,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRAdamantine5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.Invisibility)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRAdamantine10),
                                GetRefs.BFBRCast(FeatureRefs.ColdImmunity),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityImmunity)
                                }
                        }

                    }
                },
            #endregion
            #region Radiant
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Radiant,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.MageLight)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Airborne),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.FastHealing),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Shadow
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Shadow,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.BFBRCast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.BFBRCast(AbilityRefs.Bane),
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRMagic5),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.DRMagic10),
                                GetRefs.BFBRCast(FeatureRefs.SpellResistance10plusCR),
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(AbilityRefs.DimensionDoor),
                                }
                        }

                    }
                },
            #endregion
            #region Storykin
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Storykin,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Twinned
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Twinned,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
            #region Void
            new EidolonSubtypeProgression()
                {
                    subtype = EnumsEidolonSubtype.Void,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.NegativeEnergyAffinity),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToDisease),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToEnergyDrain),
                                GetRefs.BFBRCast(FeatureRefs.ImmunityToPoison),
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.Airborne),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.BFBRCast(FeatureRefs.ColdImmunity),
                                GetRefs.BFBRCast(FeatureRefs.DRAdamantine5),
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                }
                        }

                    }
                },
            #endregion
        };
    }
}
