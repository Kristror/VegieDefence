using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject EnemyObject;

        private float enemyAmount;
        private float speedOfSpawn;
        private float spawnRange;

        private EnemyPool enemyPool;


        private void Start()
        {
            enemyAmount = 20;
            speedOfSpawn = 10;
            spawnRange = 2;

            enemyPool = new EnemyPool();
        }

        private void SpawnEnemy()
        {
            enemyPool.GetObject();
        }
    }
}
