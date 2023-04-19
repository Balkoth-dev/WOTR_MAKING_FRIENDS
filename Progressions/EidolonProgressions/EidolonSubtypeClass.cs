using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using static WOTR_MAKING_FRIENDS.Enums.EidolonEnums;

namespace WOTR_MAKING_FRIENDS.Progressions.EidolonProgressions
{
    public class EidolonSubtypeClass
    {
        private EidolonSubtypeEnums _subtype;
        private Dictionary<int, BlueprintFeatureBaseReference[]> _levelEntries;
        private string _name;
        internal EidolonSubtypeEnums subtype
        {
            get { return _subtype; }
            set
            {
                _subtype = value;
                _name = Enum.GetName(typeof(EidolonSubtypeEnums), _subtype);
            }
        }

        public Dictionary<int, BlueprintFeatureBaseReference[]> levelEntries
        {
            get { return _levelEntries; }
            set { _levelEntries = value; }
        }

        public string name
        {
            get { return _name; }
        }
    }

}
