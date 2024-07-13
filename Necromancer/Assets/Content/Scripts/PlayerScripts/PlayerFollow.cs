using System;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerFollow
    {
        [SerializeField] private Transform followPoint;
        private Transform transform;
        private Vector3 followPos;
        private float lerpSpeed = 5f;
        
        public void Init(Transform transform)
        {
            followPoint.parent = transform;
            this.transform = transform;
        }
        
        public void UpdatePointMove()
        {
            // followPos.x = Input.GetAxisRaw("Horizontal")f;
            // followPos.y = Input.GetAxisRaw("Vertical");
            followPoint.localPosition = Vector3.Lerp(followPoint.localPosition, followPos,lerpSpeed*Time.deltaTime);
        }
        
        public void UpdatePointAim(Vector3 target)
        {
            Vector3 avrPoint = Vector3.Lerp(transform.position, target, 0.5f);
            followPoint.position = Vector3.Lerp(followPoint.position, avrPoint,lerpSpeed*Time.deltaTime);
        }

        private Vector3 GetFollowPos(Vector3 direction)
        {
            if (direction.z < 0)
            {
                direction.z = 0f;
            }
            return direction;
        }

        public void Destroy()
        {
            followPoint.parent = null;
        }
    }
}