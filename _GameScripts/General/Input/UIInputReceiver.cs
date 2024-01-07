// Copyright (C) by Khoruz Studio

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _GameScripts.General.Input
{
    [CreateAssetMenu(fileName = "InputReceiver", menuName = "Game/Input/UIInputReceiver")]
    public class UIInputReceiver: ScriptableObject, InputActions.IUIActions
    {
        private InputActions _input;
        private InputActions.UIActions _receiver;

        public bool IsActive => _receiver.enabled;
        
        public event Action<Vector2> EventNavigate;
        public event Action EventPlayerMenu;
        public event Action EventPauseMenu;
        public event Action EventSubmit;
        public event Action EventCancel;
        public event Action<Vector2> EventPoint;
        public event Action EventClick;

        private void OnEnable()
        {
            if (_input == null) _input = new InputActions();
            _receiver = _input.UI;
            SetReceiverActive(false);
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


        public void OnNavigate(InputAction.CallbackContext context)
        {
            EventNavigate?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPlayerMenu(InputAction.CallbackContext context)
        {
            if (context.started) EventPlayerMenu?.Invoke();
        }

        public void OnPauseMenu(InputAction.CallbackContext context)
        {
            if (context.started) EventPauseMenu?.Invoke();
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            EventSubmit?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            EventCancel?.Invoke();
        }

        public void OnPoint(InputAction.CallbackContext context)
        {
            EventPoint?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            EventClick?.Invoke();
        }
    }
}