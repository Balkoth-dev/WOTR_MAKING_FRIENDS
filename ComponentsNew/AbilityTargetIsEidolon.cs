using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    public class AbilityTargetIsEidolon : BlueprintComponent, IAbilityTargetRestriction
    {
        public bool Not;

        public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper target)
        {
            UnitPartPetMaster unitPartPetMaster = caster.Get<UnitPartPetMaster>();
            if (unitPartPetMaster == null)
            {
                return false;
            }

            foreach (EntityPartRef<UnitEntityData, UnitPartPet> pet in unitPartPetMaster.Pets)
            {
                if (!(pet.Entity != target.Unit))
                {
                    UnitPartPet entityPart = pet.EntityPart;
                    bool flag = entityPart != null && entityPart.Type == PetTypeExtensions.Eidolon;
                    return !Not & flag || Not && !flag;
                }
            }
            return Not;
        }

        public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target) => Not ? BlueprintRoot.Instance.LocalizedTexts.Reasons.TargetIsNotAnimalCompanion : BlueprintRoot.Instance.LocalizedTexts.Reasons.TargetIsAnimalCompanion;
    }
}
