using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
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
                    guid = GetGUID.GUIDByName("EidolonAirElemental"),
                    name = "EidolonAirElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_AirElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                    eidolonSubtype = EnumsEidolonSubtype.Elemental,
                    size = Size.Medium
                },
            #endregion
            #region EidolonFireElementalMedium
            new NewUnitClass()
                {
                    guid = GetGUID.GUIDByName("EidolonFireElementalMedium"),
                    name = "EidolonFireElementalMedium",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_FireElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                    eidolonSubtype = EnumsEidolonSubtype.Elemental,
                    size = Size.Medium
                },
            #endregion
            #region EidolonAirElemental
            new NewUnitClass()
                {
                    guid = GetGUID.GUIDByName("EidolonAirElemental"),
                    name = "EidolonAirElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_WaterElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                    eidolonSubtype = EnumsEidolonSubtype.Elemental,
                    size = Size.Medium
                },
            #endregion
            #region EidolonEarthElemental
            new NewUnitClass()
                {
                    guid = GetGUID.GUIDByName("EidolonEarthElemental"),
                    name = "EidolonEarthElemental",
                    m_DisplayName = Helpers.ObtainString("eidolonunit.Name"),
                    copiedUnit = UnitRefs.CR3_EarthElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    isEidolon = true,
                    eidolonBaseForm = EnumsEidolonBaseForm.Abberant,
                    eidolonSubtype = EnumsEidolonSubtype.Elemental,
                    size = Size.Medium
                }
            #endregion
        };
    }
}
