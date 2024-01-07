// Copyright (C) by Khoruz Studio

using _GameScripts.Enviro.Entity;
using _GameScripts.General.Input;
using UnityEngine;

namespace _GameScripts.Player
{
    public class PlayerController: MonoBehaviour
    {
        [SerializeField] private PlayerInputReceiver _playerInputReceiver;
        [SerializeField] private float _movementSpeed;

        private IInteractable _interactable;

        private Vector2 _moveDirection;
        private Vector2 _cameraDelta;

        private Rigidbody2D _rg;

        private void Start()
        {
            _rg = GetComponent<Rigidbody2D>();
            
            _playerInputReceiver.EventMove += HandleMoveEvent;
            _playerInputReceiver.EventLook += HandleLookEvent;
            _playerInputReceiver.EventInteractionStarted += HandleInteractionStarted;
            _playerInputReceiver.EventInteractionFinished += HandleInteractionFinished;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rg.velocity = _moveDirection * _movementSpeed;
        }

        private void Interact()
        {
            _interactable?.Interact();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IInteractable>(out var val)) _interactable = val;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<IInteractable>(out var val)) _interactable = null;
        }

        private void HandleMoveEvent(Vector2 value)
        {
            _moveDirection = value;
        }
        
        private void HandleLookEvent(Vector2 value)
        {
            _cameraDelta = value;
        }

        private void HandleInteractionStarted()
        {
            Interact();
        }
        
        private void HandleInteractionFinished()
        {
            Debug.Log("Interaction finished!");
        }
    }
}