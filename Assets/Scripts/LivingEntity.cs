using Assets.Lib.Objects;
using Assets.Lib.Objects.Builders;
using UnityEngine;

namespace Assets.Scripts
{
    internal class LivingEntity : MonoBehaviour, ILivingEntity
    {
        public LivingEntityObject livingEntityObject = new LivingEntityObjectBuilder().Build();

        public EntityObject EntityObject { get => livingEntityObject; set => livingEntityObject = (LivingEntityObject)value; }
        public LivingEntityObject LivingEntityObject { get => livingEntityObject; set => livingEntityObject = value; }

        void Initialize()
        {
            livingEntityObject.Name = gameObject.name;
            livingEntityObject.InitializeGameObject(gameObject);

        }

        private void Awake()
        {
            Initialize();
        }

    }
}
