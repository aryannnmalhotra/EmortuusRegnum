using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float health = 100;
    private int healthKitCount = 1;
    public int MaxHealthkitCount = 10;
    public float GetHealth()
    {
        return health;
    }
    public void IncreaseHealth(float factor)
    {
        health = Mathf.Clamp(health + factor, 0, 100);
    }
    public void DecreaseHealth(float factor)
    {
        health = Mathf.Clamp(health - factor, 0, 100);
    }
    public void BuyHealthkit()
    {
        healthKitCount = Mathf.Clamp(healthKitCount + 1, 0, MaxHealthkitCount);
    }
    public void UseHealthKit()
    {
        health = Mathf.Clamp(health + 70, 0, 100);
        healthKitCount = Mathf.Clamp(healthKitCount - 1, 0, MaxHealthkitCount);
    }
    public int GetHealthkitCount()
    {
        return healthKitCount;
    }
}
