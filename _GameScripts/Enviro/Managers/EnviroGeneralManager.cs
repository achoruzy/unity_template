// Copyright (C) by Khoruz Studio

using System;
using _GameScripts.Core;
using _GameScripts.General.Input;
using UnityEngine;

namespace _GameScripts.Enviro.Managers
{
    public class EnviroGeneralManager: MonoBehaviour
    {
        [SerializeField] private PlayerInputReceiver _playerInputReceiver;
        [SerializeField] private UIInputReceiver _uiInputReceiver;
        [SerializeField] private Scenes _scenes;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _playerMenu;

        public event Action ExitScene;
        
        private void Start()
        {
            _playerInputReceiver.EventPauseMenu += HandlePauseMenu;
            _playerInputReceiver.EventPlayerMenu += HandlePlayerMenu;
            
            _uiInputReceiver.EventPauseMenu += HandlePauseMenu;
            _uiInputReceiver.EventPlayerMenu += HandlePlayerMenu;
            
            _playerInputReceiver.SetReceiverActive(true);
            _uiInputReceiver.SetReceiverActive(false);

            ExitScene += ClearReceivers;
        }

        private void HandlePauseMenu()
        {
            SwapReceivers();
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        }
        
        private void HandlePlayerMenu()
        {
            if (_pauseMenu.activeSelf) return;
            SwapReceivers();
            _playerMenu.SetActive(!_playerMenu.activeSelf);
        }

        private void SwapReceivers()
        {
            _playerInputReceiver.SetReceiverActive(!_playerInputReceiver.IsActive);
            _uiInputReceiver.SetReceiverActive(!_uiInputReceiver.IsActive);
        }

        public void ExitToMainMenu()
        {
            ExitScene?.Invoke();
            _scenes.LoadMainMenu();
        }

        public void StartBattle()
        {
            ExitScene?.Invoke();
            _scenes.LoadBattle();
        }

        private void ClearReceivers()
        {
            _playerInputReceiver.EventPauseMenu -= HandlePauseMenu;
            _playerInputReceiver.EventPlayerMenu -= HandlePlayerMenu;
            
            _uiInputReceiver.EventPauseMenu -= HandlePauseMenu;
            _uiInputReceiver.EventPlayerMenu -= HandlePlayerMenu;
            
            _playerInputReceiver.SetReceiverActive(false);
            _uiInputReceiver.SetReceiverActive(false);
        }
    }
}