using Assets.Code.UI;
using System;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        private PlayerStats playerStats;

        public Action PlayerDeath;
        public Action HpUpdated;

        public int PlayerHealth => playerStats.Health;
        public int PlayerMaxHealth => playerStats.MaxHealth;

        public void Start()
        {
            GameObject.Find("UI").GetComponentInChildren<DeathScreen>(true).PlayerRevive += Revive;
        }

        public void SetClass(ClassesEnum playerClass) 
        {

            playerStats = Resources.Load<PlayerStats>("PlayerStats");

            PlayerStats baseStats;

            string classPath;

            switch (playerClass)
            {
                case ClassesEnum.Potato: 
                    classPath = "Class start stats/PotatoStats"; 
                break;
                case ClassesEnum.Onion: 
                    classPath = "Class start stats/OnionStats"; 
                break;
                case ClassesEnum.Pumpkin: 
                    classPath = "Class start stats/PumpkinStats"; 
                break;

                default: 
                    classPath = "Class start stats/PotatoStats"; 
                break;
            }

            baseStats = Resources.Load<PlayerStats>(classPath);

            playerStats.MaxHealth = baseStats.MaxHealth;
            playerStats.Health = baseStats.Health;
            playerStats.Damage = baseStats.Damage;
            playerStats.ShootingSpeed = baseStats.ShootingSpeed;
        }


        /// <summary>
        /// Лечит игрока
        /// </summary>
        public  void Heal(int amount)
        {
            playerStats.Health += amount;
            HpUpdated?.Invoke();
        }

        /// <summary>
        /// Лечит на 2% от макс здоровья
        /// </summary>
        public void Regen() 
        { 
            playerStats.Health += (int)(playerStats.MaxHealth*0.02);
            HpUpdated?.Invoke();
        }

        /// <summary>
        /// Наносит игроку урон
        /// </summary>
        public void Hurt(int amount)
        {
            playerStats.Health -= amount;
            HpUpdated?.Invoke();
            CheckHealth();
        }

        /// <summary>
        /// Увеличивает масимальное здоровье игрока
        /// </summary>
        public void MaxHealthUpgrade(int amount)
        {
            playerStats.MaxHealth += amount;
            HpUpdated?.Invoke();
        }

        /// <summary>
        /// Увеличивает урон
        /// </summary>
        public void DamageUpgrade(int amount)
        {
            playerStats.Damage += amount;
        }

        /// <summary>
        /// Увеличивает скорость стрельбы
        /// </summary>
        public void ShootingSpeedUpgrade(float amount)
        {
            playerStats.ShootingSpeed -= amount;
        }

        /// <summary>
        /// Включает удвоение скорости стрельбы
        /// </summary>
        public void ActivateBooster()
        {
            playerStats.ActivateBooster();
        }
        /// <summary>
        /// Выключает удвоение скорости стрельбы
        /// </summary>
        public void DeactivateBooster()
        {
            playerStats.DeactivateBooster();
        }

        /// <summary>
        /// Проверяет уровень издоровья игрока, следит за смертью
        /// </summary>
        private void CheckHealth()
        {
            if (playerStats.Health < (playerStats.MaxHealth * 0.25))
            {
                //эффект низкого здоровья
            }
            if (playerStats.Health <= 0)
            {
                Death();
            }
        }

        /// <summary>
        /// Активирует смерть
        /// </summary>
        private void Death()
        {
            Time.timeScale = 0;
            PlayerDeath?.Invoke();
        }

        /// <summary>
        /// Активирует возрождение
        /// </summary>
        private void Revive()
        {
            Heal(playerStats.MaxHealth / 2);
        }
    }
}