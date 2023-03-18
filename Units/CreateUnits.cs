using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WOTR_MAKING_FRIENDS.Units.NewUnits;

namespace WOTR_MAKING_FRIENDS.Units
{
    class CreateUnits
    {
        public static void CreateAllUnits()
        {
            foreach(NewUnit newUnit in newUnits)
            {
                var unitConfigured = UnitConfigurator.New(newUnit.name, newUnit.guid)
                    .CopyFrom(newUnit.copiedUnit)
                    .SetDisplayName(newUnit.m_DisplayName)
                    .SetLocalizedName(new SharedStringAsset() { String = newUnit.m_DisplayName })
                    .SetStrength(newUnit.strength)
                    .SetDexterity(newUnit.dexterity)
                    .SetConstitution(newUnit.constitution)
                    .SetIntelligence(newUnit.intelligence)
                    .SetWisdom(newUnit.wisdom)
                    .SetCharisma(newUnit.charisma)
                    .SetPortrait(null)
                    .SetSize(newUnit.size)
                    .SetAddFacts(newUnit.blueprintUnitFactReferences);
                if (newUnit.prefab != null)
                    unitConfigured.SetPrefab(newUnit.prefab);

                    unitConfigured.Configure();
            }

        }

    }
}
