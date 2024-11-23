using System.Collections;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemyController
    {
        //Передавать противникам новые данные о здоровье, уроне и
        //увеличивать скорость появления противников с течением времени
        private EnemySpawner spawner;
        private EnemyStats stats;

        public EnemyController(GameObject enemyObject, EnemyStats stats)
        {
            this.stats = stats;
            spawner =  new EnemySpawner(enemyObject, stats);
        }

        public void FrameUpdate()
        {
            spawner.FrameUpdate();
        }
    }
}