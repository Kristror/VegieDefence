using UnityEngine;

namespace Assets.Code.Player
{

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletStartPos;

        [SerializeField] private PlayerStats playerStats;

       

        private Transform bullet;
        private BulletPool bulletPool; 
        private const int amountOfBullets = 50;
        private float lastShoot;

        void Start()
        {
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
                bullet = bulletPool.GetNextItem();

                bullet.transform.position = bulletStartPos.transform.position;

                bullet.GetComponent<BulletMovement>().Shoot();
            }
        }
    }
}
