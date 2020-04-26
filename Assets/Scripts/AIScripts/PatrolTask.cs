using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolTask : Task
{
    private NavMeshAgent navAgent;
    private Vector3 patrolPoint;
    private float idleTime;
    public PatrolTask(TaskManager taskManager, NavMeshAgent navAgent, Vector3 patrolPoint) : base(taskManager)
    {
        this.navAgent = navAgent;
        this.patrolPoint = patrolPoint;
        idleTime = Random.Range(0.5f, 2);
    }
    public  override bool Start()
    {
        navAgent.isStopped = false;
        navAgent.speed = 1;
        TaskManager.StartCoroutine(StartPatrol());
        return true;
    }
    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(idleTime);
        Vector3 direction = (patrolPoint - navAgent.gameObject.transform.position).normalized;
        Quaternion directionalRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        navAgent.gameObject.transform.rotation = Quaternion.Slerp(navAgent.gameObject.transform.rotation, directionalRotaion, Time.deltaTime * 3);
        navAgent.SetDestination(patrolPoint);
    }
    public override bool End()
    {
        return true;
    }
}
