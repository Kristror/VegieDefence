using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] Button closeMenu;
        [SerializeField] Slider volumeSlider;
        [SerializeField] Button saveProgress;
        [SerializeField] Button loadProgress;

        [SerializeField] Button changeLanguageRussian;
        [SerializeField] Button changeLanguageEnglish;

        [SerializeField] MainMenu mainMenu;

        private void Start()
        {
            closeMenu.onClick.AddListener(Close);
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            saveProgress.onClick.AddListener(SaveProgress);
            loadProgress.onClick.AddListener(LoadProgress);
            changeLanguageRussian.onClick.AddListener(ChangeLanguageRussian);
            changeLanguageEnglish.onClick.AddListener(ChangeLanguageEnglish);


            this.gameObject.SetActive(false);
        }

        public void OpenSettingsMenu()
        {
            this.gameObject.SetActive(true);
        }

        private void Close()
        {
            mainMenu.OpenMainMenu();
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