using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    /// <summary>
    /// Массив управляющий пулями для стрельбы
    /// </summary>
    public class BulletPool : PoolBase
    {
        /// <param name="poolLenght">Размер массива</param>
        /// <param name="bullet">Обьект пули</param>
        public BulletPool(int poolLenght, GameObject bullet, Transform bulletStartPos)
        {
            poolObject = bullet;
            this.poolLenght = poolLenght;

            poolCount = -1;
            CreateBulletPool(bulletStartPos);
        }

        /// <summary>
        /// Создает и заполняет пул с пулями для стрельбы
        /// </summary>
        private void CreateBulletPool(Transform bulletStartPos)
        {
            poolInstanse = new GameObject("BulletPool").transform;

            poolList = new List<Transform>();

            for (int i = 0; i < poolLenght; i++)
            {
                GameObject item = GameObject.Instantiate(poolObject);

                item.GetComponent<BulletMovement>().SetUp(bulletStartPos);

                poolList.Add(item.transform);
                item.transform.SetParent(poolInstanse);
                item.SetActive(false);
            }
        }

        public void FrameUpdate()
        {
            foreach (Transform item in poolList)
            {
                if (item.gameObject.activeSelf) item.GetComponent<BulletMovement>().FrameUpdate();
            } 
        }
    }
}