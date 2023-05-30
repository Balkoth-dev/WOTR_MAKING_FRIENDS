using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Units
{
    public static class UnitEidolons
    {
        public static NewUnitClass[] newUnits =
            {
            #region EidolonAirElemental
            new NewUnitClass()
                {
                    Name = "EidolonAirElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_AirElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonFireElemental
            new NewUnitClass()
                {
                    Name = "EidolonFireElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_FireElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonWaterElemental
            new NewUnitClass()
                {
                    Name = "EidolonWaterElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_WaterElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonEarthElemental
            new NewUnitClass()
                {
                    Name = "EidolonEarthElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_EarthElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant
                },
            #endregion
            #region EidolonGoldDragon
            new NewUnitClass()
                {
                    Name = "EidolonGoldDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ArmyDragonGold.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "7a47bc6dbd2e2014aa5be8519e93a02e"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonSilverDragon
            new NewUnitClass()
                {
                    Name = "EidolonSilverDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.SilverDragon.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "f021f54d9e87f5a49922a10f69598bba"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonBrassDragon
            new NewUnitClass()
                {
                    Name = "EidolonBrassDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ArmyDragonBrass.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "2b4bbf498ccba75489dfcbe786c7a8b2"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonCopperDragon
            new NewUnitClass()
                {
                    Name = "EidolonCopperDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ArmyDragonCopper.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "d69ec0bc0baab38408f87bcc0809517b"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonTroll
            new NewUnitClass()
                {
                    Name = "EidolonTroll",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.TestTroll.Cast<BlueprintUnitReference>().Reference,
                    portrait = BlueprintTool.GetRef<BlueprintPortraitReference>("8b39144752ca7644b97d0d6c3253f923"),
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonSuccubus
            new NewUnitClass()
                {
                    Name = "EidolonSuccubus",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR15_SuccubusCaster.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonIncubus
            new NewUnitClass()
                {
                    Name = "EidolonIncubus",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR16_IncubusGladiator.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonBabau
            new NewUnitClass()
                {
                    Name = "EidolonBabau",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.BabauSummon.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonMarilith
            new NewUnitClass()
                {
                    Name = "EidolonMarilith",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR17_MarilithStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonDretch
            new NewUnitClass()
                {
                    Name = "EidolonDretch",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR2_DretchStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonBalor
            new NewUnitClass()
                {
                    Name = "EidolonBalor",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.BalorSummon.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonSchir
            new NewUnitClass()
                {
                    Name = "EidolonSchir",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR4_SchirStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonColoxus
            new NewUnitClass()
                {
                    Name = "EidolonColoxus",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR12_ColoxusStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonGlabrezu
            new NewUnitClass()
                {
                    Name = "EidolonGlabrezu",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR13_GlabrezuStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonVrock
            new NewUnitClass()
                {
                    Name = "EidolonVrock",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR11_VrockAdvanced.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonPainaji
            new NewUnitClass()
                {
                    Name = "EidolonPainaji",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR14_PainajaiStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonBrimorak
            new NewUnitClass()
                {
                    Name = "EidolonBrimorak",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR5_BrimorakStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonLilitu
            new NewUnitClass()
                {
                    Name = "EidolonLilitu",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR17_LilituStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonVavakia
            new NewUnitClass()
                {
                    Name = "EidolonVavakia",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR18_VavakiaStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonBythos
            new NewUnitClass()
                {
                    Name = "EidolonBythos",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR16_BythosStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonAxiomiteMasc
            new NewUnitClass()
                {
                    Name = "EidolonAxiomiteMasc",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.Aeon_Axiomite_M_01.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonGolemWood
            new NewUnitClass()
                {
                    Name = "EidolonGolemWood",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.GolemWoodSummon.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonGolemIron
            new NewUnitClass()
                {
                    Name = "EidolonGolemIron",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.GolemIronSummon.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonAstralDeva
            new NewUnitClass()
                {
                    Name = "EidolonAstralDeva",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR14_AstralDeva.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonMonadicDeva
            new NewUnitClass()
                {
                    Name = "EidolonMonadicDeva",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.MonadicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonMovanicDeva
            new NewUnitClass()
                {
                    Name = "EidolonMovanicDeva",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.MovanicDevaSummoned.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonLillend
            new NewUnitClass()
                {
                    Name = "EidolonLillend",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR7_AzataLillendStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonBralani
            new NewUnitClass()
                {
                    Name = "EidolonBralani",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR6_AzataBralaniStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonVeranallia
            new NewUnitClass()
                {
                    Name = "EidolonVeranallia",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ArmyAzataVeranallia.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonYinudja
            new NewUnitClass()
                {
                    Name = "EidolonYinudja",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.AzataIsland_AzataYinudja.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonTreant
            new NewUnitClass()
                {
                    Name = "EidolonTreant",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.TreantSummoned.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonErinyes
            new NewUnitClass()
                {
                    Name = "EidolonErinyes",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR8_ErinyesDevilStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonDeathsnatcher
            new NewUnitClass()
                {
                    Name = "EidolonDeathsnatcher",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR18_DeathsnatcherStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonSpirit
            new NewUnitClass()
                {
                    Name = "EidolonSpirit",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.Arcanotheign.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Fine"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Fine"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonShade
            new NewUnitClass()
                {
                    Name = "EidolonShade",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_Shadow.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonKeketar
            new NewUnitClass()
                {
                    Name = "EidolonKeketar",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR17_ProteanKeketarStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonCragLinnorm
            new NewUnitClass()
                {
                    Name = "EidolonCragLinnorm",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR14_CragLinnorm.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Fine"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Fine"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonRedDragon
            new NewUnitClass()
                {
                    Name = "EidolonRedDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.RedDragon.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "2577a3281d0de4c469c52f4519ebcc2a"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonGreenDragon
            new NewUnitClass()
                {
                    Name = "EidolonGreenDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ArmyDragonGold.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "3537dfd032a3f564588d14f4998172b1"},
                    portrait = BlueprintTool.GetRef<BlueprintPortraitReference>("a61b3b56482e45989a101b9816d54932"),
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonWhiteDragon
            new NewUnitClass()
                {
                    Name = "EidolonWhiteDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.DLC1_WintersunWhiteDragon.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "f886c5a59c94a3249a273764fac0475d"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonBlackDragon
            new NewUnitClass()
                {
                    Name = "EidolonBlackDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR11_BlackDragonAdult.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "5c1800575096ebc45a19ebd216f1e4ea"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonBlueDragon
            new NewUnitClass()
                {
                    Name = "EidolonBlueDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR10_BlueDragonJuvenile.Cast<BlueprintUnitReference>().Reference,
                    prefab = new UnitViewLink(){AssetId = "f599384431b2c494e895ff1549cfa015"},
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                },
            #endregion
            #region EidolonSalamander
            new NewUnitClass()
                {
                    Name = "EidolonSalamander",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR15_CyborgSalamander_Add.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonShamblingMound
            new NewUnitClass()
                {
                    Name = "EidolonShamblingMound",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR6_ShamblingMound.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant
                },
            #endregion
            #region EidolonNightmare
            new NewUnitClass()
                {
                    Name = "EidolonNightmare",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR5_NightmareFriendly.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonHellHound
            new NewUnitClass()
                {
                    Name = "EidolonHellHound",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.HellhoundSummoned.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonAstradaemon
            new NewUnitClass()
                {
                    Name = "EidolonAstradaemon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.SoulsCloakAstradaemonSummoned.Cast<BlueprintUnitReference>().Reference,
                    portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(GetGUID.GUIDByName("EidolonAstradaemonPortrait")),
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Tiny"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Tiny"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonWerewolf
            new NewUnitClass()
                {
                    Name = "EidolonWerewolf",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR2_WerewolfStandard.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Biped,
                },
            #endregion
            #region EidolonMimic
            new NewUnitClass()
                {
                    Name = "EidolonMimic",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.MimicChestStandart.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                },
            #endregion
            #region EidolonManticore
            new NewUnitClass()
                {
                    Name = "EidolonManticore",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.ManticoreSummoned.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Small"+"OriginalFeature"))
                                                  }
                },
            #endregion
            #region EidolonWillOWisp
            new NewUnitClass()
                {
                    Name = "EidolonWillOWisp",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.WillOWispSummon.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant
                },
            #endregion
            #region EidolonFairyDragon
            new NewUnitClass()
                {
                    Name = "EidolonFairyDragon",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.FaerieDragon_01_Familiar.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Serpentine
                },
            #endregion
            #region EidolonBulette
            new NewUnitClass()
                {
                    Name = "EidolonBulette",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR12_BuletteAncient.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Quadruped,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Tiny"+"Feature")),
                                                    BlueprintTool.GetRef<BlueprintUnitFactReference>(GetGUID.GUIDByName("EvolutionSizeChange"+"Tiny"+"OriginalFeature"))
                                                  }
                },
            #endregion
        };
    }
}
