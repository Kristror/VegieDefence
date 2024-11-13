using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private float speed = 0.005f;
        private float speedSteap = 0.001f;

        public void FrameUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed);
        }

        public void SpeedUP()
        {
            speed += speedSteap;
        }
    }
}