// Copyright (C) by Khoruz Studio

using _GameScripts.Enviro.Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GameScripts.Enviro.Entity.Object
{
    public class TeleportInteractable: MonoBehaviour, IInteractable
    {
        [FormerlySerializedAs("_generalManager")] [SerializeField] private EnviroGeneralManager _enviroGeneralManager;
        
        public void Interact()
        {
            _enviroGeneralManager.StartBattle();
        }
    }
}