using JetBrains.Annotations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace WOTR_MAKING_FRIENDS.ComponentsNew
{
    [AllowedOn(typeof(BlueprintUnit), false)]
    [AllowMultipleComponents]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [AllowedOn(typeof(BlueprintBuff), false)]
    [TypeId("339fb222a0a843fc870ce0b401696958")]
    public class AddOutgoingPhysicalDamagePropertyMasterAlignment : UnitFactComponentDelegate, IInitiatorRulebookHandler<RulePrepareDamage>, IRulebookHandler<RulePrepareDamage>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public int levelRequirement = 0;
        public bool AffectAnyPhysicalDamage;

        [HideIf("AffectAnyPhysicalDamage")]
        public bool NaturalAttacks;

        [ShowIf("NaturalAttacks")]
        public bool NotUnarmed;

        public bool AddMagic;

        public bool AddMaterial;

        [ShowIf("AddMaterial")]
        public PhysicalDamageMaterial Material = PhysicalDamageMaterial.Adamantite;

        public bool AddForm;

        [ShowIf("AddForm")]
        public PhysicalDamageForm Form;

        public bool AddAlignment;

        [ShowIf("AddAlignment")]
        public DamageAlignment Alignment = DamageAlignment.Good;

        [ShowIf("AddAlignment")]
        public bool MastersAlignment;

        public bool AddReality;

        [ShowIf("AddReality")]
        public DamageRealityType Reality = DamageRealityType.Ghost;

        public bool CheckWeaponType;

        [FormerlySerializedAs("WeaponType")]
        [SerializeField]
        [ShowIf("CheckWeaponType")]
        public BlueprintWeaponTypeReference m_WeaponType;

        public bool CheckRange;

        [ShowIf("CheckRange")]
        public bool IsRanged;

        public bool AgainstFactOwner;

        [ShowIf("AgainstFactOwner")]
        [SerializeField]
        public BlueprintUnitFactReference m_UnitFact;

        public BlueprintWeaponType WeaponType => m_WeaponType?.Get();

        public BlueprintUnitFact UnitFact => m_UnitFact?.Get();

        public void OnEventAboutToTrigger(RulePrepareDamage evt)
        {
        }

        public void OnEventDidTrigger(RulePrepareDamage evt)
        {

            ItemEntityWeapon weapon = evt.DamageBundle.Weapon;
            bool num = AddMagic || AddMaterial || AddAlignment || AddForm || AddReality;
            bool flag = !NaturalAttacks || (weapon?.Blueprint.Type.IsNatural ?? false);
            bool flag2 = !NotUnarmed || !NaturalAttacks || weapon == null || !weapon.Blueprint.Type.IsUnarmed;
            bool flag3 = !CheckWeaponType || (weapon != null && weapon.Blueprint.Type == WeaponType);
            bool flag4 = !CheckRange || (weapon != null && ((IsRanged && weapon.Blueprint.Type.IsRanged) || (!IsRanged && !weapon.Blueprint.Type.IsRanged)));
            bool flag5 = !AgainstFactOwner || evt.Target.HasFact(UnitFact);
            if (!(num && flag3 && flag4 && flag && flag2 && flag5))
            {
                return;
            }

            if (AffectAnyPhysicalDamage)
            {
                foreach (BaseDamage item in evt.DamageBundle)
                {
                    ApplyProperties(item as PhysicalDamage);
                }
            }
            else
            {
                ApplyProperties(evt.DamageBundle.WeaponDamage as PhysicalDamage);
            }
        }

        public void ApplyProperties([CanBeNull] PhysicalDamage damage)
        {
            if (base.Owner.Progression.CharacterLevel < levelRequirement)
            { return; }
            if (damage == null)
            {
                return;
            }

            if (AddMagic && damage.Enchantment < 1)
            {
                damage.Enchantment = 1;
                damage.EnchantmentTotal++;
            }

            if (AddMaterial)
            {
                damage.AddMaterial(Material);
            }

            if (AddForm)
            {
                damage.AddForm(Form);
            }

            if (AddAlignment)
            {
                if (MastersAlignment)
                {
                    if (base.Owner.Master.Alignment.ValueRaw.HasComponent(AlignmentComponent.Lawful))
                    {
                        damage.AddAlignment(DamageAlignment.Lawful);
                    }

                    if (base.Owner.Master.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic))
                    {
                        damage.AddAlignment(DamageAlignment.Chaotic);
                    }

                    if (base.Owner.Master.Alignment.ValueRaw.HasComponent(AlignmentComponent.Good))
                    {
                        damage.AddAlignment(DamageAlignment.Good);
                    }

                    if (base.Owner.Master.Alignment.ValueRaw.HasComponent(AlignmentComponent.Evil))
                    {
                        damage.AddAlignment(DamageAlignment.Evil);
                    }
                }
                else
                {
                    damage.AddAlignment(Alignment);
                }
            }

            if (AddReality)
            {
                damage.Reality |= Reality;
            }
        }
    }
}