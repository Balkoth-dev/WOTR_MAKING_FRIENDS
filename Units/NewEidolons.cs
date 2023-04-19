using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using WOTR_MAKING_FRIENDS.GUIDs;
using static WOTR_MAKING_FRIENDS.Enums.EidolonEnums;

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
                    eidolonBaseForm = EidolonBaseFormEnums.Abberant,
                    eidolonSubtype = EidolonSubtypeEnums.Elemental,
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
