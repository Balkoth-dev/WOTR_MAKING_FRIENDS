using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.Features.EidolonFeatures.BaseFeatures
{
    public static class FeatureArmorBonus
    {
        internal static class IClass
        {
            internal const string Feature = "EidolonStatBonus";
            internal static LocalizedString Name = Helpers.ObtainString(Feature + ".Name");
            internal static LocalizedString Description = Helpers.ObtainString(Feature + ".Description");
        }

        public static void Create()
        {
            FeatureConfigurator.New(IClass.Feature, GetGUID.GUIDByName(IClass.Feature))
                .SetDisplayName(IClass.Name)
                .SetDescription(IClass.Description)
                .SetIcon(FeatureRefs.DrovierAnimalAspectBaseFeature.Reference.Get().m_Icon)
                .AddStatBonus(ModifierDescriptor.Racial, false, StatType.Strength, 1)
                .AddStatBonus(ModifierDescriptor.NaturalArmor, false, StatType.AC, 2)
                .AddStatBonus(ModifierDescriptor.Racial, false, StatType.Dexterity, 1)
                .SetRanks(8)
                .ConfigureWithLogging();

        }

    }
}
