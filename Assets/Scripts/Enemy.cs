using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private bool isActive;
    private HealthSystem healthSystem;
    private Animator anim;
    private NavMeshAgent navAgent;
    public GameObject Weapon;
    public Transform PlayerPosition;
    public CapsuleCollider PlayerDetection;
    void Start()
    {
        isActive = false;
        healthSystem = GetComponent<HealthSystem>();
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerDetection.enabled = false;
        isActive = true;
    }
    public void DamageInflicted(float damage)
    {
        healthSystem.DecreaseHealth(damage);
    }
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, PlayerPosition.position) > 8.5f)
        {
            PlayerDetection.enabled = true;
            isActive = false;
        }
        if(healthSystem.GetHealth() <= 0)
        {
            anim.SetBool("Die", true);
            Destroy(this.gameObject, 7);
        }
    }
}
