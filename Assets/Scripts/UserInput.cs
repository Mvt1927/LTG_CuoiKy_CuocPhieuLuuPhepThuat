using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class UserInput : MonoBehaviour
    {
        [Space(1)]
        [Header("User Input")]
        [SerializeField] private InputActionReference movement;
        [SerializeField] private InputActionReference interact, pointerPosition;

        [SerializeField]
        private Vector2 movementInput;

        private void Update()
        {
            if (movement != null)
            {
                movementInput = movement.action.ReadValue<Vector2>();
            }

            if (TryGetComponent(out EntityMover entityMover))
            {
                entityMover.MovermentInput = movementInput;
            }
        }
    }
}
