using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Code.Player
{
    public class PlayerController 
    {
        private ClasesEnum playerClass;

        public  PlayerStatsController  playerStatsController;
        private PlayerMovement playerMovment;
        private PlayerShooting playerShooting;


        public PlayerController(GameObject playerPrefab, PlayerStats playerStats)
        {
            GameObject playerObject = GameObject.Instantiate(playerPrefab);

            playerStatsController = playerObject.GetComponent<PlayerStatsController>();
            playerMovment = playerObject.GetComponent<PlayerMovement>();
            playerShooting = playerObject.GetComponent<PlayerShooting>();

            playerClass = 0; //Дальше получать инфорацию о классе в интерфейсе выбора класса
            playerStatsController.SetClass(playerClass);
        }

        public void FrameUpdate() 
        {
            playerMovment.FrameUpdate();
            playerShooting.FrameUpdate();
        }  
    }
}