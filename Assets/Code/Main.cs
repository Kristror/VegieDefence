using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;
using Assets.Code.Score;

namespace Assets.Code
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemyStats enemyStats;

        private PlayerController playerController;
        private EnemyController enemyController;
        private ScoreController scoreController;

        public void StartGame()
        {
            this.gameObject.SetActive(true);

            playerController = new PlayerController(playerPrefab, playerStats);

            enemyController = new EnemyController(enemyPrefab,enemyStats);

            scoreController = new ScoreController();
        }

        void Update()
        {
            playerController.FrameUpdate();
            enemyController.FrameUpdate();
            scoreController.FrameUpdate();
        }
    }
}