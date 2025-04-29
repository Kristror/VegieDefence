using Assets.Code.Player;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Code.Score;

namespace Assets.Code.UI
{
    public class ClassMenu : MonoBehaviour
    {
        [SerializeField] private Button onionButton; 
        [SerializeField] private Button potatoButton; 
        [SerializeField] private Button pumpkinButton;

        [SerializeField] private Button startGameButton;
        [SerializeField] private Button backToMenuButton;

        [SerializeField] private TextMeshProUGUI recordText;
        [SerializeField] private TextMeshProUGUI descriptionText;

        [SerializeField] Main mainObject;
        [SerializeField] RecordController recordController;

        private Action OpenMenuAction;
        private Action ShowInGameUIAction;
        private Action SubscribeToDeathAction;

        private ClassesEnum playerClass;

        private string descr;
        private void Start()
        {
            onionButton.onClick.AddListener(SelectOnion);
            potatoButton.onClick.AddListener(SelectPotato);
            pumpkinButton.onClick.AddListener(SelectPumpkin);
            startGameButton.onClick.AddListener(StartGame);
            backToMenuButton.onClick.AddListener(BackToMenu);

            recordText.text = "";
            descriptionText.text = "";
        }

        public void OpenClassMenu(Action BackToMenu, Action showInGameUI, Action subscribeToDeath)
        {
            OpenMenuAction = BackToMenu;
            ShowInGameUIAction = showInGameUI;
            SubscribeToDeathAction = subscribeToDeath;
            this.gameObject.SetActive(true);
        }

        private void SelectOnion()
        {
            playerClass = ClassesEnum.Onion;
            ShowRecordAndDescription();
        }

        private void SelectPotato()
        {
            playerClass = ClassesEnum.Potato;
            ShowRecordAndDescription();
        }

        private void SelectPumpkin()
        {
            playerClass = ClassesEnum.Pumpkin;
            ShowRecordAndDescription();
        }


        private void ShowRecordAndDescription()
        {
            switch (playerClass)
            {
                case ClassesEnum.Potato:
                    recordText.text = "Record Score: " + recordController.PotatoRecordScore;
                    descriptionText.text = "potato Placeholder";
                    break;
                case ClassesEnum.Onion:
                    recordText.text = "Record Score: " + recordController.OnionRecordScore;
                    descriptionText.text = "onion Placeholder";
                    break;
                case ClassesEnum.Pumpkin:
                    recordText.text = "Record Score: " + recordController.PumpkinRecordScore;
                    descriptionText.text = "pumpkin Placeholder";
                    break;
            }
        }

        private void StartGame()
        {
            mainObject.StartGame(SubscribeToDeathAction, playerClass);
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