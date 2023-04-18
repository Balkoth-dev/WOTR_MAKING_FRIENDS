using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Units
{
    public static class NewEidolons
    {
        public static NewUnit[] newUnits =
            {
            #region EidolonAirElemental
            new NewUnit()
                {
                    guid = GetGUID.EidolonAirElemental,
                    name = "EidolonAirElemental",
                    copiedUnit = UnitRefs.CR3_AirElementalMedium.Cast<BlueprintUnitReference>().Reference,
                    prefab = UnitRefs.CR3_AirElementalMedium.Reference.Get().Prefab,
                    isSummon = false,
                    isEidolon = true,
                    eidolonBaseForm = EidolonBaseForm.Abberant,
                    eidolonSubtype = EidolonSubtype.Elemental,
                    size = Size.Medium,
                    blueprintUnitFactReferences = new Blueprint<BlueprintUnitFactReference>[]
                                                  {
                                                    FeatureRefs.SubtypeExtraplanar.Cast<BlueprintUnitFactReference>().Reference,
                                                    FeatureRefs.SubtypeElemental.Cast<BlueprintUnitFactReference>().Reference
                                                  }
                }
            #endregion
        };
    }
}
