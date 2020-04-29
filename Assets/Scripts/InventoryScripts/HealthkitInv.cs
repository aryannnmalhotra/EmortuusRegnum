using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthkitInv : MonoBehaviour
{
    public HealthSystem PlayerHealth;
    public Text Details;
    private void OnEnable()
    {
        Details.text = PlayerHealth.GetHealthkitCount().ToString() + "/" + PlayerHealth.MaxHealthkitCount.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(PlayerHealth.GetHealthkitCount() > 0 && PlayerHealth.GetHealth() != 100)
            {
                PlayerHealth.UseHealthKit();
                Details.text = PlayerHealth.GetHealthkitCount().ToString() + "/" + PlayerHealth.MaxHealthkitCount.ToString();
            }
        }
    }
}
