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
        [SerializeField] ScoreUI scoreUI;


        [SerializeField] GameObject background;

        private void Start()
        {
            PlayerStatsController.PlayerDeath += ShowDeathScreen;
            PauseController.ActivatePause += ShowPause;

            ShowBackground();
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            mainMenu.OpenMainMenu(ShowSettings, ShowInGameUI);
        }

        private void ShowSettings()
        {
            settingsMenu.OpenSettingsMenu(ShowMainMenu);
        }

        private void ShowDeathScreen()
        {
            ShowBackground();
            HideInGameUI();
            deathScreen.PlayerDeath(ShowInGameUI); 
        }

        private void ShowPause()
        {
            ShowBackground();
            pauseMenu.OpenPause(HideBackground);
        }

        private void ShowInGameUI() 
        {
            HideBackground();
            scoreUI.Activate();
        }
        private void HideInGameUI() 
        {
            scoreUI.gameObject.SetActive(false);
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