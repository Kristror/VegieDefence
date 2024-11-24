using Assets.Code.Enemy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        private ClasesEnum baseClass;

        public void Start()
        {
            PlayerStats baseStats;

            string classPath = "Class start stats/PotatoStats"; 

            switch (baseClass)
            {
                case ClasesEnum.Potato: classPath = "Class start stats/PotatoStats"; break;
                case ClasesEnum.Onion: classPath = "Class start stats/OnionStats"; break;
                case ClasesEnum.Pumpkin: classPath = "Class start stats/PumpkinStats"; break;
            }

            baseStats = Resources.Load<PlayerStats>(classPath);

            playerStats.MaxHealth = baseStats.MaxHealth;
            playerStats.Health = baseStats.Health;
            playerStats.Damage = baseStats.Damage;
            playerStats.ShootingSpeed = baseStats.ShootingSpeed;
        }

        public void SetClass(ClasesEnum clasesEnum) // временное решение до появления интерфейса
        {
            baseClass = clasesEnum;
        }


        /// <summary>
        /// Лечит игрока
        /// </summary>
        public void Heal(int amount)
        {
            playerStats.Health += amount;
        }

        /// <summary>
        /// Наносит игроку урон
        /// </summary>
        public void Hurt(int amount)
        {
            playerStats.Health -= amount;
        }

        /// <summary>
        /// Увеличивает масимальное здоровье игрока
        /// </summary>
        public void MaxHealthUpgrade(int amount)
        {
            playerStats.MaxHealth += amount;
        }

        /// <summary>
        /// Увеличивает урон
        /// </summary>
        public void DamageUpgrade()
        {
            playerStats.Damage++;
        }

        public void DamageUP(float duration)
        {
            //Временное  увеличение урона
        }

        /// <summary>
        /// Увеличивает скорость стрельбы
        /// </summary>
        public void ShootingSpeedUpgrade()
        {
            playerStats.ShootingSpeed++;
        }

        public void ShootingSpeedUP(float duration)
        {
            //Временное  увеличение скорости стрельбы
        }
    }
}