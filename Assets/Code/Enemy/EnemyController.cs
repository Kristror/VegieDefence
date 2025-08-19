using Assets.Code.DangerLevels;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// Отвечает за контроль над появлдением противников и увеличением их характтеристик
    /// </summary>
    public class EnemyController
    {        
        private EnemySpawner spawner;
        private EnemyStats stats;

        public EnemyController(GameObject enemyObject, EnemyStats stats, DangerLevelController dangerLevelController)
        {
            this.stats = stats;
            stats.SetDangerController(dangerLevelController);

            spawner =  new EnemySpawner(enemyObject, stats);
        }

        public void FrameUpdate()
        {
            spawner.FrameUpdate();
        }
    }
}