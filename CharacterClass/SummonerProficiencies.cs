using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WOTR_MAKING_FRIENDS.GUIDs;
using WOTR_MAKING_FRIENDS.Utilities;

namespace WOTR_MAKING_FRIENDS.CharacterClass
{
    class SummonerProficiencies
    {
        private static readonly string Proficiency = "SummonerProficiencies";
        private static readonly LocalizedString ProficiencyName = Helpers.ObtainString(Proficiency + ".Name");
        private static readonly LocalizedString ProficiencyDescription = Helpers.ObtainString(Proficiency + ".Description");

        public static void Initialize()
        {
            FeatureConfigurator.New(Proficiency, GetGUID.SummonerProficiencies)
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
                .Configure();
        }
    }
}
