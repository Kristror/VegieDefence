using System.Collections;
using UnityEngine;

namespace Assets.Code.Enemy
{

    [CreateAssetMenu(fileName = "MyTool/EnemyStats", menuName = "Enemy stats")]
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private float movmentSpeed;
        [SerializeField] private float spawnSpeed;

        private float speedStep = 0.001f;



        /// <summary>
        /// Максимальное здоровье противника
        /// </summary>
        public int MaxHealth => maxHealth;

        /// <summary>
        /// Урон по игроку
        /// </summary>
        public int Damage => damage;

        /// <summary>
        /// Скорость движения
        /// </summary>
        public float MovmentSpeed => movmentSpeed;

        /// <summary>
        /// Скорость движения
        /// </summary>
        public float SpawnSpeed => spawnSpeed;

        public void SpeedUP()
        {
            movmentSpeed += spawnSpeed;
        }

        public void SetBasicStats()
        {
            maxHealth = 1;
            damage = 2;
            movmentSpeed = 0.005f;
            spawnSpeed = 1f;
        }
    }
}