using UnityEngine;
using UnityEngine.InputSystem;
using UdemyProje3.Abstracts.Inputs;
using System.Collections;

namespace UdemyProje3.Inputs
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        int _index;
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }
        public bool IsAttackButtonPress { get; private set; }

        public bool IsInventoryButtonPressed { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirectrion = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirectrion.x, 0f, oldDirectrion.y);
        }
        public void OnRatotaor(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            IsAttackButtonPress = context.ReadValueAsButton();
        }
        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            if (IsInventoryButtonPressed && context.action.triggered) return;
            StartCoroutine(WaitOnFrameAsync());
        }

        IEnumerator WaitOnFrameAsync()
        {
            IsInventoryButtonPressed = true&&_index%2==0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
            _index++;
        }
    }
}

