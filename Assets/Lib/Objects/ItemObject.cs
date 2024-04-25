using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Lib.Objects
{
    [System.Serializable]
    public class ItemObject : EntityObject
    {
        [SerializeField] private int _maxStack;
        [SerializeField] private int _currentStack;
        //[SerializeField]
        private bool _isStackable;
        //[SerializeField] 
        private bool _isEquippable;
        private bool _isConsumable;
        private bool _isSellable;
        private bool _isDroppable;
        private bool _isPickedUp;
        private bool _isDestroyable;
        private bool _isUsable;
        private bool _isEquipped;
        private bool _isUsed;
        private bool _isSold;
        private bool _isDropped;
        private bool _isDestroyed;
        private bool _isConsumed;
        private bool _isUsedUp;

        //private bool _isEquippedByPlayer;
        //private bool _isEquippedByEnemy;
        //private bool _isEquippedByNPC;
        //private bool _isEquippedByLivingEntity;

        //[SerializeField]
        [NonSerialized]
        private LivingEntityObject _owner = null;

        public int MaxStack { get => _maxStack; set => _maxStack = value; }
        public int CurrentStack { get => _currentStack; set => _currentStack = value; }
        public bool IsStackable { get => _isStackable; set => _isStackable = value; }
        public bool IsEquippable { get => _isEquippable; set => _isEquippable = value; }
        public bool IsConsumable { get => _isConsumable; set => _isConsumable = value; }
        public bool IsSellable { get => _isSellable; set => _isSellable = value; }
        public bool IsDroppable { get => _isDroppable; set => _isDroppable = value; }
        public bool IsPickedUp { get => _isPickedUp; set => _isPickedUp = value; }
        public bool IsDestroyable { get => _isDestroyable; set => _isDestroyable = value; }
        public bool IsUsable { get => _isUsable; set => _isUsable = value; }
        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
        public bool IsUsed { get => _isUsed; set => _isUsed = value; }
        public bool IsSold { get => _isSold; set => _isSold = value; }
        public bool IsDropped { get => _isDropped; set => _isDropped = value; }
        public bool IsDestroyed { get => _isDestroyed; set => _isDestroyed = value; }
        public bool IsConsumed { get => _isConsumed; set => _isConsumed = value; }
        public bool IsUsedUp { get => _isUsedUp; set => _isUsedUp = value; }

        public LivingEntityObject Owner { get => _owner; set => _owner = value; }

        //public LivingEntityObject Owner { get; set ; }

        public UnityEvent OnUse { get; set; } = new UnityEvent();

        //create all UnityEvent OnEquip, OnUse, OnSell, OnDrop, OnDestroy, OnConsume, OnUseUp.
        public UnityEvent OnEquip { get; set; } = new UnityEvent();
        public UnityEvent OnUnequip { get; set; } = new UnityEvent();
        public UnityEvent OnSell { get; set; } = new UnityEvent();
        public UnityEvent OnDrop { get; set; } = new UnityEvent();
        public UnityEvent OnPickUp { get; set; } = new UnityEvent();
        public UnityEvent OnDestroy { get; set; } = new UnityEvent();
        public UnityEvent OnConsume { get; set; } = new UnityEvent();
        public UnityEvent OnUseUp { get; set; } = new UnityEvent();

        void OnItemEquip()
        {
            if (IsEquippable)
            {
                IsEquipped = true;
            }
            else
            {
                Debug.Log("This item is not equippable");
            }
        }

        void OnItemUnequip()
        {
            if (IsEquippable)
            {
                IsEquipped = false;
            }
            else
            {
                Debug.Log("This item is not equippable");
            }
        }

        void OnItemSell()
        {
            if (IsSellable)
            {
                IsSold = true;
            }
            else
            {
                Debug.Log("This item is not sellable");
            }
        }

        void OnItemDrop()
        {
            if (IsDroppable)
            {
                IsDropped = true;
            }
            else
            {
                Debug.Log("This item is not droppable");
            }
        }

        void OnItemPickUp()
        {
            if (IsPickedUp)
            {
                IsPickedUp = true;
            }
            else
            {
                Debug.Log("This item is not picked up");
            }
        }

        void OnItemDestroy()
        {
            if (IsDestroyable)
            {
                IsDestroyed = true;
            }
            else
            {
                Debug.Log("This item is not destroyable");
            }
        }

        void OnItemConsume()
        {
            if (IsConsumable)
            {
                IsConsumed = true;
            }
            else
            {
                Debug.Log("This item is not consumable");
            }
        }

        void OnItemUseUp()
        {
            if (IsUsable)
            {
                IsUsedUp = true;
            }
            else
            {
                Debug.Log("This item is not usable");
            }
        }
        private void InitializeListener()
        {
            OnEquip.AddListener(OnItemEquip);
            OnUnequip.AddListener(OnItemUnequip);
            OnSell.AddListener(OnItemSell);
            OnDrop.AddListener(OnItemDrop);
            OnPickUp.AddListener(OnItemPickUp);
            OnDestroy.AddListener(OnItemDestroy);
            OnConsume.AddListener(OnItemConsume);
            OnUseUp.AddListener(OnItemUseUp);
        }


        //gererate constructor
        public ItemObject(string name) : base(name)
        {
            InitializeListener();
        }

        public ItemObject() : this("Item")
        {

        }


        public ItemObject(
            int maxStack,
            int currentStack,
            bool isStackable,
            bool isEquippable,
            bool isConsumable,
            bool isSellable,
            bool isDroppable,
            bool isDestroyable,
            bool isUsable,
            bool isEquipped,
            bool isUsed,
            bool isSold,
            bool isDropped,
            bool isDestroyed,
            bool isConsumed,
            bool isUsedUp)
            : this(
            obj: new ItemObject(),
            maxStack: maxStack,
            currentStack: currentStack,
            isStackable: isStackable,
            isEquippable: isEquippable,
            isConsumable: isConsumable,
            isSellable: isSellable,
            isDroppable: isDroppable,
            isDestroyable: isDestroyable,
            isUsable: isUsable,
            isEquipped: isEquipped,
            isUsed: isUsed,
            isSold: isSold,
            isDropped: isDropped,
            isDestroyed: isDestroyed,
            isConsumed: isConsumed,
            isUsedUp: isUsedUp
            )
        {
        }

        public ItemObject(ItemObject obj) : this(
            obj: obj,
            maxStack: obj.MaxStack,
            currentStack: obj.CurrentStack,
            isStackable: obj.IsStackable,
            isEquippable: obj.IsEquippable,
            isConsumable: obj.IsConsumable,
            isSellable: obj.IsSellable,
            isDroppable: obj.IsDroppable,
            isDestroyable: obj.IsDestroyable,
            isUsable: obj.IsUsable,
            isEquipped: obj.IsEquipped,
            isUsed: obj.IsUsed,
            isSold: obj.IsSold,
            isDropped: obj.IsDropped,
            isDestroyed: obj.IsDestroyed,
            isConsumed: obj.IsConsumed,
            isUsedUp: obj.IsUsedUp
        )
        {
        }

        public ItemObject(EntityObject obj) : base(obj) { }

        public ItemObject(
            EntityObject obj,
            int maxStack,
            int currentStack,
            bool isStackable,
            bool isEquippable,
            bool isConsumable,
            bool isSellable,
            bool isDroppable,
            bool isDestroyable,
            bool isUsable,
            bool isEquipped,
            bool isUsed,
            bool isSold,
            bool isDropped,
            bool isDestroyed,
            bool isConsumed,
            bool isUsedUp)
            : this(obj)
        {
            MaxStack = maxStack;
            CurrentStack = currentStack;
            IsStackable = isStackable;
            IsEquippable = isEquippable;
            IsConsumable = isConsumable;
            IsSellable = isSellable;
            IsDroppable = isDroppable;
            IsDestroyable = isDestroyable;
            IsUsable = isUsable;
            IsEquipped = isEquipped;
            IsUsed = isUsed;
            IsSold = isSold;
            IsDropped = isDropped;
            IsDestroyed = isDestroyed;
            IsConsumed = isConsumed;
            IsUsedUp = isUsedUp;

            InitializeListener();
        }

        //generate ToString method
        public override string ToString()
        {
            return $"ItemObject: {Name}, MaxStack: {MaxStack}, CurrentStack: {CurrentStack}, IsStackable: {IsStackable}, IsEquippable: {IsEquippable}, IsConsumable: {IsConsumable}, IsSellable: {IsSellable}, IsDroppable: {IsDroppable}, IsDestroyable: {IsDestroyable}, IsUsable: {IsUsable}, IsEquipped: {IsEquipped}, IsUsed: {IsUsed}, IsSold: {IsSold}, IsDropped: {IsDropped}, IsDestroyed: {IsDestroyed}, IsConsumed: {IsConsumed}, IsUsedUp: {IsUsedUp}";
        }
    }
}
