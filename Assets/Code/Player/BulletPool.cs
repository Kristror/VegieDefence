using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    /// <summary>
    /// Массив управляющий пулями для стрельбы
    /// </summary>
    public class BulletPool 
    {
        private Transform poolObject;
        private List<Transform> bulletPool;
        private int poolLenght;
        private int bulletCount;

        private GameObject bullet;

        
        /// <param name="poolLenght">Размер массива</param>
        /// <param name="bullet">Обьект пули</param>
        public BulletPool(int poolLenght, GameObject bullet)
        {
            this.bullet = bullet;
            this.poolLenght = poolLenght;

            bulletCount = -1;
            CreateBulletPool();
        }

        /// <summary>
        /// Создает и заполняет пул с пулями для стрельбы
        /// </summary>
        private void CreateBulletPool()
        {
            poolObject = new GameObject("bulletPool").transform;

            bulletPool = new List<Transform>();

            poolLenght = 150;

            for (int i = 0; i < poolLenght; i++)
            {
                GameObject item = GameObject.Instantiate(bullet);

                bulletPool.Add(item.transform);

                item.transform.SetParent(poolObject);
                item.SetActive(false);
            }
        }

        /// <summary>
        /// Передает пулю для стрельбы
        /// </summary>
        public Transform GetBullet()
        {
            bulletCount++;
            if (bulletCount == poolLenght)
            {
                bulletCount = 0;
            }

            return bulletPool[bulletCount];
        }
    }
}