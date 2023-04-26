using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using static WOTR_MAKING_FRIENDS.Enums.EnumsEidolons;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    public class EidolonSubtypeProgression
    {
        private EnumsEidolonSubtype _subtype;
        internal EnumsEidolonSubtype subtype
        {
            get { return _subtype; }
            set
            {
                _subtype = value;
                _name = Enum.GetName(typeof(EnumsEidolonSubtype), _subtype);
            }
        }

        public LevelEntryBuilder levelEntries = LevelEntryBuilder.New();

        private string _name;
        public string name
        {
            get { return _name; }
        }

        internal List<EnumsEidolonBaseForm> baseForms = new();

        internal bool hide = false;
    }

}
