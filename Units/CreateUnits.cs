using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
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
                    .SetLocalizedName(newUnit.m_DisplayName.Shared)
                    .SetStrength(newUnit.strength)
                    .SetDexterity(newUnit.dexterity)
                    .SetConstitution(newUnit.constitution)
                    .SetIntelligence(newUnit.intelligence)
                    .SetWisdom(newUnit.wisdom)
                    .SetCharisma(newUnit.charisma)
                    .SetPortrait(null)
                    .SetSize(newUnit.size);
                    //.AddChangeUnitSize(null,BlueprintCore.Blueprints.CustomConfigurators.ComponentMerge.Skip,newUnit.size,-1,Kingmaker.Designers.Mechanics.Buffs.ChangeUnitSize.ChangeType.Delta);

                if (newUnit.prefabLink != null)
                    unitConfigured.SetPrefab(newUnit.prefabLink);

                    unitConfigured.Configure();
            }

        }

    }
}
