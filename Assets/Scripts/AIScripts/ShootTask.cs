using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTask : Task
{
    private Animator anim;
    private Vector3 bulletOrigin;
    private Vector3 target;
    private ParticleSystem flash;
    private ParticleSystem smoke1;
    private ParticleSystem smoke2;
    private float aimTime;
    public ShootTask(TaskManager taskManager, Animator anim, Vector3 bulletOrigin, Vector3 target, ParticleSystem flash, ParticleSystem smoke1, ParticleSystem smoke2) : base(taskManager)
    {
        this.anim = anim;
        this.bulletOrigin = bulletOrigin;
        this.target = target;
        this.flash = flash;
        this.smoke1 = smoke1;
        this.smoke2 = smoke2;
        aimTime = Random.Range(1.5f, 2);
    }
    public override bool Start()
    {
        /*Vector3 direction = (TaskManager.gameObject.transform.position - target).normalized;
        Quaternion directionalRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        TaskManager.gameObject.transform.rotation = Quaternion.Slerp(TaskManager.gameObject.transform.rotation, directionalRotaion, 5);*/
        anim.SetBool("Aim", true);
        TaskManager.StartCoroutine(StartShooting());
        return true;
    }
    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(aimTime);
        RaycastHit shot;
        anim.SetBool("Aim", false);
        anim.SetBool("Fire", true);
        flash.Play();
        smoke1.Play();
        smoke2.Play();
        if (Physics.Raycast(bulletOrigin, (bulletOrigin - target).normalized, out shot, 10))
        {
            if (shot.transform.GetComponent<FpsMovement>() != null)
                Debug.Log("Hit");
        }
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Fire", false);
        TaskManager.HasTakenPreviousShot = true;
    }
    public override bool End()
    {
        return true;
    }
}
