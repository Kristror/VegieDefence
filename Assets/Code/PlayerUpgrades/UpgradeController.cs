using Assets.Code.Enemy;
using Assets.Code.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Code.PlayerUpgrades
{
    public class UpgradeController : MonoBehaviour
    {
        private int upgradePoints;
        private int upgradePrice;

        private const int pointsForEnemy = 2;
        private const int maxHealthUpgrade = 25;
        private const int damageUpgrade = 2;
        private const float shootingSpeedUpgrade = 0.02f;

        private PlayerStatsController playerStats;

        public int Points => upgradePoints;
        public int Price => upgradePrice;

        private void Start()
        {
            upgradePoints = 0;
            upgradePrice = 20;
            EnemyUnit.onEnemyKilled += EnemyKilled;
        }

        public void SetPlayerStatsController(PlayerStatsController playerStatsController)
        {
            playerStats = playerStatsController;
        }

        private void EnemyKilled()
        {
            upgradePoints += pointsForEnemy; 
        }

        public void MaxHealthUpgrade()
        {
            playerStats.MaxHealthUpgrade(maxHealthUpgrade);
            UpgradeCostUp();
        }

        public void DamageUpgrade()
        {
            playerStats.DamageUpgrade(damageUpgrade);
            UpgradeCostUp();
        }

        public void ShootingSpeedUpgrade()
        {
            playerStats.ShootingSpeedUpgrade(shootingSpeedUpgrade);
            UpgradeCostUp();
        }

        private void UpgradeCostUp()
        {
            upgradePrice += upgradePrice/2;
        }
    }
}