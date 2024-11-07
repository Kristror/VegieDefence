using UnityEngine;
using Assets.Code.Player;
using Assets.Code.Enemy;

namespace Assets.Code
{
    public class Main : MonoBehaviour
    {
        public GameObject playerPrefab;

        private PlayerBase playerBase;
        private PlayerMovement playerMovment;
        private PlayerShooting playerShooting;

        public void Start()
        {
            GameObject playerObject = GameObject.Instantiate(playerPrefab);

            playerBase = playerObject.GetComponent<PlayerBase>();
            playerMovment = playerObject.GetComponent<PlayerMovement>();
            playerShooting = playerObject.GetComponent<PlayerShooting>();
        }
        void Update()
        {
            playerBase.FrameUpdate();
            playerMovment.FrameUpdate();
            playerShooting.FrameUpdate();
        }
    }
}