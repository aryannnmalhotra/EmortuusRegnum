using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WellScript : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject ObjectiveAchievedPanel;
    public GameObject WeaponsCam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FpsAttributes.EnemyCount <= 0)
            {
                MainUI.SetActive(false);
                WeaponsCam.SetActive(false);
                ObjectiveAchievedPanel.SetActive(true);
            }
        }
    }
}
