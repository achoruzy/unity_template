// Copyright (C) by Khoruz Studio

using System;
using _GameScripts.Core;
using _GameScripts.General.Input;
using UnityEngine;

namespace _GameScripts.Battle.Managers
{
    public class BattleGeneralManager: MonoBehaviour
    {
        [SerializeField] private PlayerInputReceiver _playerInputReceiver;
        [SerializeField] private UIInputReceiver _uiInputReceiver;
        [SerializeField] private Scenes _scenes;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _battleUI;
        
        public event Action ExitScene;

        private void Start()
        {
            _uiInputReceiver.EventPauseMenu += HandlePauseMenu;
            ShowBattleMenu();
            
            _playerInputReceiver.SetReceiverActive(false);
            _uiInputReceiver.SetReceiverActive(true);
            
            ExitScene += ClearReceivers;
        }

        private void HandlePauseMenu()
        {
            _battleUI.SetActive(!_battleUI.activeSelf);
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        }
        
        private void ShowBattleMenu()
        {
            _battleUI.SetActive(true);
        }
        
        public void ExitToMainMenu()
        {
            ExitScene?.Invoke();
            _scenes.LoadMainMenu();
        }

        public void EndBattle()
        {
            ExitScene?.Invoke();
            _scenes.LoadHub();
        }
        
        private void ClearReceivers()
        {
            _uiInputReceiver.EventPauseMenu -= HandlePauseMenu;
            
            _playerInputReceiver.SetReceiverActive(false);
            _uiInputReceiver.SetReceiverActive(false);
        }
    }
}