using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button classMenuButton; // заполнить
        [SerializeField] Button settingsButton;
        [SerializeField] Button quitButton;

        private Action OpenSettingsAction;
        private Action OpenClassMenuAction;

        private void Start()
        {
            classMenuButton.onClick.AddListener(OpenClassMenu);
            settingsButton.onClick.AddListener(OpenSettings);
            quitButton.onClick.AddListener(CloseGame);
        }

        public void OpenMainMenu(Action opentSettings, Action openClassMenu)
        {
            OpenSettingsAction = opentSettings;
            OpenSettingsAction = openClassMenu;

            this.gameObject.SetActive(true);
        }

        private void OpenClassMenu()
        {
            OpenSettingsAction?.Invoke();
            this.gameObject.SetActive(false);
        }

        private void OpenSettings()
        {
            OpenSettingsAction?.Invoke();
            this.gameObject.SetActive(false);
        }        

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}