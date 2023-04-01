using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Parts;
using WOTR_MAKING_FRIENDS.ComponentsNew;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowedOn(typeof(BlueprintFeature), false)]
    [AllowedOn(typeof(BlueprintBuff), false)]
    [AllowMultipleComponents]
    public class BondedSensesComponent : UnitFactComponentDelegate
    {
        public ModifierDescriptor Descriptor = ModifierDescriptor.None;
        public StatType Stat = StatType.SkillPerception;

        public override void OnTurnOn()
        {
            int statValue = Owner.Stats.SkillPerception.BaseValue;
            if (Owner.Pets.Count > 0)
            {
                foreach (EntityPartRef<Kingmaker.EntitySystem.Entities.UnitEntityData, UnitPartPet> pet in Owner.Pets)
                {
                    PetType? type = pet.Entity.Get<UnitPartPet>()?.Type;
                    if (type == PetTypeExtensions.Eidolon && pet.Entity.Stats.SkillPerception.BaseValue > statValue)
                    {
                        statValue = pet.Entity.Stats.SkillPerception.BaseValue;
                    }
                }
            }

            Owner.Stats.GetStat(Stat).BaseValue = statValue;
            //Owner.Stats.GetStat(Stat).(statValue, Runtime, Descriptor);
        }

        public override void OnTurnOff()
        {
            Owner.Stats.GetStat(Stat)?.RemoveModifiersFrom(Runtime);
        }
    }
}