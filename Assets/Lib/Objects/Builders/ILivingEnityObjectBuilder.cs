namespace Assets.Lib.Objects.Builders
{
    interface ILivingEnityObjectBuilder
    {
        LivingEntityObjectBuilder AddHealthPoint(float healthPoint);
        LivingEntityObjectBuilder AddDamagePoint(float damagePoint);
        LivingEntityObjectBuilder AddManaPoint(float manaPoint);
        LivingEntityObjectBuilder AddIsHoldable(bool isHoldable);

        LivingEntityObjectBuilder AddEntityObject(EntityObject entityObject);

        LivingEntityObject Build();
    }
}