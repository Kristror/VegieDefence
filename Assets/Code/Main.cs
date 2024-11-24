using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;

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

        public void Start()
        {
            playerController = new PlayerController(playerPrefab, playerStats);

            enemyController = new EnemyController(enemyPrefab,enemyStats);
        }
        void Update()
        {
            playerController.FrameUpdate();
            enemyController.FrameUpdate();
        }
    }
}