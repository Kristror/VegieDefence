using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemySpawner
    {
        private GameObject enemyObject;
        private EnemyStats stats;

        private int enemyAmount;
        private float lastSpawned;

        private float widthScreen;

        private EnemyPool enemyPool;


        public EnemySpawner(GameObject enemyObject, EnemyStats stats)
        {
            this.enemyObject = enemyObject;
            this.stats = stats;

            enemyAmount = 200;
            lastSpawned = Time.time;

            CalcBoundres();

            enemyPool = new EnemyPool(enemyAmount, this.enemyObject);

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
            Transform enemy = enemyPool.GetObject();

            enemy.GetComponent<Enemy>().Allive();

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
