using System.Collections;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemyController
    {
        //Передавать противникам новые данные о здоровье, уроне и
        //увеличивать скорость появления противников с течением времени
        private EnemySpawner spawner;

        public EnemyController(GameObject enemyObject)
        {
            spawner =  new EnemySpawner(enemyObject);
        }

        public void FrameUpdate()
        {
            spawner.FrameUpdate();
        }
    }
}