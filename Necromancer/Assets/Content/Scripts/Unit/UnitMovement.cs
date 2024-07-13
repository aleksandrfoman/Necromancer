using System;
using UnityEngine;
using UnityEngine.AI;
namespace Content.Scripts.Unit
{
    [Serializable]
    public class UnitMovement 
    {
        [SerializeField] private NavMeshAgent navNavMeshAgent;
        [SerializeField] private Vector3 target;
        private Transform transform;
     
    
        public void Init(Transform transform)
        {
            this.transform = transform;
        }
    
        public void SetTarget(Vector3 target)
        {
            this.target = target;
            navNavMeshAgent.SetDestination(this.target);
        }
    
        public void EnableStop(bool value)
        {
            navNavMeshAgent.isStopped = value;
        }
    
        public bool CheckDistanceToTarget()
        {
            return Vector3.Distance(transform.position,target) <= navNavMeshAgent.stoppingDistance;
        }
        
        public bool CheckDistanceToTarget(float value)
        {
            return Vector3.Distance(transform.position,target) <= value;
        }
    
        public void RotateToTarget(Vector3 target)
        {
            Vector3 newTarget = new Vector3(target.x, target.y, target.z);
            var forwardDir = newTarget - transform.position;
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, navNavMeshAgent.angularSpeed * Time.deltaTime);
        }
        
        public bool IsVisible(Vector3 pos)
        {
            var targetPos = pos;
            targetPos.y = transform.position.y;

            return Vector3.Angle(transform.forward, (targetPos - transform.position).normalized) <= 1f;
        }
    
        public bool IsVisible(Vector3 pos, float value)
        {
            var targetPos = pos;
            targetPos.y = transform.position.y;

            return Vector3.Angle(transform.forward, (targetPos - transform.position).normalized) <= value;
        }
    
        public bool CanBuildPath(Vector3 point)
        {
            var path = new NavMeshPath();
            navNavMeshAgent.CalculatePath(point, path);
            return path.status == NavMeshPathStatus.PathComplete;
        }
        public bool CheckNavMeshPoint(Vector3 point)
        {
            var hit = HitOnNavMesh(point);
            return hit.hit;
        }
        public NavMeshHit HitOnNavMesh(Vector3 point, float maxDistance = 4f)
        {
            NavMesh.SamplePosition(point, out NavMeshHit hit, maxDistance, 1 << NavMesh.GetAreaFromName("Walkable"));
            return hit;
        }
    }
}
