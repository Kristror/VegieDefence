using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// Класс создающий и отвечающий за массив противников
    /// </summary>
    public class EnemyPool : PoolBase
    {
        /// <summary>
        /// Создает массив противников и заполняет его
        /// </summary>
        /// <param name="poolLenght">Размер массива</param>
        /// <param name="enemy">Обьект противника</param>
        public EnemyPool(int poolLenght, GameObject enemy)
        {
            poolObject = enemy;
            this.poolLenght = poolLenght;

            poolCount = -1;
            CreateEnemyPool();
        }

        private void CreateEnemyPool() 
        {
            poolInstanse = new GameObject("EnemyPool").transform;

            poolList = new List<Transform>();

            for (int i = 0; i < poolLenght; i++)
            {
                GameObject item = GameObject.Instantiate(poolObject);

                poolList.Add(item.transform);
                item.transform.SetParent(poolInstanse);
                item.SetActive(false);
            }
        }

        /// <summary>
        /// Передает команду движения всем активным противникам
        /// </summary>
        public void FrameUpdate()
        {
            foreach (Transform item in poolList)
            {
                if (item.gameObject.activeSelf) item.GetComponent<EnemyMovement>().FrameUpdate();
            }
        }
    }
}