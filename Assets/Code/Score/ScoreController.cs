using Assets.Code.Enemy;
using System;
using UnityEngine;

namespace Assets.Code.Score
{
    public class ScoreController : MonoBehaviour
    {
        private long playerScore;

        public Action onEnemyDeath;

        float timeOfPoint;

        public long PLayerScore => playerScore;

        public void Start()
        {
            EnemyUnit.onEnemyDeath += KilledEnemy;
            timeOfPoint = 0;
        }

        public void KilledEnemy()
        {
            playerScore += 100;
        }

        public void FixedUpdate()
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