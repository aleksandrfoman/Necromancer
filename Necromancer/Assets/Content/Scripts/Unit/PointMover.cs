using System;
using System.Collections;
using System.Collections.Generic;
using Content.Scripts.Unit;
using UnityEditor;
using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> waypointList = new List<Transform>(1);
    [SerializeField] private Transform pointsParent;
    [SerializeField] private Transform enemiesParent;
    private Vector3 currentWaypoint;
    private int indexWaypoint;
    private bool isInit;
    private void Awake()
    {
        waypointList = InitMovePoints();
        indexWaypoint = 0;
        UpdateCurPos();
    }

    private void Update()
    {
        if (isInit && waypointList.Count >= 2)
        {
            if (CompletePath())
            {
                indexWaypoint = 0;
                UpdateCurPos();
                return;
            }
            if (IsNearPoint())
            {
                indexWaypoint++;
                UpdateCurPos();
            }
            Move();
            Rotate();
        }
    }

    private void UpdateCurPos()
    {
        currentWaypoint = waypointList[indexWaypoint].position;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            currentWaypoint,speed*Time.deltaTime);
    }
    
    private void Rotate()
    {
        Vector3 newTarget = new Vector3(currentWaypoint.x, currentWaypoint.y, currentWaypoint.z);
        var forwardDir = newTarget - transform.position;
        var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
        var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, speed * Time.deltaTime);
    }
    
    private bool IsNearPoint()
    {
        return (Vector3.Distance(transform.position, currentWaypoint)<=1f);
    }

    private bool CompletePath()
    {
        return (waypointList.Count - 1 == indexWaypoint && IsNearPoint());
    }
    public List<Transform> InitMovePoints()
    {
        int childrenCount = pointsParent.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            waypointList.Add(pointsParent.GetChild(i).transform);
        }
        pointsParent.parent = null;
        int enemiesCount = enemiesParent.childCount;
        for (int i = 0; i < enemiesCount; i++)
        {
            UnitBase enemy = enemiesParent.GetChild(i).GetComponent<UnitBase>();
           
            if (enemy != null)
            {
                enemy.UnitMovement.InitPointMove(this);
            }
        }
        enemiesParent.parent = null;
        isInit = true;
        return waypointList;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (isInit)
        {
            if (waypointList.Count >= 2)
            {
                for (int i = 0; i < waypointList.Count - 1; i++)
                {

                    Gizmos.DrawLine(waypointList[i].position, waypointList[i + 1].position);
                }
            }

            Gizmos.DrawLine(waypointList[0].position, waypointList[waypointList.Count - 1].position);
        }
    }
}
