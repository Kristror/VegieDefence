using Assets.Code.Player;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletStartPos;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private int amountOfBullets;

    private Transform bullet;
    private BulletPool bulletPool;
    private float lastShoot;

    void Start()
    {
        amountOfBullets = 150;
        shootingSpeed = 1;

        lastShoot = Time.time;
        bulletPool = new BulletPool(amountOfBullets, bulletPrefab);
    }    

    public void FrameUpdate()
    {
        Shoot();
    }

    /// <summary>
    /// Стреляет в прямом направлении от игрока, с заданной скоростью
    /// </summary>
    private void Shoot()
    {
        if( (Time.time-lastShoot) >= shootingSpeed)
        {
            lastShoot = Time.time;
            bullet = bulletPool.GetBullet();

            

        }
    }
}
