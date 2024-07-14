using System;
using Content.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Content.Scripts.Trigger
{
    [RequireComponent(typeof(BoxCollider))]
    public class InputTrigger : MonoBehaviour
    {
        public event Action<Player> OnInputTriggerStay;
        public event Action OnInputTriggerEnter;
        public event Action OnInputTriggerExit;
        
        [SerializeField] private bool isScaleTrigger;
        [SerializeField] private bool isDirectionalTrigger;
        [SerializeField] private float detectionAngle = 60f;
        [SerializeField] private Mesh arrowMesh;
        [SerializeField] private BoxCollider triggerCollider;
        private bool _isInTrigger;
        private Player _curPlayer;

        public void EnableTrigger(bool value)
        {
            gameObject.SetActive(value);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (isDirectionalTrigger)
            {
                if (player != null)
                {
                    if (Vector3.Angle(player.PlayerMovement.Forward, transform.forward) < detectionAngle)
                    {
                        _isInTrigger = true;
                        _curPlayer = player;
                        ScaleCollider();
                        OnInputTriggerEnter?.Invoke();
                    }
                }
            }
            else
            {
                if (player!=null)
                {
                    _isInTrigger = true;
                    _curPlayer = player;
                    ScaleCollider();
                    OnInputTriggerEnter?.Invoke();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.GetComponent<Player>();
        
            if (player!=null)
            {
                _isInTrigger = false;
                _curPlayer = null;
                ResetCollier();
                OnInputTriggerExit?.Invoke();
            }
        }

        private void ScaleCollider()
        {
            if(isScaleTrigger)
              triggerCollider.size = Vector3.one * 2f;
        }

        private void ResetCollier()
        {
            if(isScaleTrigger)
              triggerCollider.size = Vector3.one;
        }

        private void Update()
        {
            if (_isInTrigger)
            {
                OnInputTriggerStay?.Invoke(_curPlayer);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (isDirectionalTrigger)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawMesh(arrowMesh, transform.position, Quaternion.Euler(Vector3.right * 90), Vector3.one*0.1f);
            }
        }
    }
}
