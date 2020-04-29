using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private bool hasExploded;
    private float explosionCountdown;
    public float explosionDelay = 4;
    public float explosionRadius = 8;
    public float explosionForce = 300;
    public GameObject explosionEffect;

    void Start()
    {
        hasExploded = false;
        explosionCountdown = explosionDelay;
    }
    void Explode()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 2);
        Collider[] nearerColliders = Physics.OverlapSphere(transform.position, explosionRadius / 2);
        {
            foreach(Collider nearer in nearerColliders)
            {
                Rigidbody rb = nearer.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius / 2);
                }
                Enemy blastedEnem = nearer.GetComponent<Enemy>();
                if (blastedEnem != null)
                {
                    blastedEnem.DamageInflicted(100);
                }
            }
        }
        Collider[] fartherColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        {
            foreach (Collider farther in fartherColliders)
            {
                Rigidbody rb = farther.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce / 2, transform.position, explosionRadius);
                }
                Enemy blastedEnem = farther.GetComponent<Enemy>();
                if (blastedEnem != null)
                {
                    blastedEnem.DamageInflicted(75);
                }
            }
        }
        Destroy(gameObject);
    }
    void Update()
    {
        explosionCountdown -= Time.deltaTime;
        if(explosionCountdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
}
