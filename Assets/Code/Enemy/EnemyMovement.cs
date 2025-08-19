using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// Отвечает за передвижения противника
    /// </summary>
    public class EnemyMovement : MonoBehaviour
    {

        [SerializeField] private EnemyStats stats;
        /// <summary>
        /// Скорость движения противника
        /// </summary>
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