using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.ProgressionFeatures
{
    internal class FeatureAncestorBonusFeat
    {
        internal static class IClass
        {
            internal static string ProgressionFeature = "AncestorBonusFeat";
            internal static string Feature = ProgressionFeature + "Feature";
            internal static string Guid = GetGUID.GUIDByName(Feature);
            internal static string Name = Helpers.ObtainString(Feature + ".Name");
            internal static string Description = Helpers.ObtainString(Feature + ".Description");
            internal static Sprite Icon = FeatureRefs.CombatCasting.Reference.Get().m_Icon;
            internal static int Ranks = 1;
        }
        public void Create()
        {
            FeatureSelectionConfigurator.New(IClass.Feature, IClass.Guid)
                    .SetDisplayName(IClass.Name)
                    .SetDisplayName(IClass.Description)
                    .SetIcon(IClass.Icon)
                    .SetRanks(IClass.Ranks)
                    .SetAllFeatures(
                                      FeatureRefs.Dodge.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.GreatFortitude.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.Improved_Initiative.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.IronWill.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.LightningReflexes.Cast<BlueprintFeatureReference>(),
                                      FeatureRefs.Toughness.Cast<BlueprintFeatureReference>()
                    )
                    .ConfigureWithLogging();
        }
    }
}
