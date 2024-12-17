using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button startGame;
        [SerializeField] Button settings;
        [SerializeField] Button quit;

        [SerializeField] SettingsMenu settingsMenu;
        [SerializeField] Main mainObject;

        private void Start()
        {
            startGame.onClick.AddListener(GameStart);
            settings.onClick.AddListener(OpenSettings);
            quit.onClick.AddListener(CloseGame);
        }

        private void GameStart()
        {
            mainObject.StartGame(); 
            this.gameObject.SetActive(false);
        }

        private void OpenSettings()
        {
            settingsMenu.OpenSettingsMenu();
            this.gameObject.SetActive(false);
        }
        public void OpenMainMenu()
        {
            this.gameObject.SetActive(true);
        }

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}