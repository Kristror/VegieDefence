using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {

        [SerializeField] private EnemyStats stats;

        private float speed;

        public void Start()
        {
            speed = stats.MovmentSpeed;
        }

        public void FrameUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed);
        }
    }
}