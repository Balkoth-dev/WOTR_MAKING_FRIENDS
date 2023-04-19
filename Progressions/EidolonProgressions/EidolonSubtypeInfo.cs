using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using static WOTR_MAKING_FRIENDS.Enums.EidolonEnums;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    internal class EidolonSubtypeInfo
    {
        public static EidolonSubtypeClass[] eidolonSubtypes =
        {
            #region Aberrant
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Aberrant,
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
                                GetRefs.Cast(FeatureRefs.VerminImmunities)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRSlashing5),
                                GetRefs.Cast(FeatureRefs.FallenBlindsense)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Blindsight)
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Aeon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Fortification50Feature),
                                GetRefs.Cast(FeatureRefs.TripImmunityFeature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Airborne)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.CrushingDespair)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToCritical)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.TrueStrike)
                                }
                        }

                    }
                },
            #endregion
            #region Agathion
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Agathion,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature),
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.Cast(FeatureRefs.SonicResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.LayOnHandsFeature),
                                GetRefs.Cast(AbilityResourceRefs.LayOnHandsResource)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DREvil5),
                                GetRefs.Cast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DREvil10)
                                }
                        }

                    }
                },
            #endregion
            #region Ancestor
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Ancestor,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Angel,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Airborne)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DREvil5),
                                GetRefs.Cast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdImmunity),
                                GetRefs.Cast(FeatureRefs.AcidImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.HolyAura)
                                }
                        }

                    }
                },
            #endregion
            #region Archon
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Archon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
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
                                GetRefs.Cast(FeatureRefs.DREvil5),
                                GetRefs.Cast(FeatureRefs.ImmunityToPetrification)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity),
                                GetRefs.Cast(AbilityRefs.FrightfulAspect)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.DimensionDoor)
                                }
                        }

                    }
                },
            #endregion
            #region Astral
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Astral,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Azata,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature)
                            }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Airborne)
                            }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DREvil5),
                                GetRefs.Cast(FeatureRefs.ImmunityToPetrification)
                            }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity)
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Daemon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRGood5),
                                GetRefs.Cast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.Cast(FeatureRefs.ImmunityToDisease),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidImmunity)
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Deepwater,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature)
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
                                GetRefs.Cast(FeatureRefs.DRMagic5),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FastHealing),
                                }
                        }

                    }
                },
            #endregion
            #region Demon
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Demon,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.TrueSeeing)
                                }
                        }

                    }
                },
            #endregion
            #region Devil
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Devil,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FastHealing)
                                }
                        }

                    }
                },
            #endregion
            #region Div
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Div,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireResistance10Feature),
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRGood5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FireImmunity)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.DimensionDoor)
                                }
                        }

                    }
                },
            #endregion
            #region Elemental
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Elemental,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.Cast(FeatureRefs.ImmunityToSleep)
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
                                GetRefs.Cast(FeatureRefs.UncannyDodge),
                                GetRefs.Cast(FeatureRefs.ImmunityToBleed),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison),
                                GetRefs.Cast(FeatureRefs.ImmunityToStun)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToCritical),
                                GetRefs.Cast(FeatureRefs.DRImmune_PrecisionDamage)
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Genie,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Inevitable,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.PoisonResistance4Feature),
                                GetRefs.Cast(FeatureRefs.UndeadResistanceDhampir)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.Cast(FeatureRefs.ImmunityToDisease),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToSleep),
                                GetRefs.Cast(FeatureRefs.DRChaotic10),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToAbilityDamage),
                                GetRefs.Cast(FeatureRefs.ImmunityToEnergyDrain)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.Cast(FeatureRefs.ImmunityToSleep),
                                GetRefs.Cast(FeatureRefs.ImmunityToStun)
                                }
                        }

                    }
                },
            #endregion
            #region Kami
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Kami,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Kyton,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Plant,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(FeatureRefs.SonicResistance10Feature),
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
                                GetRefs.Cast(FeatureRefs.ImmunityToParalysis),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison),
                                GetRefs.Cast(FeatureRefs.ImmunityToSleep),
                                GetRefs.Cast(FeatureRefs.ImmunityToStun),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.SonicImmunity),
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity)
                                }
                        }

                    }
                },
            #endregion
            #region Protean
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Protean,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidResistance10Feature)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(FeatureRefs.SonicResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRLawful15),
                                GetRefs.Cast(FeatureRefs.Airborne),
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.AcidImmunity),
                                GetRefs.Cast(FeatureRefs.AmorphousAnatomyFeature)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.FreedomOfMovement),
                                GetRefs.Cast(AbilityRefs.PolymorphGreaterBase),
                                }
                        }

                    }
                },
            #endregion
            #region Psychopomp
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Psychopomp,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.Cast(FeatureRefs.ImmunityToDisease),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRAdamantine5)
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.Invisibility)
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRAdamantine10),
                                GetRefs.Cast(FeatureRefs.ColdImmunity),
                                GetRefs.Cast(FeatureRefs.ElectricityImmunity)
                                }
                        }

                    }
                },
            #endregion
            #region Radiant
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Radiant,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.Cast(FeatureRefs.ImmunityToEnergyDrain)
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.MageLight)
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Airborne),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.FastHealing),
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Shadow,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                GetRefs.Cast(FeatureRefs.ElectricityResistance10Feature),
                                GetRefs.Cast(AbilityRefs.Bane),
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRMagic5),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.DRMagic10),
                                GetRefs.Cast(FeatureRefs.SpellResistance10plusCR),
                                }
                        },
                        {   20,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(AbilityRefs.DimensionDoor),
                                }
                        }

                    }
                },
            #endregion
            #region Storykin
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Storykin,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Twinned,
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
            new EidolonSubtypeClass()
                {
                    subtype = EidolonSubtypeEnums.Void,
                    levelEntries = new()
                    {
                        {   1,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.NegativeEnergyAffinity),
                                GetRefs.Cast(FeatureRefs.ImmunityToDeathEffects),
                                GetRefs.Cast(FeatureRefs.ImmunityToDisease),
                                GetRefs.Cast(FeatureRefs.ImmunityToEnergyDrain),
                                GetRefs.Cast(FeatureRefs.ImmunityToPoison),
                                }
                        },
                        {   4,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdResistance10Feature),
                                }
                        },
                        {   8,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.Airborne),
                                }
                        },
                        {   12,
                            new BlueprintFeatureBaseReference[]{
                                }
                        },
                        {   16,
                            new BlueprintFeatureBaseReference[]{
                                GetRefs.Cast(FeatureRefs.ColdImmunity),
                                GetRefs.Cast(FeatureRefs.DRAdamantine5),
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
