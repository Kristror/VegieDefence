using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;
using Assets.Code.Boosters;
using Assets.Code.Score;

namespace Assets.Code
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemyStats enemyStats;
        [SerializeField] private GameObject boosterPrefab;

        private PlayerController playerController;
        private EnemyController enemyController;
        private BoosterController boosterController;
        private ScoreController scoreController;

        public void StartGame()
        {
            this.gameObject.SetActive(true);

            playerController = new PlayerController(playerPrefab, playerStats);

            enemyController = new EnemyController(enemyPrefab,enemyStats);

            boosterController = new BoosterController(boosterPrefab);

            scoreController = new ScoreController();
        }

        void Update()
        {   if (Time.timeScale != 0)
            {
                playerController.FrameUpdate();
                enemyController.FrameUpdate();
                boosterController.FrameUpdate();
                scoreController.FrameUpdate();
            }
        }
    }
}