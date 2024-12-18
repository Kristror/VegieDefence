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


        private void Start()
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            resumeButton.onClick.AddListener(Resume);
            BackToMenuButton.onClick.AddListener(BackToMenu);
        }

        public void OpenPause()
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void Resume()
        {
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