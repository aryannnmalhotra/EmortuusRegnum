using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolTask : Task
{
    private Animator anim;
    private NavMeshAgent navAgent;
    private Vector3 patrolPoint;
    private float idleTime;
    public PatrolTask(TaskManager taskManager, Animator anim, NavMeshAgent navAgent, Vector3 patrolPoint) : base(taskManager)
    {
        this.anim = anim;
        this.navAgent = navAgent;
        this.patrolPoint = patrolPoint;
        idleTime = Random.Range(0.5f, 2);
    }
    public  override bool Start()
    {
        TaskManager.StartCoroutine(StartPatrol());
        return true;
    }
    IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(idleTime);
        navAgent.SetDestination(patrolPoint);
    }
    public override bool End()
    {
        return true;
    }
}
