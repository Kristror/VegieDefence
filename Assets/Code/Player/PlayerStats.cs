using UnityEngine;

namespace Assets.Code.Player
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "MyTools/Player stats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        [SerializeField] private int damage;
        [SerializeField] private float shootingSpeed;

        private int booster = 1;

        /// <summary>
        /// Здоровье игрока
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            { 
                health = value;
                if (health > maxHealth) health = maxHealth;
            }
        }

        /// <summary>
        /// Максимальное здоровье игрока
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                if (value > 0)
                {
                    maxHealth = value;
                }
            }
        }

        /// <summary>
        /// Урон игрока
        /// </summary>
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 0)
                {
                    damage = value;
                }
            }
        }

        /// <summary>
        /// Скорость стрельбы
        /// </summary>
        public float ShootingSpeed
        {
            get
            {
                return shootingSpeed * booster;
            }
            set
            {
                if (value > 0)
                {
                    shootingSpeed = value;
                }
            }
        }

        /// <summary>
        /// Удвоение скорости стрельбы
        /// </summary>
        public void Booster()
        {
            if (booster == 1)
            {
                booster = 2;
            }
            else booster = 1;
        }
    }
}