using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System.Collections.Generic;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;

namespace WOTR_MAKING_FRIENDS.Units
{
    public static class NewUnits
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
            internal AssetLink<UnitViewLink> prefabLink;
            internal Size size;
            internal int strength;
            internal int dexterity;
            internal int constitution;
            internal int intelligence;
            internal int wisdom;
            internal int charisma;
        };

        public static NewUnit[] newUnits =
            {
                new NewUnit()
                {
                    guid = GetGUID.RedPandaSummon,
                    name = "RedPandaSummon",
                    m_DisplayName = Helpers.ObtainString("RedPandaSummon.Name"),
                    copiedUnit = UnitRefs.DogSummoned.Cast<BlueprintUnitReference>().Reference,
                    prefabLink = UnitRefs.RedPandaFamiliar.Reference.Get().Prefab,
                    size = Size.Tiny,
                    strength = 8,
                    dexterity = 16,
                    constitution = 11,
                    intelligence = 2,
                    wisdom = 13,
                    charisma = 5
                }
            };
    }
}
