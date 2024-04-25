using UnityEngine;

namespace Assets.Lib.Objects
{
    [System.Serializable]
    public class WeaponObject : ItemObject, IWeaponObject
    {

        [SerializeField] private float _damagePointBonus = 0;
        [SerializeField] private float _healthPointBonus = 0;
        [SerializeField] private float _manaPointBonus = 0;

        //create function to apply bonus or remove bonus follow the item is equipped or unequipped
        public void ApplyBonus()
        {
            //if item is equipped
            if (IsEquipped)
            {
                //apply bonus
                Owner.DamagePoint += DamagePointBonus;
                Owner.HealthPoint += HealthPointBonus;
                Owner.ManaPoint += ManaPointBonus;
            }
            //if item is unequipped
            else
            {
                //remove bonus
                Owner.DamagePoint -= DamagePointBonus;
                Owner.HealthPoint -= HealthPointBonus;
                Owner.ManaPoint -= ManaPointBonus;
            }
        }

        //genrate OnWeaponEquipped function
        public void OnWeaponEquip()
        {
            //apply bonus
            ApplyBonus();
        }

        //genrate OnWeaponUnequipped function
        public void OnWeaponUnequip()
        {
            //remove bonus
            ApplyBonus();
        }

        //generate InitializeListener function
        public void InitializeListener()
        {
            //add listener to OnEquip
            OnEquip.AddListener(OnWeaponEquip);
            //add listener to OnUnequip
            OnUnequip.AddListener(OnWeaponUnequip);
        }
        

        public float DamagePointBonus
        {
            get => _damagePointBonus;
            set => _damagePointBonus = value;
        }

        public float HealthPointBonus
        {
            get => _healthPointBonus;
            set => _healthPointBonus = value;
        }

        public float ManaPointBonus
        {
            get => _manaPointBonus;
            set => _manaPointBonus = value;
        }

        //generate constructor

        //null contructor
        public WeaponObject(string name) : base(name) { }

        public WeaponObject() : this("Weapon") { }

        //builder constructor
        public WeaponObject(ItemObject obj) : base(obj) { }
        public WeaponObject(ItemObject obj, float damagePointBonus, float healthPointBonus, float manaPointBonus) : this(obj)
        {
            DamagePointBonus = damagePointBonus;
            HealthPointBonus = healthPointBonus;
            ManaPointBonus = manaPointBonus;
        }

        public WeaponObject(WeaponObject obj) : this(obj, obj.DamagePointBonus, obj.HealthPointBonus, obj.ManaPointBonus) { }


        public override string ToString()
        {
            return $"WeaponObject: {Name}, DamagePointBonus: {DamagePointBonus}, HealthPointBonus: {HealthPointBonus}, ManaPointBonus: {ManaPointBonus}";
        }


        //public override string GetDebuggerDisplay()
        //{
        //    return ToString();
        //}

    }
}
