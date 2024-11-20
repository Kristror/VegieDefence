using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemySpawner
    {
        private GameObject enemyObject;

        private int enemyAmount;
        private float speedOfSpawn;
        private float lastSpawned;

        private float widthScreen;

        private EnemyPool enemyPool;


        public EnemySpawner(GameObject enemyObject)
        {
            this.enemyObject = enemyObject;

            enemyAmount = 100;
            speedOfSpawn = 0.1f;
            lastSpawned = Time.time;

            CalcBoundres();

            enemyPool = new EnemyPool(enemyAmount, this.enemyObject);

        }

        public void FrameUpdate()
        {
            enemyPool.FrameUpdate();

            if ((Time.time - lastSpawned) >= speedOfSpawn)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Transform enemy = enemyPool.GetObject();

            //нельзя брать живой обьект

            enemy.GetComponent<Enemy>().Allive();

            float rand = Random.value * 2 * 3.14f;
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
