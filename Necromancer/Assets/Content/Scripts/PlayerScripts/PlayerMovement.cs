using System;
using UnityEngine;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerMovement
    {
        public Vector2 Direction => direction;
        public Vector3 Forward => rotateTransform.forward;
        
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform rotateTransform;
        [SerializeField] private float speed; 
        [SerializeField] private float rotateSpeed;
        private Vector2 direction;
        
        public void Movement()
        {
            Vector3 velocity = new Vector3(direction.x, 0f, direction.y) * speed;
            velocity.y = rigidbody.velocity.y;
            Vector3 worldVelocity = rigidbody.transform.TransformVector(velocity);
            rigidbody.velocity = worldVelocity;
        }

        public void EnableRb(bool value)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.isKinematic = !value;
        }
        public void Rotate()
        {
            if (direction != Vector2.zero)
            {
                var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
                rotateTransform.transform.rotation = Quaternion.Lerp(rotateTransform.transform.rotation, nextRot, rotateSpeed * Time.deltaTime);
            }
        }
        
        public void Rotate(Vector3 target)
        {
            Vector3 newTarget = new Vector3(target.x, target.y, target.z);
            var forwardDir = newTarget - rigidbody.position;
            Debug.DrawRay(rigidbody.position,forwardDir*10f,Color.white);
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            rotateTransform.rotation = Quaternion.Lerp(rotateTransform.rotation, nextRot, rotateSpeed * Time.deltaTime);
        }
        
        
        public bool IsVisible(Vector3 pos, float offset)
        {
            var targetPos = pos;
            targetPos.y = rotateTransform.position.y;

            return Vector3.Angle(rotateTransform.forward, (targetPos - rotateTransform.position).normalized) <= offset;
        }
        
        public bool IsVisible(Vector3 pos)
        {
            var targetPos = pos;
            targetPos.y = rotateTransform.position.y;

            return Vector3.Angle(rotateTransform.forward, (targetPos - rotateTransform.position).normalized) <= 0.1f;
        }
        

        public void MyInput()
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
    }
}