using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.UI
{
    public class PauseController : MonoBehaviour
    {
        public static Action ActivatePause;

        InputAction jumpAction;

        private InputControls inputSystem;

        private void Start()
        {
            inputSystem = new InputControls();

            inputSystem.Enable();

            inputSystem.PauseImput.Pause.performed += Pause;
        }


        private void Pause(InputAction.CallbackContext context)
        {
            if (Time.timeScale != 0)
            {
                ActivatePause?.Invoke();
            }
        }
    }
}