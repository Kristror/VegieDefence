using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.UI
{
    public class PauseController : MonoBehaviour
    {
        public static Action ActivatePause;

        private PauseInputSystem inputSystem;

        private void Start()
        {
            inputSystem = new PauseInputSystem();

            inputSystem.Pause.Pause.performed += Pause;
        }

        private void Pause(InputAction.CallbackContext context)
        {
            ActivatePause.Invoke();
            Debug.Log("Prees");
        }
    }
}