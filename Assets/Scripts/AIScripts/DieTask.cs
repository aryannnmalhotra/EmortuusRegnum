using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTask : Task
{
    Animator anim;
    public DieTask(TaskManager taskManager, Animator anim) : base(taskManager)
    {
        this.anim = anim;
    }
    public override bool Start()
    {
        anim.SetBool("Die", true);
        TaskManager.gameObject.GetComponent<BoxCollider>().enabled = false;
        TaskManager.StartCoroutine(SpawnCollectibles());
        return true;
    }
    IEnumerator SpawnCollectibles()
    {
        yield return new WaitForSeconds(4.9f);
        // spawn logic
        yield return new WaitForSeconds(0.1f);
        TaskManager.Destroy(TaskManager.gameObject);
    }

    public override bool End()
    {
        return false;
    }
}
