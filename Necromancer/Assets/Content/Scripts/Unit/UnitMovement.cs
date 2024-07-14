using System;
using UnityEngine;
using UnityEngine.AI;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitMovement
    {
        public bool IsMove => rigidbody.velocity.magnitude >= 0.75f;

        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform meshRotator;
        [SerializeField] private Vector3 target;
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;


        public void EnableMovement(bool value)
        {
            rigidbody.isKinematic = true;
        }

        public void EnableCollider(bool value)
        {
            collider.enabled = value;
        }
        
        public void Move()
        {
            float velocitySclaer = 1.5f;
            rigidbody.velocity *= 1f - (velocitySclaer * Time.deltaTime);
            rigidbody.angularVelocity *= 1f - (velocitySclaer * Time.deltaTime);
            
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

        #region NavMesh
        //
        // [SerializeField] private NavMeshAgent navNavMeshAgent;
        //
        //
        //
        //
        // public void SetTarget(Vector3 target)
        // {
        //     this.target = target;
        //     navNavMeshAgent.SetDestination(this.target);
        // }
        //
        // public void EnableStop(bool value)
        // {
        //     navNavMeshAgent.isStopped = value;
        // }
        //
        // public bool CheckDistanceToTarget()
        // {
        //     return Vector3.Distance(transform.position,target) <= navNavMeshAgent.stoppingDistance;
        // }
        //
        // public bool CheckDistanceToTarget(float value)
        // {
        //     return Vector3.Distance(transform.position,target) <= value;
        // }
        //
        // public void RotateToTarget(Vector3 target)
        // {
        //     Vector3 newTarget = new Vector3(target.x, target.y, target.z);
        //     var forwardDir = newTarget - transform.position;
        //     var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
        //     var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
        //     transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, navNavMeshAgent.angularSpeed * Time.deltaTime);
        // }
        //
        // public bool IsVisible(Vector3 pos)
        // {
        //     var targetPos = pos;
        //     targetPos.y = transform.position.y;
        //
        //     return Vector3.Angle(transform.forward, (targetPos - transform.position).normalized) <= 1f;
        // }
        //
        // public bool IsVisible(Vector3 pos, float value)
        // {
        //     var targetPos = pos;
        //     targetPos.y = transform.position.y;
        //
        //     return Vector3.Angle(transform.forward, (targetPos - transform.position).normalized) <= value;
        // }
        //
        // public bool CanBuildPath(Vector3 point)
        // {
        //     var path = new NavMeshPath();
        //     navNavMeshAgent.CalculatePath(point, path);
        //     return path.status == NavMeshPathStatus.PathComplete;
        // }
        // public bool CheckNavMeshPoint(Vector3 point)
        // {
        //     var hit = HitOnNavMesh(point);
        //     return hit.hit;
        // }
        // public NavMeshHit HitOnNavMesh(Vector3 point, float maxDistance = 4f)
        // {
        //     NavMesh.SamplePosition(point, out NavMeshHit hit, maxDistance, 1 << NavMesh.GetAreaFromName("Walkable"));
        //     return hit;
        // }

        #endregion
    }
}
