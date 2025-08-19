using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Boosters
{
    /// <summary>
    /// Отвечает за появление бонусов для игрока
    /// </summary>
    public class BoosterController
    {   /// <summary>
        /// Время через которое появляются бонусы
        /// </summary>
        private const float timeToSpawn = 2;
        /// <summary>
        /// Когда появился последний бонус
        /// </summary>
        private float lastSpawn;

        private BoosterPool boosterPool;
        private const int boosterPoolLenght = 10;
        /// <summary>
        /// Радиус круга в тором могут появлятся бонусы
        /// </summary>
        private const int circleRadius = 5;
        /// <summary>
        /// Включен ли бонус ускорения стрельбы
        /// </summary>
        private bool isShootingBoosterActive;
        /// <summary>
        /// Продолжительность бонуса ускорения стрельбы
        /// </summary>
        private const float durationSotingBooster = 15;
        /// <summary>
        /// Время начала активации бонуса ускорения стрельбы
        /// </summary>
        private float timeShootingBoosterStart;

        private PlayerStatsController playerStatsController;

        public BoosterController(GameObject booster, PlayerStatsController playerStatsController)
        {
            this.playerStatsController = playerStatsController;
            lastSpawn = 0;
            boosterPool = new BoosterPool(boosterPoolLenght, booster, ShootingSpeedUp, playerStatsController);
            StopShootingBooster();
        }

        public void FrameUpdate()
        {
            if(Time.time - lastSpawn >= timeToSpawn)
            {
                lastSpawn = Time.time;
                SpawnBooster();
            }
            if(Time.time - timeShootingBoosterStart>= durationSotingBooster)
            {
                StopShootingBooster();
            }
        }

        private void ShootingSpeedUp()
        {
            timeShootingBoosterStart = Time.time;
            if (!isShootingBoosterActive)
            {
                isShootingBoosterActive = true;
                playerStatsController.ActivateBooster();
            }
        }

        private void StopShootingBooster()
        {
            isShootingBoosterActive = false;
            playerStatsController.DeactivateBooster();
        }

        private void SpawnBooster()
        {
            Transform booster = boosterPool.GetNextItem();

            booster.GetComponent<Booster>().Activate();
            //Используем Range вместо UnitCircle что бы избежать спавна в игроке
            Vector2 randomPosition = new Vector2(Random.Range(0.1f, 1), Random.Range(0.1f, 1));
            booster.transform.position = randomPosition * circleRadius; 
        }
    }
}