using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        [SerializeField] PlayerStats playerStats;

        public void SetUp(PlayerStats baseStats)
        {
            playerStats.MaxHealth = baseStats.MaxHealth;
            playerStats.Health = baseStats.Health;
            playerStats.Damage = baseStats.Damage;
            playerStats.ShootingSpeed = baseStats.ShootingSpeed;
        }

        public void Heal(int amount)
        {
            playerStats.Health += amount;
        }

        public void Hurt(int amount)
        {
            playerStats.Health -= amount;
        }
        
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
        public void SpeedUpgrade()
        {
            playerStats.ShootingSpeed++;
        }

        public void SpeedUP(float duration)
        {
            //Временное  увеличение скорости стрельбы
        }
    }
}