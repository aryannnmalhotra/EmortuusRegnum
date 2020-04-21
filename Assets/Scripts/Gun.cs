using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage = 10;
    public float Range = 30;
    public Camera FpsCam;
    public ParticleSystem Flash;
    public ParticleSystem Smoke1;
    public ParticleSystem Smoke2;
    void Start()
    {
        
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
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }
}
