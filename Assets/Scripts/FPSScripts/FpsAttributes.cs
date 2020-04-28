using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAttributes : MonoBehaviour
{
    private HealthSystem healthSystem;
    private ArmourSystem armourSystem;
    public static bool IsAlive;
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        armourSystem = GetComponent<ArmourSystem>();
        IsAlive = true;
    }
    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
            IsAlive = false;
        }
    }
}
