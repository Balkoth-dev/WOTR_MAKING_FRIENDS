using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.Evolutions._1_Point_Evolutions
{
    internal class EvolutionWingBuffet
    {
        private static class InternalString
        {
            internal const string Feature = "EvolutionWingBuffet" + "Feature";
            internal static LocalizedString FeatureName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString FeatureDescription = Helpers.ObtainString(Feature + ".Description");
            internal const string Ability = "EvolutionWingBuffet" + "Ability";
            internal static LocalizedString AbilityName = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString AbilityDescription = Helpers.ObtainString(Feature + ".Description");
        }
    }
}
