using Assets.Code.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Boosters
{
    public class BoosterPool : PoolBase
    {
        /// <param name="poolLenght">Размер массива</param>
        /// <param name="booster">Обьект бустер</param>
        public BoosterPool(int poolLenght, GameObject booster)
        {
            poolObject = booster;
            this.poolLenght = poolLenght;

            poolCount = -1;
            CreateBoosterPool();
        }

        /// <summary>
        /// Создает пул бустеров и заполняет его
        /// </summary>
        private void CreateBoosterPool()
        {
            poolInstanse = new GameObject("BoosterPool").transform;

            poolList = new List<Transform>();

            for (int i = 0; i < poolLenght; i++)
            {
                GameObject item = GameObject.Instantiate(poolObject);

                poolList.Add(item.transform);
                item.transform.SetParent(poolInstanse);
                item.SetActive(false);
            }
        }
    }
}