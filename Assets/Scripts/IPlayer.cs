using Assets.Lib.Objects;
namespace Assets.Scripts
{
    internal interface IPlayer : ILivingEntity
    {
        PlayerObject PlayerObject { get; set; }

    }
}