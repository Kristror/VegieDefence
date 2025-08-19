using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// ќтвечает за по€вление противников на карте
    /// </summary>
    public class EnemySpawner
    {
        private GameObject enemyObject;
        private EnemyStats stats;
        /// <summary>
        /// ¬рем€ прошлого по€влени€ противника
        /// </summary>
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

        /// <summary>
        /// јктивирует противников через определенные промежутки времени
        /// </summary>
        public void FrameUpdate()
        {
            enemyPool.FrameUpdate();

            if ((Time.time - lastSpawned) >= stats.SpawnSpeed)
            {
                SpawnEnemy();
            }
        }

        /// <summary>
        /// —тавит противника в случайной точке недалеко от границ экрана
        /// </summary>
        private void SpawnEnemy()
        {
            Transform enemy = enemyPool.GetNextItem();

            enemy.GetComponent<EnemyUnit>().Allive();

            float rand = Random.value * 2 * 3.14f;  //получаем случайную точку на периметре круга
            enemy.position = new Vector3(widthScreen * Mathf.Cos(rand), widthScreen * Mathf.Sin(rand));

            lastSpawned = Time.time;
        }

        /// <summary>
        /// ¬ысчитывает границы экрана дл€ по€влени€ противников
        /// </summary>
        private void CalcBoundres()
        {
            Camera cam = Camera.main;

            widthScreen = cam.orthographicSize * cam.aspect + 1;
        }
    }
}
