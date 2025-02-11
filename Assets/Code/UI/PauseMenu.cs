using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] Slider volumeSlider;
        [SerializeField] Button resumeButton;
        [SerializeField] Button BackToMenuButton;

        Action hideBackground;

        private void Start()
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            resumeButton.onClick.AddListener(Resume);
            BackToMenuButton.onClick.AddListener(BackToMenu);
        }

        public void OpenPause(Action hideBackground)
        {
            this .hideBackground = hideBackground;
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void Resume()
        {
            hideBackground?.Invoke();    
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }


        private void ChangeVolume(float volune)
        {

        }

        private void BackToMenu()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}