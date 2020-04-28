using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTask : Task
{
    private NavMeshAgent navAgent;
    private Animator anim;
    private Vector3 destination;
    public ChaseTask(TaskManager taskManager, Animator anim, NavMeshAgent navAgent, Vector3 destination) : base(taskManager)
    {
        this.navAgent = navAgent;
        this.anim = anim;
        this.destination = destination;
    }
    public override bool Start()
    {
        anim.SetBool("Aim", false);
        navAgent.isStopped = false;
        navAgent.speed = 5;
        navAgent.SetDestination(destination);
        return true;
    }
    public override bool End()
    {
        return true;
    }
}
