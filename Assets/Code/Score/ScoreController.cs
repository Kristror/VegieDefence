using Assets.Code.Enemy;
using Assets.Code.UI;
using System;
using UnityEngine;

namespace Assets.Code.Score
{
    public class ScoreController
    {
        private static long playerScore;

        float timeOfPoint;

        public static long PLayerScore => playerScore;

        public static Action ScoreUpdated;

        public ScoreController()
        {
            EnemyUnit.onEnemyKilled += KilledEnemy;
            DeathScreen.PlayerRevive += Revived;
            timeOfPoint = 0;
        }

        /// <summary>
        /// Увеличивает счет игрока на 10%
        /// </summary>
        public static void Booster()
        {
            playerScore += ((long)(playerScore * 0.1)); 
        }

        public void KilledEnemy()
        {
            playerScore += 20;
            UpdateUI();
        }

        private void Revived()
        {
            playerScore = playerScore - (playerScore / 4);
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

                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            ScoreUpdated?.Invoke();
        }
    }
}