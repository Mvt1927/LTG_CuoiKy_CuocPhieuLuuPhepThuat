using UnityEngine;


namespace Assets.Lib.Objects
{
    [System.Serializable]
    public class EntityObject : IEntityObject
    {

        [SerializeField] private string _name = "Entity";
        [SerializeField] private string _description = "Entity Description";

#if UNITY_EDITOR
        [SerializeField]
#else
        [NonSerialized]
#endif
        private GameObject _gameObject;

#if UNITY_EDITOR
        [SerializeField]
#else
        [NonSerialized]
#endif
        private Transform _transform;

        [SerializeField] private Vector2 _direction = Vector2.right;
        [SerializeField]
        private float _speed = 2, _acceleration = 50, _deceleration = 100;

        public string Name { get => _name; set => _name = value; }

        public GameObject GameObject { get => _gameObject; private set => _gameObject = value; }
        public Transform Transform { get => _transform; private set => _transform = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float Acceleration { get => _acceleration; set => _acceleration = value; }
        public float Deceleration { get => _deceleration; set => _deceleration = value; }
        public Vector2 Direction { get => _direction; set => _direction = value; }
        public string Description { get => _description; set => _description = value; }


        //genrate functions to Initialize the gameobject and transform
        public void InitializeGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
            Transform = gameObject.transform;
        }

        public void InitializeGameObject(Transform transform)
        {
            Transform = transform;
            GameObject = transform.gameObject;
        }

        public EntityObject(string name)
        {
            Name = name;
        }

        public EntityObject() : this("Entity") { }

        public EntityObject(
            string name,
            string description,
            float speed,
            float acceleration,
            float deceleration,
            Vector2 direction
            ) : this(name)
        {
            Description = description;
            Speed = speed;
            Acceleration = acceleration;
            Deceleration = deceleration;
            Direction = direction;
        }
        public EntityObject(EntityObject obj) : this(
            name: obj.Name,
            description: obj.Description,
            speed: obj.Speed,
            acceleration: obj.Acceleration,
            deceleration: obj.Deceleration,
            direction: obj.Direction
        )
        { }
    }
}