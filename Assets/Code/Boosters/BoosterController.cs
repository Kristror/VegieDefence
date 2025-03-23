using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Boosters
{
    public class BoosterController
    {
        private const float timeToSpawn = 2;
        private float lastSpawn;

        private BoosterPool boosterPool;
        private const int boosterPoolLenght = 10;

        private const int circleRadius = 5;

        private bool isShootingBoosterActive;
        private const float durationSotingBooster = 15;
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