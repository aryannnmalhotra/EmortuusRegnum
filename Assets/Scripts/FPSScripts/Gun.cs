using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool isReloading;
    private int currentAmmo;
    private float currentFireStamp;
    private Animator anim;
    public int AmmoPerRound = 5;
    public int ExtraRounds = 0;
    public float ReloadTime = 2.5f;
    public float Damage = 10;
    public float Range = 30;
    public float ShotForce = 10;
    public float FireRate = 5;
    public Camera FpsCam;
    public GameObject OnShot;
    public ParticleSystem Flash;
    public ParticleSystem Smoke1;
    public ParticleSystem Smoke2;
    void Start()
    {
        isReloading = false;
        currentFireStamp = 0;
        currentAmmo = AmmoPerRound;
    }
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        isReloading = false;
        anim.SetBool("Reload", false);
    }
    void Shoot()
    {
        RaycastHit shot;
        if(Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out shot, Range))
        {
            Flash.Play();
            Smoke1.Play();
            Smoke2.Play();
            Enemy shotEnem = shot.transform.GetComponent<Enemy>();
            if (shotEnem != null)
            {
                shotEnem.DamageInflicted(Damage);
            }
            if (shot.rigidbody != null)
                shot.rigidbody.AddForce(-shot.normal * ShotForce);
            Instantiate(OnShot, shot.point, Quaternion.LookRotation(shot.normal));
            currentAmmo--;
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("Reload", true);
        yield return new WaitForSeconds(ReloadTime - 0.25f);
        anim.SetBool("Reload", false);
        yield return new WaitForSeconds(0.25f);
        ExtraRounds--;
        currentAmmo = AmmoPerRound;
        isReloading = false;
    }
    void Update()
    {
        if (isReloading)
            return;
        if(currentAmmo <= 0)
        {
            if (ExtraRounds > 0)
                StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.C) && Time.time >= currentFireStamp)
        {
            currentFireStamp = Time.time + 1 / FireRate;
            Shoot();
        }
    }
}
