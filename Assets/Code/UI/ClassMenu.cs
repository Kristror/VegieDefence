using Assets.Code.Player;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class ClassMenu : MonoBehaviour
    {
        [SerializeField] private Button onionButton; 
        [SerializeField] private Button potatoButton; 
        [SerializeField] private Button pumpkinButton;

        [SerializeField] private Button startGameButton;
        [SerializeField] private Button backToMenuButton;

        [SerializeField] private Text onionRecordText;
        [SerializeField] private Text potatoRecordText;
        [SerializeField] private Text pumpkinRecordText;

        [SerializeField] Main mainObject; //заполнить

        private Action OpenMenuAction;
        private Action ShowInGameUIAction;
        private Action SubscribeToDeathAction;

        private ClassesEnum playerClass;

        private void Start()
        {
            //получить рекорды игрока и поместить в текст
            // добавить описание классов

            onionButton.onClick.AddListener(SelectOnion);
            potatoButton.onClick.AddListener(SelectPotato);
            pumpkinButton.onClick.AddListener(SelectPumpkin);

            onionRecordText.text = "1";
            potatoRecordText.text = "2";
            pumpkinRecordText.text = "3";

            startGameButton.onClick.AddListener(StartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);
        }

        public void OpenClassMenu(Action BackToMenu, Action showInGameUI, Action subscribeToDeath)
        {
            OpenMenuAction = BackToMenu;
            ShowInGameUIAction = showInGameUI;
            SubscribeToDeathAction = subscribeToDeath;
        }

        private void SelectOnion()
        {
            playerClass = ClassesEnum.Onion;
        }

        private void SelectPotato()
        {
            playerClass = ClassesEnum.Potato;
        }

        private void SelectPumpkin()
        {
            playerClass = ClassesEnum.Pumpkin;
        }

        private void StartGame()
        {
            // передать класс в main
            mainObject.StartGame(SubscribeToDeathAction);
            ShowInGameUIAction?.Invoke();
            this.gameObject.SetActive(false);
        }

        private void BackToMenu()
        {
            OpenMenuAction.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}