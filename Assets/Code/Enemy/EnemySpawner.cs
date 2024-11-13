using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemySpawner
    {
        private GameObject enemyObject;

        private int enemyAmount;
        private float speedOfSpawn;
        private float spawnRange;

        private EnemyPool enemyPool;


        public EnemySpawner(GameObject enemyObject)
        {
            this.enemyObject = enemyObject;
            enemyAmount = 20;
            speedOfSpawn = 10;
            spawnRange = 2;

            enemyPool = new EnemyPool(enemyAmount, this.enemyObject);
        }

        public void FrameUpdate()
        {
            enemyPool.FrameUpdate();
        }

        private void SpawnEnemy()
        {
            enemyPool.GetObject();
            //перемещать противника в зону за экраном
        }
    }
}
