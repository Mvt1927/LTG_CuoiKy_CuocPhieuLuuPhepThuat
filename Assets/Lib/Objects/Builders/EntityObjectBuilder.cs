using System.Diagnostics;
using UnityEngine;

namespace Assets.Lib.Objects.Builders
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class EntityObjectBuilder : IEntityObjectBuilder
    {
        string Name { get; set; } = "Entity";
        string Description { get; set; } = "Entity Description";
        float Speed { get; set; } = 2;
        float Acceleration { get; set; } = 50;
        public float Deceleration { get; set; } = 100;
        Vector2 Direction { get; set; } = Vector2.right;

        public EntityObjectBuilder AddName(string name)
        {
            Name = name;
            return this;
        }

        public EntityObjectBuilder AddDescription(string description)
        {
            Description = description;
            return this;
        }
        
        public EntityObjectBuilder AddSpeed(float speed)
        {
            Speed = speed;
            return this;
        }

        public EntityObjectBuilder AddAcceleration(float acceleration)
        {
            Acceleration = acceleration;
            return this;
        }

        public EntityObjectBuilder AddDeceleration(float deceleration)
        {
            Deceleration = deceleration;
            return this;
        }

        public EntityObjectBuilder AddDirection(Vector2 direction)
        {
            Direction = direction;
            return this;
        }

        public virtual EntityObject Build()
        {
            return new EntityObject(
                name: Name,
                description: Description,
                speed: Speed,
                acceleration: Acceleration,
                deceleration: Deceleration,
                direction: Direction
                );
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }


    }
}
