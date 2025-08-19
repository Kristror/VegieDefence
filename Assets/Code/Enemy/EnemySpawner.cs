using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// �������� �� ��������� ����������� �� �����
    /// </summary>
    public class EnemySpawner
    {
        private GameObject enemyObject;
        private EnemyStats stats;
        /// <summary>
        /// ����� �������� ��������� ����������
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
        /// ���������� ����������� ����� ������������ ���������� �������
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
        /// ������ ���������� � ��������� ����� �������� �� ������ ������
        /// </summary>
        private void SpawnEnemy()
        {
            Transform enemy = enemyPool.GetNextItem();

            enemy.GetComponent<EnemyUnit>().Allive();

            float rand = Random.value * 2 * 3.14f;  //�������� ��������� ����� �� ��������� �����
            enemy.position = new Vector3(widthScreen * Mathf.Cos(rand), widthScreen * Mathf.Sin(rand));

            lastSpawned = Time.time;
        }

        /// <summary>
        /// ����������� ������� ������ ��� ��������� �����������
        /// </summary>
        private void CalcBoundres()
        {
            Camera cam = Camera.main;

            widthScreen = cam.orthographicSize * cam.aspect + 1;
        }
    }
}
