using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private float health = 100;
    private int healthKitCount = 1;
    private AudioSource soundPlayer;
    public int MaxHealthkitCount = 10;
    public AudioClip Hurt;
    public AudioClip HealthkitUse;
    public Image Healthbar;
    public Image BloodImpact;
    public float GetHealth()
    {
        return health;
    }
    public void IncreaseHealth(float factor)
    {
        health = Mathf.Clamp(health + factor, 0, 100);
        Healthbar.fillAmount = health / 100;
        if (gameObject.CompareTag("Player"))
        {
            Color color = BloodImpact.color;
            color.a = ((100 - health) / 100) * 0.7f;
            BloodImpact.color = color;
        }
    }
    public void DecreaseHealth(float factor)
    {
        health = Mathf.Clamp(health - factor, 0, 100);
        Healthbar.fillAmount = health / 100;
        if (gameObject.CompareTag("Player"))
        {
            Color color = BloodImpact.color;
            color.a = ((100 - health) / 100) * 0.7f;
            BloodImpact.color = color;
        }
        soundPlayer.PlayOneShot(Hurt);
    }
    public void BuyHealthkit()
    {
        healthKitCount = Mathf.Clamp(healthKitCount + 1, 0, MaxHealthkitCount);
    }
    public void UseHealthKit()
    {
        soundPlayer.PlayOneShot(HealthkitUse);
        health = Mathf.Clamp(health + 70, 0, 100);
        healthKitCount = Mathf.Clamp(healthKitCount - 1, 0, MaxHealthkitCount);
        Healthbar.fillAmount = health / 100;
        if (gameObject.CompareTag("Player"))
        {
            Color color = BloodImpact.color;
            color.a = ((100 - health) / 100) * 0.7f;
            BloodImpact.color = color;
        }
    }
    public int GetHealthkitCount()
    {
        return healthKitCount;
    }
    private void Start()
    {
        healthKitCount = MaxHealthkitCount;
        soundPlayer = GetComponent<AudioSource>();
        if (gameObject.CompareTag("Player"))
        {
            Color color = BloodImpact.color;
            color.a = 0;
            BloodImpact.color = color;
        }
    }
}
