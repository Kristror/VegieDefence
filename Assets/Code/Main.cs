using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;

namespace Assets.Code
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemyStats enemyStats;

        private PlayerBase playerBase;
        private PlayerMovement playerMovment;
        private PlayerShooting playerShooting;
        private EnemyController enemyController;

        public void Start()
        {
            GameObject playerObject = GameObject.Instantiate(playerPrefab);

            playerBase = playerObject.GetComponent<PlayerBase>();
            playerMovment = playerObject.GetComponent<PlayerMovement>();
            playerShooting = playerObject.GetComponent<PlayerShooting>();

            enemyController = new EnemyController(enemyPrefab,enemyStats);
        }
        void Update()
        {
            playerBase.FrameUpdate();
            playerMovment.FrameUpdate();
            playerShooting.FrameUpdate();
            enemyController.FrameUpdate();
        }
    }
}