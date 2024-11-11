using System.Collections;
using UnityEngine;

namespace Assets.Code.Player
{
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

        private void Stop() 
        {
            transform.position = Vector3.zero; 
            rigidBody.linearVelocity = Vector2.zero;

            gameObject.SetActive(false);
        }
    }
}