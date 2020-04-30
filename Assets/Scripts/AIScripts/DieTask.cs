using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTask : Task
{
    Animator anim;
    private GameObject dieEffect;
    private GameObject cashDrop;
    public DieTask(TaskManager taskManager, Animator anim, GameObject dieEffect, GameObject cashDrop) : base(taskManager)
    {
        this.anim = anim;
        this.dieEffect = dieEffect;
        this.cashDrop = cashDrop;
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
        yield return new WaitForSeconds(3.5f);
        TaskManager.Instantiate(dieEffect, TaskManager.gameObject.transform.position, Quaternion.LookRotation(Vector3.up));
        yield return new WaitForSeconds(1.4f);
        var go = TaskManager.Instantiate(cashDrop) as GameObject;
        go.transform.position = new Vector3(TaskManager.gameObject.transform.position.x, TaskManager.gameObject.transform.position.y + 1, TaskManager.gameObject.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        TaskManager.Destroy(TaskManager.gameObject);
    }

    public override bool End()
    {
        return false;
    }
}
