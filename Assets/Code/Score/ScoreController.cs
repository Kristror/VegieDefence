using Assets.Code.Enemy;
using Assets.Code.UI;
using System;
using UnityEngine;

namespace Assets.Code.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] DeathScreen deathScreen;
        private long playerScore = 0;

        public long PlayerScore => playerScore;

        float timeOfPoint;

        public static Action ScoreUpdated;

        public void Start()
        {
            deathScreen.PlayerRevive += Revived; 
            EnemyUnit.onEnemyKilled += KilledEnemy;
            timeOfPoint = 0;
            UpdateUI();
        }

        /// <summary>
        /// Увеличивает счет игрока на 10%
        /// </summary>
        public void Booster()
        {
            playerScore += ((long)(playerScore * 0.1));
            UpdateUI();
        }

        public void KilledEnemy()
        {
            playerScore += 20;
            UpdateUI();
        }

        private void Revived()
        {
            playerScore = playerScore - (playerScore / 4);
            UpdateUI();
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