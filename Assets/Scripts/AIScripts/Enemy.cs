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
    private TaskManager taskManager;
    private Vector3 startPosition;
    public float SpotRange = 5;
    public float PatrolRadius = 5;
    public GameObject Weapon;
    public Transform PlayerPosition;
    void Start()
    {
        isActive = false;
        healthSystem = GetComponent<HealthSystem>();
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        taskManager = GetComponent<TaskManager>();
        startPosition = transform.position;
        InvokeRepeating("PatrolCall", 0, 3);
    }
    void PatrolCall()
    {
        if (!isActive)
        {
            float xToAdd = Random.Range(-PatrolRadius, PatrolRadius);
            float zToAdd = Random.Range(-PatrolRadius, PatrolRadius);
            if (xToAdd >= -1.5f && xToAdd <= 1.5f)
                xToAdd *= 3;
            if (zToAdd >= -1.5f && zToAdd <= 1.5f)
                zToAdd *= 3;
            Vector3 patrolPoint = startPosition + new Vector3(xToAdd, 0, -(zToAdd));
            taskManager.StartTask(new PatrolTask(taskManager, anim, navAgent, patrolPoint));
        }
    }
    public void DamageInflicted(float damage)
    {
        navAgent.ResetPath();
        taskManager.StartTask(new HurtTask(taskManager, anim, healthSystem, damage));
    }
    void Update()
    {
        anim.SetFloat("WalkSpeed", navAgent.velocity.magnitude);
        if (Vector3.Distance(transform.position, PlayerPosition.position) <= SpotRange)
            isActive = true;
        if (Vector3.Distance(transform.position, PlayerPosition.position) > 16)
            isActive = false;
        if(healthSystem.GetHealth() <= 0)
        {
            navAgent.ResetPath();
            anim.SetBool("Die", true);
            Destroy(this.gameObject, 4);
        }
    }
}
