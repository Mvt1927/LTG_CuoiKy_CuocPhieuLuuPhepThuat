using Assets.Scripts;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Lib.Objects
{
    [System.Serializable]
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class LivingEntityObject : EntityObject
    {
        [System.Serializable]
        public class Stats
        {
            public float HealthPoint;
            public float DamagePoint;
            public float ManaPoint;
        }
        [SerializeField] private Stats _stats = new();

        [SerializeField] private bool _isHoldable = true;

#if UNITY_EDITOR
        [SerializeField]
        //[ConditionalShow(-, true)]

#else
        [NonSerialized]
#endif
        private GameObject _hands_Right = null;

#if UNITY_EDITOR
        [SerializeField]
        //[ConditionalShow(nameof(IsHoldable), true)]

#else
        [NonSerialized]
#endif
        private GameObject _hands_Left = null;

        public float HealthPoint { get => _stats.HealthPoint; set => _stats.HealthPoint = value; }
        public float DamagePoint { get => _stats.HealthPoint; set => _stats.HealthPoint = value; }
        public float ManaPoint { get => _stats.HealthPoint; set => _stats.HealthPoint = value; }
        public bool IsHoldable { get => _isHoldable; set => _isHoldable = value; }

        public GameObject Hands_Right
        {
            get => _hands_Right;
            private set {
                if (value != null && value.TryGetComponent<Entity>(out _))
                {
                    _hands_Right = value;
                }
            }
        }
        public GameObject Hands_Left { 
            get => _hands_Left;
            private set
            {
                if (value != null && value.TryGetComponent<Entity>(out _))
                {
                    _hands_Left = value;
                }
            }
        }

        public void InitializeHands(GameObject hands_Right, GameObject hands_Left)
        {
            Hands_Right = hands_Right;
            Hands_Left = hands_Left;
        }

        public LivingEntityObject(string name) : base(name) { }

        public LivingEntityObject() : this("LivingEntity") { }

        public LivingEntityObject(EntityObject obj) : base(obj) { }

        //constructor chaining
        /// <summary>
        /// constructor chaining with base constructor
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="healthPoint"></param>
        /// <param name="damagePoint"></param>
        public LivingEntityObject(
            EntityObject obj,
            float healthPoint,
            float damagePoint
            ) : this(obj)
        {
            HealthPoint = healthPoint;
            DamagePoint = damagePoint;
        }

        /// <summary>
        /// constructor chaining 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="healthPoint"></param>
        /// <param name="damagePoint"></param>
        /// <param name="manaPoint"></param>
        public LivingEntityObject(
            EntityObject obj,
            float healthPoint,
            float damagePoint,
            float manaPoint
            ) : this(
                obj,
                healthPoint,
                damagePoint
                )
        {
            ManaPoint = manaPoint;
        }

        public LivingEntityObject(
            EntityObject obj,
            float healthPoint,
            float damagePoint,
            float manaPoint,
            bool isHoldable
            //ItemObject leftEquippedItemObject,
            //ItemObject rightEquippedItemObject
            ) : this(
                obj,
                healthPoint,
                damagePoint,
                manaPoint
                )
        {
            IsHoldable = isHoldable;
            //LeftEquippedItemObject = leftEquippedItemObject;
            //RightEquippedItemObject = rightEquippedItemObject;
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="obj"></param>
        public LivingEntityObject(LivingEntityObject obj) :
            this(obj, obj.HealthPoint, obj.DamagePoint, obj.ManaPoint)
        { }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
