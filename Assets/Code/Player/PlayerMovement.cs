using UnityEngine;


namespace Assets.Code.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private GameObject playerObject;
        private Camera cam;

        [SerializeField] private float turningSpeed;


        private void Start()
        {
            playerObject = GetComponent<GameObject>();
            cam = Camera.main;
            turningSpeed = 0.02f;
        }

        public void FrameUpdate()
        {
            RotateToMouse();
        }

        /// <summary>
        /// Поворачивает игрока в сторону мыши с заданной скоростью
        /// </summary>
        private void RotateToMouse()
        {
            Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
            float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
            float angleDef = (180 / Mathf.PI) * angleRad;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, angleDef), turningSpeed);
        }
    }
}