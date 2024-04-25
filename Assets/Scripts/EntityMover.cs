using Assets.Lib.Objects;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(IEntity), typeof(Rigidbody2D))]
    public class EntityMover : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody2D rb2d;
        private Vector2 oldMovementInput;
        public bool isRightDir = true;
        EntityAnimator entityAnimator;

        [SerializeField]
        private float currentSpeed = 0;

        [SerializeField]
        private EntityObject entityObject;

        public Vector2 MovermentInput { get; set; }

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            TryGetComponent(out entityAnimator);
        }

        void Start()
        {
            entityObject = GetComponent<IEntity>().EntityObject;
        }

        private void Update()
        {
            MoveAnimation();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (MovermentInput.magnitude > 0 && currentSpeed >= 0)
            {
                oldMovementInput = MovermentInput;
                currentSpeed += entityObject.Acceleration * entityObject.Speed * Time.fixedDeltaTime;
            }
            else
            {
                currentSpeed -= entityObject.Deceleration * entityObject.Speed * Time.fixedDeltaTime;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, 0, entityObject.Speed);
            rb2d.velocity = oldMovementInput * currentSpeed;
        }

        private void MoveAnimation()
        {
            if (entityAnimator != null)
            {
                if (rb2d.velocity != Vector2.zero)
                {
                    entityAnimator.IsMove = true;
                }
                else
                {
                    entityAnimator.IsMove = false;
                }

                if (MovermentInput.x > 0)
                {
                    entityAnimator.IsRightDir = true;
                }
                else if (MovermentInput.x < 0)
                {
                    entityAnimator.IsRightDir = false;
                }
            }
        }
    }

}