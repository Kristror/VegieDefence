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

        public BoosterController(GameObject booster)
        {
            lastSpawn = 0;
            boosterPool = new BoosterPool(boosterPoolLenght, booster);
        }

        public void FrameUpdate()
        {
            if(Time.time - lastSpawn >= timeToSpawn)
            {
                lastSpawn = Time.time;
                SpawnBooster();
            }
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