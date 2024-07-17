using System;
using UnityEngine;
using UnityEngine.AI;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitMovement
    {
        public PointMover PointMover => pointMover;
        [SerializeField] private PointMover pointMover;
        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform meshRotator; 
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        private Vector3 target;

        public void InitPointMove(PointMover pointMover)
        {
            this.pointMover = pointMover;
        }
        public void EnableMovement(bool value)
        {
            rigidbody.isKinematic = !value;
        }

        public void EnableCollider(bool value)
        {
            collider.enabled = value;
        }

        public bool IsMove(float magn = 0.75f)
        { 
            return rigidbody.velocity.magnitude >= magn;
        }

        public void ResetVelocity()
        {
            rigidbody.velocity = Vector3.zero;
        }
        
        public void Move(float scale = 1.5f)
        {
            float velocityScaler = scale;
            rigidbody.velocity *= 1f - (velocityScaler * Time.deltaTime);
            rigidbody.angularVelocity *= 1f - (velocityScaler * Time.deltaTime);
            
            Vector3 targetDir = target - rigidbody.transform.position;
            rigidbody.AddForce(targetDir.normalized*speed*Time.deltaTime, ForceMode.Force);
        }
        
        
        public void Rotate()
        {
            Vector3 dir = target - meshRotator.position;
            dir = dir.normalized * 25f;
            var lookPoint = target + dir;
            var forwardDir = lookPoint - meshRotator.position;
            
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            meshRotator.rotation = Quaternion.Slerp(meshRotator.rotation, nextRot, rotateSpeed * Time.deltaTime);
        }
        
        public void Rotate(Vector3 dir)
        {
            dir = dir.normalized * 25f;
            var lookPoint = target + dir;
            var forwardDir = lookPoint - meshRotator.position;
            
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            meshRotator.rotation = Quaternion.Slerp(meshRotator.rotation, nextRot, rotateSpeed * Time.deltaTime);
        }
        
        public void RotateToTarget(Vector3 target)
        {
            Vector3 newTarget = new Vector3(target.x, target.y, target.z);
            var forwardDir = newTarget - meshRotator.position;
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            meshRotator.rotation = Quaternion.Lerp(meshRotator.rotation, nextRot, rotateSpeed * Time.deltaTime);
        }
        
        public void SetTarget(Vector3 pos)
        {
            target = pos;
        }
        
        public bool CheckDistanceToTarget(float value)
        {
            return Vector3.Distance(rigidbody.position,target) <= value;
        }
        
        public void Gravity()
        {
            rigidbody.AddForce(Physics.gravity * 75f * Time.deltaTime, ForceMode.Acceleration);
        }
        
        public bool IsVisible(Vector3 pos)
        {
            var targetPos = pos;
            targetPos.y = meshRotator.position.y;

            return Vector3.Angle(meshRotator.transform.forward, (targetPos - meshRotator.position).normalized) <= 1f;
        }
    }
}
