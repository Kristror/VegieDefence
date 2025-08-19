using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;
using Assets.Code.Boosters;
using Assets.Code.Score;
using Assets.Code.PlayerUpgrades;
using System;
using Assets.Code.DangerLevels;

namespace Assets.Code
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemyStats enemyStats;
        [SerializeField] private GameObject boosterPrefab;
        [SerializeField] private ScoreController scoreController;

        private PlayerController playerController;
        private EnemyController enemyController;
        private BoosterController boosterController;

        private ClassesEnum playerClass;

        public ClassesEnum PlayerClass => playerClass;

        public void StartGame(Action Subscribe, ClassesEnum playerClass)
        {
            this.gameObject.SetActive(true);

            this.playerClass = playerClass;

            UpgradeController upgradeController = GetComponent<UpgradeController>();
            DangerLevelController dangerLevelController = GetComponent<DangerLevelController>();

            upgradeController.StartGame();

            playerController = new PlayerController(playerPrefab, playerStats, playerClass, upgradeController);

            enemyController = new EnemyController(enemyPrefab, enemyStats, dangerLevelController);

            boosterController = new BoosterController(boosterPrefab, playerController.playerStatsController);

            upgradeController.SetPlayerStatsController(playerController.playerStatsController);

            Subscribe.Invoke();
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