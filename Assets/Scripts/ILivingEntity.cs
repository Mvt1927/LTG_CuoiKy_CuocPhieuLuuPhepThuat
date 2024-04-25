using Assets.Lib.Objects;

namespace Assets.Scripts
{
    internal interface ILivingEntity : IEntity
    {
        LivingEntityObject LivingEntityObject { get; set; }

    }
}