using UnityEngine;
using UnityEngine.UI;
using System;

namespace Assets.Code.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] Button closeMenuButton;
        [SerializeField] Slider volumeSlider;
        [SerializeField] Button saveProgressButton;
        [SerializeField] Button loadProgressButton;

        [SerializeField] Button changeLanguageRussianButton;
        [SerializeField] Button changeLanguageEnglishButton;


        private Action OpenMainMenu;

        private void Start()
        {
            closeMenuButton.onClick.AddListener(Close);
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            saveProgressButton.onClick.AddListener(SaveProgress);
            loadProgressButton.onClick.AddListener(LoadProgress);
            changeLanguageRussianButton.onClick.AddListener(ChangeLanguageRussian);
            changeLanguageEnglishButton.onClick.AddListener(ChangeLanguageEnglish);
        }

        public void OpenSettingsMenu(Action mainMenu)
        {
            OpenMainMenu = mainMenu; 
            this.gameObject.SetActive(true);
        }

        private void Close()
        {
            OpenMainMenu.Invoke();
            this.gameObject.SetActive(false);
        }

        private void ChangeVolume(float volune)
        {

        }

        private void SaveProgress()
        {

        } 
        private void LoadProgress()
        {

        }
        private void ChangeLanguageRussian()
        {

        } 
        private void ChangeLanguageEnglish()
        {

        }

    }
}