using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private bool isAlive = true;
    private bool isActive;
    private HealthSystem healthSystem;
    private Animator anim;
    private NavMeshAgent navAgent;
    private TaskManager taskManager;
    private Vector3 startPosition;
    public bool IsWeakerEnem;
    public float ShotDamage = 10;
    public float SpotRange = 10;
    public float FireRange = 4;
    public float EscapeRange = 16;
    public float PatrolRadius = 6;
    public GameObject Weapon;
    public GameObject DieEffect;
    public GameObject CashDrop;
    public Transform PlayerPosition;
    public Transform BulletOrigin;
    public ParticleSystem Flash;
    public ParticleSystem Smoke1;
    public ParticleSystem Smoke2;
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
        if (healthSystem.GetHealth() > 0)
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
    }
    public void DamageInflicted(float damage)
    {
        if (healthSystem.GetHealth() > 0)
        {
            navAgent.ResetPath();
            navAgent.isStopped = true;
            if (IsWeakerEnem)
                taskManager.PriorityStartTask(new HurtTask(taskManager, anim, healthSystem, damage * 2));
            else
                taskManager.PriorityStartTask(new HurtTask(taskManager, anim, healthSystem, damage));
        }
    }
    void Update()
    {
        anim.SetFloat("WalkSpeed", navAgent.velocity.magnitude);
        if (FpsAttributes.IsAlive)
        {
            if (healthSystem.GetHealth() > 0)
            {
                if (Vector3.Distance(transform.position, PlayerPosition.position) <= SpotRange && !isActive)
                {
                    isActive = true;
                    navAgent.ResetPath();
                }
                if (Vector3.Distance(transform.position, PlayerPosition.position) > EscapeRange && isActive)
                    isActive = false;
                if (isActive)
                {
                    if (Vector3.Distance(transform.position, PlayerPosition.position) <= FireRange)
                    {
                        FireRange = SpotRange - SpotRange / 5;
                        taskManager.StartTask(new ShootTask(taskManager, anim, navAgent, BulletOrigin.position, PlayerPosition.position, Flash, Smoke1, Smoke2, ShotDamage));
                    }
                    if (Vector3.Distance(transform.position, PlayerPosition.position) > FireRange)
                    {
                        taskManager.StartTask(new ChaseTask(taskManager, anim, navAgent, PlayerPosition.position));
                    }
                }
            }
            if (healthSystem.GetHealth() <= 0 && isAlive)
            {
                isAlive = false;
                FpsAttributes.EnemyCount--;
                navAgent.ResetPath();
                navAgent.isStopped = true;
                taskManager.PriorityStartTask(new DieTask(taskManager, anim, DieEffect, CashDrop));
            }
            else
                isActive = false;
        }
    }
}
