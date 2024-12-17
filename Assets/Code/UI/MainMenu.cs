using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button startGame;
        [SerializeField] Button settings;
        [SerializeField] Button quit;

        [SerializeField] Main mainObject;

        private Action OpenSettingsAction;
        private Action CloseBackground;

        private void Start()
        {
            startGame.onClick.AddListener(GameStart);
            settings.onClick.AddListener(OpenSettings);
            quit.onClick.AddListener(CloseGame);
        }

        private void GameStart()
        {
            mainObject.StartGame();
            CloseBackground.Invoke();
            this.gameObject.SetActive(false);
        }

        private void OpenSettings()
        {
            this.gameObject.SetActive(false);
            OpenSettingsAction.Invoke();
        }

        public void OpenMainMenu(Action settings, Action closeBackground)
        {
            OpenSettingsAction = settings;
            CloseBackground = closeBackground;

            this.gameObject.SetActive(true);
        }

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}