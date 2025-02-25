using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemySpawner
    {
        private GameObject enemyObject;
        private EnemyStats stats;
        private float lastSpawned;

        private float widthScreen;

        private EnemyPool enemyPool;
        private const int enemyPollLength = 200;


        public EnemySpawner(GameObject enemyObject, EnemyStats stats)
        {
            this.enemyObject = enemyObject;
            this.stats = stats;

            
            lastSpawned = Time.time;

            CalcBoundres();

            enemyPool = new EnemyPool(enemyPollLength, this.enemyObject);

        }

        public void FrameUpdate()
        {
            enemyPool.FrameUpdate();

            if ((Time.time - lastSpawned) >= stats.SpawnSpeed)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Transform enemy = enemyPool.GetNextItem();

            enemy.GetComponent<EnemyUnit>().Allive();

            float rand = Random.value * 2 * 3.14f;  //получаем случайную точку па периметре круга
            enemy.position = new Vector3(widthScreen * Mathf.Cos(rand), widthScreen * Mathf.Sin(rand));

            lastSpawned = Time.time;
        }

        private void CalcBoundres()
        {
            Camera cam = Camera.main;

            widthScreen = cam.orthographicSize * cam.aspect + 1;
        }
    }
}
