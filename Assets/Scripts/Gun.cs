using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float currentFireStamp;
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
        currentFireStamp = 0;
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
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Time.time >= currentFireStamp)
        {
            currentFireStamp = Time.time + 1 / FireRate;
            Shoot();
        }
    }
}
