using Assets.Code.DangerLevels;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Enemy
{
    /// <summary>
    /// Отвечает за характеристики противника
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "MyTools/Enemy stats")]    
    public class EnemyStats : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int damage;
        [SerializeField] private float movmentSpeed;
        [SerializeField] private float spawnSpeed;

        private float spawnSpeedStep = 0.001f;

        private DangerLevelController dangerLevelController;


        /// <summary>
        /// Максимальное здоровье противника
        /// </summary>
        public int MaxHealth => maxHealth + 1 * dangerLevelController.DangerLevel;

        /// <summary>
        /// Урон по игроку
        /// </summary>
        public int Damage => damage + 1 * dangerLevelController.DangerLevel;

        /// <summary>
        /// Скорость движения
        /// </summary>
        public float MovmentSpeed => movmentSpeed;

        /// <summary>
        /// Скорость появления противников
        /// </summary>
        public float SpawnSpeed => spawnSpeed + spawnSpeedStep * dangerLevelController.DangerLevel;

        /// <summary>
        /// Устанавливает характеристики противников на стартовые значения
        /// </summary>
        public void SetBasicStats()
        {
            maxHealth = 1;
            damage = 2;
            movmentSpeed = 0.005f;
            spawnSpeed = 1f;
        }

        public void SetDangerController(DangerLevelController dangerLevelController)
        {
            this.dangerLevelController = dangerLevelController;
        }
    }
}