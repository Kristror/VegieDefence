using Assets.Code.Enemy;
using Assets.Code.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Boosters
{    /// <summary>
     /// Класс создающий и отвечающий за массив бонусов
     /// </summary>
    public class BoosterPool : PoolBase
    {    /// <summary>
         /// Создает массив бонусов и заполняет его
         /// </summary>
         /// <param name="poolLenght">Размер массива</param>
         /// <param name="booster">Обьект бонуса</param>
        public BoosterPool(int poolLenght, GameObject booster, Action ShootingSpeedUp, PlayerStatsController playerStatsController)
        {
            poolObject = booster;
            this.poolLenght = poolLenght;

            poolCount = -1;
            CreateBoosterPool(ShootingSpeedUp, playerStatsController);
        }
        
        private void CreateBoosterPool(Action ShootingSpeedUp, PlayerStatsController playerStatsController)
        {
            poolInstanse = new GameObject("BoosterPool").transform;

            poolList = new List<Transform>();

            for (int i = 0; i < poolLenght; i++)
            {
                GameObject item = GameObject.Instantiate(poolObject);

                poolList.Add(item.transform);
                item.transform.SetParent(poolInstanse);
                item.GetComponent<Booster>().SetUp(ShootingSpeedUp, playerStatsController);
                item.SetActive(false);
            }
        }
    }
}