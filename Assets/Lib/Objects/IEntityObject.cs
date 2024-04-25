using UnityEngine;

namespace Assets.Lib.Objects
{
    internal interface IEntityObject
    {
        public GameObject GameObject { get; }

        public Transform Transform { get; }
        public float Speed { get; set; }
        public float Acceleration { get; set; }
        public float Deceleration { get; set; }
        public Vector2 Direction { get; set; }
    }
}
