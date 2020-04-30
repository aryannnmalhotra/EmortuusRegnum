using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FpsAttributes : MonoBehaviour
{
    private HealthSystem healthSystem;
    private ArmourSystem armourSystem;
    public Text EnemyCountUI;
    public static int EnemyCount = 2;
    public static bool IsAlive;
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        IsAlive = true;
    }
    void Update()
    {
        if (healthSystem.GetHealth() <= 0)
        {
            IsAlive = false;
        }
        EnemyCountUI.text = "ENEMIES REMAINING : " + EnemyCount.ToString();
    }
}
