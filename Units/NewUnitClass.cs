using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Units
{
    public class NewUnitClass
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
        /// <summary> Denotes if this unit is to be used in a summon spell. </summary>
        internal bool isSummon;
        /// <summary> Denotes if this unit is an Eidolon. </summary>
        internal bool isEidolon;
        /// <summary> If the unit is an eidolon, assign base form. </summary>
        internal EnumsEidolonBaseForm eidolonBaseForm;
        /// <summary> If the unit is an eidolon, assign subtype.  </summary>
        internal EnumsEidolonSubtype eidolonSubtype;
        internal Size? size;
        internal int? strength;
        internal int? dexterity;
        internal int? constitution;
        internal int? intelligence;
        internal int? wisdom;
        internal int? charisma;
        internal Blueprint<BlueprintUnitFactReference>[] blueprintUnitFactReferences;

    };
}
