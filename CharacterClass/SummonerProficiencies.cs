using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Localization;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;
namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    internal class SummonerProficiencies
    {
        private static readonly string Proficiency = "SummonerProficiencies";
        private static readonly LocalizedString ProficiencyName = Helpers.ObtainString(Proficiency + ".Name");
        private static readonly LocalizedString ProficiencyDescription = Helpers.ObtainString(Proficiency + ".Description");

        public static void Initialize()
        {
            FeatureConfigurator.New(Proficiency, GetGUID.GUIDByName("SummonerProficiencies"))
                .SetDisplayName(ProficiencyName)
                .SetDescription(ProficiencyDescription)
                .AddFacts(new()
                {
                    FeatureRefs.SimpleWeaponProficiency.Reference.Get(),
                    FeatureRefs.LightArmorProficiency.Reference.Get()
                })
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetRanks(1)
                .SetAllowNonContextActions(false)
                .AddArcaneArmorProficiency(new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Light })
                .ConfigureWithLogging();
        }
    }
}
