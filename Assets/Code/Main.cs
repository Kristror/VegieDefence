using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;
using Assets.Code.Boosters;
using Assets.Code.Score;
using System;

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

        public void StartGame(Action Subscribe)
        {
            this.gameObject.SetActive(true);

            playerController = new PlayerController(playerPrefab, playerStats);

            enemyController = new EnemyController(enemyPrefab,enemyStats);

            boosterController = new BoosterController(boosterPrefab);

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