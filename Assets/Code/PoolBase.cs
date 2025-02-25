using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    abstract public class PoolBase
    {
        public Transform poolInstanse;
        public List<Transform> poolList;
        public int poolLenght;
        public int poolCount;

        public GameObject poolObject;   

        /// <summary>
        /// Передает следующий объект
        /// </summary>
        public Transform GetNextItem()
        {
            poolCount++;
            if (poolCount == poolLenght)
            {
                poolCount = 0;
            }

            return poolList[poolCount];
        }
    }
}