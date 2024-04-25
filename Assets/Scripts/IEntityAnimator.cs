namespace Assets.Scripts
{
    public interface IEntityAnimator
    {
        bool IsMove { get; set; }
        bool IsRightDir { get; set; }

        void Flip();
        void Idle();
        void Move();
        void Turn();
    }
}