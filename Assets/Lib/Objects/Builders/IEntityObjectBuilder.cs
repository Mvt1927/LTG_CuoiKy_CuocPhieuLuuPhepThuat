using UnityEngine;

namespace Assets.Lib.Objects.Builders
{
    interface IEntityObjectBuilder
    {
        // Generate bulder pattern for EntityObject
        EntityObjectBuilder AddName(string name);

        EntityObjectBuilder AddDescription(string description);

        EntityObjectBuilder AddSpeed(float speed);

        EntityObjectBuilder AddAcceleration(float acceleration);

        EntityObjectBuilder AddDeceleration(float deceleration);

        EntityObjectBuilder AddDirection(Vector2 direction);

        EntityObject Build();


    }
}
