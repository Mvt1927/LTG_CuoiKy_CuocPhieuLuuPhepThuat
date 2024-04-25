using Assets.Lib.Objects;

namespace Assets.Scripts
{
    public interface IEntity
    {
        EntityObject EntityObject { get; set; }

        void SetUp() { }

    }
}