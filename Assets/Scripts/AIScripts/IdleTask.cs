using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleTask : Task
{
    private Animator anim;
    private NavMeshAgent navAgent;
    public IdleTask(TaskManager taskManager, Animator anim, NavMeshAgent navAgent) : base(taskManager)
    {
        this.anim = anim;
        this.navAgent = navAgent;
    }
    public override bool Start()
    {
        navAgent.ResetPath();
        anim.SetBool("Hurt", false);
        anim.SetBool("Aim", false);
        anim.SetBool("Fire", false);
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        TaskManager.StartCoroutine(BeingIdle());
        return true;
    }
    IEnumerator BeingIdle()
    {
        yield return new WaitForSeconds(1);
        IsTaskComplete = true;
        TaskManager.OnTaskCompleted(this);
    }
    public override bool End()
    {
        return IsTaskComplete;
    }
}
