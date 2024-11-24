using UnityEngine;

namespace Assets.Code.Player
{

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletStartPos;

        [SerializeField] private PlayerStats playerStats;

        private int amountOfBullets;

        private Transform bullet;
        private BulletPool bulletPool;
        private float lastShoot;

        void Start()
        {

            amountOfBullets = 50;

            lastShoot = Time.time;
            bulletPool = new BulletPool(amountOfBullets, bulletPrefab, bulletStartPos.transform);
        }

        public void FrameUpdate()
        {
            Shoot();
            bulletPool.FrameUpdate();
        }

        /// <summary>
        /// Стреляет в прямом направлении от игрока, с заданной скоростью
        /// </summary>
        private void Shoot()
        {
            if ((Time.time - lastShoot) >= playerStats.ShootingSpeed)
            {
                lastShoot = Time.time;
                bullet = bulletPool.GetObject();

                bullet.transform.position = bulletStartPos.transform.position;
                //bullet.transform.rotation = bulletStartPos.transform.rotation;

                bullet.GetComponent<BulletMovement>().Shoot();
            }
        }
    }
}
