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
        private Action ShowInGameUI;
        private Action Subscribe;

        private void Start()
        {
            startGame.onClick.AddListener(GameStart);
            settings.onClick.AddListener(OpenSettings);
            quit.onClick.AddListener(CloseGame);
        }

        public void OpenMainMenu(Action settings, Action showInGameUI, Action subscribe)
        {
            OpenSettingsAction = settings;
            ShowInGameUI = showInGameUI;
            Subscribe = subscribe;

            this.gameObject.SetActive(true);
        }

        private void GameStart()
        {
            mainObject.StartGame(Subscribe);
            ShowInGameUI?.Invoke();
            this.gameObject.SetActive(false);
        }

        private void OpenSettings()
        {
            this.gameObject.SetActive(false);
            OpenSettingsAction?.Invoke();
        }        

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}