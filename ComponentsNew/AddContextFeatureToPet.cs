using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Parts;
using System;
using UnityEngine;
using WOTR_MAKING_FRIENDS.Enums;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [ComponentName("Add feature to companion")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowMultipleComponents]
    [TypeId("5fed8b619ce448efb629e94661f6c607")]
    public class AddContextFeatureToPet : ContextAction
    {
        [SerializeField]
        public PetType m_PetType;

        [SerializeField]
        public BlueprintFeatureReference m_Feature;

        public BlueprintFeature Feature => m_Feature?.Get();

        [SerializeField]
        public BlueprintFeatureReference m_ReplaceFeature;

        public BlueprintFeature ReplaceFeature => m_ReplaceFeature?.Get();

        [SerializeField]
        public BlueprintFeatureReference m_HasFeature;

        public BlueprintFeature HasFeature => m_HasFeature?.Get();

        public override void RunAction()
        {
            if (base.Target.Unit.IsPet || base.Target.Unit.IsReallyInFactPet)
            {
                return;
            }

            foreach (EntityPartRef<UnitEntityData, UnitPartPet> pet in base.Target.Unit.Pets)
            {
                UnitPartPet entityPart = pet.EntityPart;
                bool flag = entityPart != null && entityPart.Type == PetTypeExtensions.Eidolon;
                if (flag)
                {
                    FeatureCollection targetFeatures = Target.Unit.Descriptor.Progression.Features;
                    FeatureCollection petFeatures = pet.Entity.Descriptor.Progression.Features;
                    if (HasFeature != null && targetFeatures.HasFact(HasFeature))
                    {
                        Main.Log(ReplaceFeature.m_DisplayName);
                        petFeatures.AddFeature(ReplaceFeature);
                    }
                    else
                    {
                        Main.Log(HasFeature.m_DisplayName);
                        petFeatures.AddFeature(Feature);
                    }
                }
            }


        }

        public override string GetCaption()
        {
            throw new NotImplementedException();
        }
    }
}
