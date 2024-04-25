using UnityEngine;

namespace Assets.Scripts
{
    public class EntityAnimator : MonoBehaviour, IEntityAnimator
    {

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private GameObject _sprite;

        private bool oldIsRightDir = true;
        private bool oldIsMove = false;

        public enum SpriteState
        {
            Spawn, Idle, Run
        }

        //private Vector2 currentDirection = Vector2.right;

        public bool IsRightDir { get; set; } = true;
        public bool IsMove { get; set; } = false;


        private void Awake()
        {
            _sprite = transform.Find("Sprite").gameObject;
            if (_sprite != null)
            {
                _sprite.TryGetComponent(out animator);
            }
        }

        void Start()
        {
            PlaySpriteAnimation(SpriteState.Spawn);
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Turn();
        }

        void PlaySpriteAnimation(SpriteState state)
        {
            if (animator == null) return;
            switch (state)
            {
                case SpriteState.Spawn:
                    animator.SetInteger("SpriteState", (int)SpriteState.Spawn);
                    break;
                case SpriteState.Idle:
                    animator.SetInteger("SpriteState", (int)SpriteState.Idle);
                    break;
                case SpriteState.Run:
                    animator.SetInteger("SpriteState", (int)SpriteState.Run);
                    break;
                default:
                    break;
            }
        }

        public void Idle()
        {
            PlaySpriteAnimation(SpriteState.Idle);
        }

        public void Move()
        {
            if (oldIsMove != IsMove)
            {
                if (IsMove == true)
                {
                    PlaySpriteAnimation(SpriteState.Run);
                }
                else
                {
                    PlaySpriteAnimation(SpriteState.Idle);
                }
                oldIsMove = IsMove;
            }
        }

        public void Turn()
        {
            if (oldIsRightDir != IsRightDir)
            {
                Flip();
                oldIsRightDir = IsRightDir;
            }
        }

        public void Flip()
        {
            transform.Rotate(0, 180, 0);
        }
    }

}