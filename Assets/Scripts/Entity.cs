using Assets.Lib.Objects;
using Assets.Lib.Objects.Builders;
using UnityEngine;
namespace Assets.Scripts
{
    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        EntityObject entityObject = new EntityObjectBuilder().Build();

        public virtual EntityObject EntityObject { get => entityObject; set => entityObject = value; }


        void SetUp()
        {
            entityObject.Name = gameObject.name;
            entityObject.InitializeGameObject(gameObject);
        }


        private void Awake()
        {
            SetUp();
        }

    }

}