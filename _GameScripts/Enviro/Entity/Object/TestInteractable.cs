using DG.Tweening;
using UnityEngine;

namespace _GameScripts.Enviro.Entity.Object
{
    public class TestInteractable: MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            transform.DOPunchPosition(new Vector3(0f, 1f), 0.5f, 5, 1f);
        }
    }
}