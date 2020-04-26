using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTask : Task
{
    private NavMeshAgent navAgent;
    private Vector3 destination;
    public ChaseTask(TaskManager taskManager, NavMeshAgent navAgent, Vector3 destination) : base(taskManager)
    {
        this.navAgent = navAgent;
        this.destination = destination;
    }
    public override bool Start()
    {
        navAgent.isStopped = false;
        navAgent.speed = 4;
        /*Vector3 direction = (destination - navAgent.gameObject.transform.position).normalized;
        Quaternion directionalRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        navAgent.gameObject.transform.rotation = Quaternion.Slerp(navAgent.gameObject.transform.rotation, directionalRotaion, 4);*/
        navAgent.SetDestination(destination);
        return true;
    }
    public override bool End()
    {
        return true;
    }
}
