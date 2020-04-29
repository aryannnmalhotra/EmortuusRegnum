using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private float health = 100;
    private int healthKitCount = 1;
    public int MaxHealthkitCount = 10;
    public Image Healthbar;
    public float GetHealth()
    {
        return health;
    }
    public void IncreaseHealth(float factor)
    {
        health = Mathf.Clamp(health + factor, 0, 100);
        Healthbar.rectTransform.localScale = new Vector3(health / 100, 1, 1);
    }
    public void DecreaseHealth(float factor)
    {
        health = Mathf.Clamp(health - factor, 0, 100);
        Healthbar.rectTransform.localScale = new Vector3(health / 100, 1, 1);
    }
    public void BuyHealthkit()
    {
        healthKitCount = Mathf.Clamp(healthKitCount + 1, 0, MaxHealthkitCount);
    }
    public void UseHealthKit()
    {
        health = Mathf.Clamp(health + 70, 0, 100);
        healthKitCount = Mathf.Clamp(healthKitCount - 1, 0, MaxHealthkitCount);
        Healthbar.rectTransform.localScale = new Vector3(health / 100, 1, 1);
    }
    public int GetHealthkitCount()
    {
        return healthKitCount;
    }
}
