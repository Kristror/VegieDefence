using Assets.Code.Enemy;
using UnityEngine;

namespace Assets.Code.Score
{
    public class ScoreController
    {
        private static long playerScore;

        float timeOfPoint;

        public static long PLayerScore => playerScore;

        public ScoreController()
        {
            EnemyUnit.onEnemyDeath += KilledEnemy;
            timeOfPoint = 0;
        }

        public void KilledEnemy()
        {
            playerScore += 100;
        }

        public void FrameUpdate()
        {
            SecondPased();
        }

        private void SecondPased()
        {
            if (Time.time - timeOfPoint > 1)
            {
                timeOfPoint = Time.time;

                playerScore += 2;
            }
        }
    }
}