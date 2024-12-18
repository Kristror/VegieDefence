using Assets.Code.Player;
using System;
using UnityEngine;

namespace Assets.Code.UI
{
    public class InGameUIController : MonoBehaviour
    {
        [SerializeField] MainMenu mainMenu;
        [SerializeField] SettingsMenu settingsMenu;
        [SerializeField] DeathScreen deathScreen;
        [SerializeField] PauseMenu pauseMenu;

        [SerializeField] GameObject background;

        public void Start()
        {
            PlayerStatsController.PlayerDeath += ShowDeathScreen;
            PauseController.ActivatePause += ShowPause;

            ShowBackground();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            mainMenu.OpenMainMenu(ShowSettings, HideBackground);
        }

        public void ShowSettings()
        {
            settingsMenu.OpenSettingsMenu(ShowMainMenu);
        }

        public void ShowDeathScreen()
        {
            ShowBackground();
            deathScreen.PlayerDeath(); 
        }

        public void ShowPause()
        {
            ShowBackground();
            pauseMenu.OpenPause();
        }

        private void ShowBackground()
        {
            background.SetActive(true);
        }
        
        private void HideBackground()
        {
            background.SetActive(false);
        }
        
    }
}