using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Enums;

namespace WOTR_MAKING_FRIENDS.Units
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
        /// <summary> Denotes if this unit is to be used in a summon spell. </summary>
        internal bool isSummon;
        /// <summary> Denotes if this unit is an Eidolon. </summary>
        internal bool isEidolon;
        /// <summary> If the unit is an eidolon, assign base form. </summary>
        internal EidolonBaseForm eidolonBaseForm;
        /// <summary> If the unit is an eidolon, assign subtype.  </summary>
        internal EidolonSubtype eidolonSubtype;
        internal Size? size;
        internal int? strength;
        internal int? dexterity;
        internal int? constitution;
        internal int? intelligence;
        internal int? wisdom;
        internal int? charisma;
        internal Blueprint<BlueprintUnitFactReference>[] blueprintUnitFactReferences;

    };
    public enum EidolonBaseForm
    {
        Abberant = 1,
        Biped = 2,
        Quadruped = 3,
        Serpentine = 4
    }
    public enum EidolonSubtype
    {
        Aberration = 1,
        Aeon = 2,
        Agathion = 3,
        Ancestor = 4,
        Angel = 5,
        Archon = 6,
        Astral = 7,
        Azata = 8,
        Daemon = 9,
        DeepwaterEidolon = 10,
        Demon = 11,
        Devil = 12,
        Div = 13,
        Elemental = 14,
        Genie = 15,
        Inevitable = 16,
        Kami = 17,
        Kyton = 18,
        Protean = 19,
        Psychopomp = 20,
        Radiant = 21,
        Shadow = 22,
        Storykin = 23,
        Twinned = 24,
        Void = 25,
    }
}
