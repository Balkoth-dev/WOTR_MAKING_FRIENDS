using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    public class AbilityCustomDimensionDoorToCaster : AbilityCustomLogic
    {
        public PrefabLink PortalFromPrefab;
        public string PortalBone = "";
        public PrefabLink DisappearFx;
        public PrefabLink AppearFx;
        [SerializeField]
        public BlueprintProjectileReference m_DisappearProjectile;
        [SerializeField]
        public BlueprintProjectileReference m_AppearProjectile;

        public BlueprintProjectile DisappearProjectile => m_DisappearProjectile?.Get();

        public BlueprintProjectile AppearProjectile => m_AppearProjectile?.Get();

        public override bool IsEngageUnit => true;

        public DimensionDoorSettings CreateSettings(UnitEntityData unit) => new DimensionDoorSettings()
        {
            PortalFromPrefab = PortalFromPrefab.Load(),
            PortalBone = PortalBone,
            CasterDisappearFx = DisappearFx.Load(),
            CasterAppearFx = AppearFx.Load(),
            CasterDisappearProjectile = DisappearProjectile,
            CasterAppearProjectile = AppearProjectile,
            Targets = new List<UnitEntityData>() { unit },
            LookAtTarget = false,
            RelaxPoints = false
        };

        public override IEnumerator<AbilityDeliveryTarget> Deliver(
          AbilityExecutionContext context,
          TargetWrapper target)
        {
            if (!(target.Unit == null))
            {
                UnitEntityData caster = context.Caster;
                Vector3 casterPosition = caster.Position;

                Vector3 offset = 1f * UnityEngine.Random.insideUnitSphere;
                Vector3 spawnPosition = new(
                    casterPosition.x + offset.x,
                    casterPosition.y,
                    casterPosition.z + offset.z);

                IEnumerator<AbilityDeliveryTarget> targetDelivery = AbilityCustomDimensionDoor.Deliver(CreateSettings(target.Unit), target.Unit, spawnPosition);
                bool canMoveNextTarget = true;
                while (canMoveNextTarget)
                {
                    if (canMoveNextTarget &= targetDelivery.MoveNext())
                    {
                        yield return targetDelivery.Current;
                    }
                }
            }
        }

        public override void Cleanup(AbilityExecutionContext context)
        {
        }
    }
}
