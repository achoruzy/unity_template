// Copyright (C) by Khoruz Studio

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GameScripts.General.Input
{
    [CreateAssetMenu(fileName = "InputReceiver", menuName = "Game/Input/PlayerInputReceiver")]
    public class PlayerInputReceiver: ScriptableObject, InputActions.IPlayerActions
    {
        private InputActions _input;
        private InputActions.PlayerActions _receiver;

        public bool IsActive => _input.Player.enabled;

        public event Action<Vector2> EventMove;
        public event Action<Vector2> EventLook;
        public event Action EventInteractionStarted;
        public event Action EventInteractionFinished;
        public event Action EventPlayerMenu;
        public event Action EventPauseMenu;

        private void OnEnable()
        {
            if (_input == null) _input = new InputActions();
            _receiver = _input.Player;
            SetReceiverActive(true);
            _receiver.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _receiver.RemoveCallbacks(this);
            SetReceiverActive(false);
        }

        public void SetReceiverActive(bool isActive)
        {
            if (isActive) _receiver.Enable();
            else _receiver.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            EventMove?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            EventLook?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started) EventInteractionStarted?.Invoke();
            else if (context.canceled) EventInteractionFinished?.Invoke();
        }

        public void OnPlayerMenu(InputAction.CallbackContext context)
        {
            if (context.started) EventPlayerMenu?.Invoke();
        }

        public void OnPauseMenu(InputAction.CallbackContext context)
        {
            if (context.started) EventPauseMenu?.Invoke();
        }
    }
}