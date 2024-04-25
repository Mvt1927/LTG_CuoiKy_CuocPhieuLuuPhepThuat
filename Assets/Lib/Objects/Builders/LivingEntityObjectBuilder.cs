namespace Assets.Lib.Objects.Builders
{
    public class LivingEntityObjectBuilder : ILivingEnityObjectBuilder
    {
        // Default values of LivingEntityObject
        float DamagePoint { get; set; } = 0;
        float HealthPoint { get; set; } = 0;
        float ManaPoint { get; set; } = 0;
        bool IsHoldable { get; set; } = true;

        EntityObject EntityObject { get; set; } = new EntityObjectBuilder().Build();


        // Fluent API methods
        public LivingEntityObjectBuilder AddDamagePoint(float damagePoint)
        {
            DamagePoint = damagePoint;
            return this;
        }

        public LivingEntityObjectBuilder AddEntityObject(EntityObject entityObject)
        {
            EntityObject = entityObject;
            return this;
        }

        public LivingEntityObjectBuilder AddHealthPoint(float healthPoint)
        {
            HealthPoint = healthPoint;
            return this;
        }

        public LivingEntityObjectBuilder AddManaPoint(float manaPoint)
        {
            ManaPoint = manaPoint;
            return this;
        }

        public LivingEntityObjectBuilder AddIsHoldable(bool isHoldable)
        {
            IsHoldable = isHoldable;
            return this;
        }

        public LivingEntityObject Build()
        {
            return new LivingEntityObject(
                obj: EntityObject,
                healthPoint: HealthPoint,
                damagePoint: DamagePoint, 
                manaPoint: ManaPoint,
                isHoldable: IsHoldable
                );
        }
    }
}
