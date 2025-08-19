using System.Collections;
using UnityEngine;

namespace Assets.Code.Player
{   /// <summary>
    /// Отвечает за движение пули после выстрела
    /// </summary>
    public class BulletMovement : MonoBehaviour
    {
        private float bulletForce;
        private float timeToLive;
        private float startTime;
        private Rigidbody2D rigidBody;
        private Transform bulletStartPos;

        public void SetUp(Transform bulletStartPos)
        {
            this.bulletStartPos = bulletStartPos;
            bulletForce = 1;
            timeToLive = 2;

            rigidBody = GetComponent<Rigidbody2D>();
        }
        /// <summary>
        /// Следит за временем прошедшим с момента выстрела, выключает пулю после определнного времени
        /// </summary>
        public void FrameUpdate()
        {
            if (gameObject.activeSelf)
            {
                if (Time.time - startTime >= timeToLive)
                {
                    Stop();
                }
            }
        }
        /// <summary>
        /// Активация пули после выстрела
        /// </summary>
        public void Shoot()
        {
            gameObject.SetActive(true);
            startTime = Time.time;

            rigidBody.AddForce(bulletStartPos.right * bulletForce, ForceMode2D.Impulse);
        }

        /// <summary>
        /// Остановка пули и возврат в начальное положение
        /// </summary>
        private void Stop() 
        {
            transform.position = Vector3.zero; 
            rigidBody.linearVelocity = Vector2.zero;

            gameObject.SetActive(false);
        }

        /// <summary>
        /// Обработка столкновения
        /// </summary>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Stop();
        }
    }
}