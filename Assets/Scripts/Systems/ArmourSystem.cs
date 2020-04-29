using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourSystem : MonoBehaviour
{
    private int armourLevel = 0;
    private int armourLevelState;
    private int upgradeCost = 5000;
    private int mendTime = 1;
    private int hits = 0;
    private int hitLimit = 2;
    public bool IsMending;
    public GameObject WeaponsCam;
    public void TakeHit()
    {
        if (armourLevelState == armourLevel)
        {
            ++hits;
            if (hits % hitLimit == 0)
            {
                hits = 0;
                armourLevelState = 0;
            }
        }
    }
    public void MendArmour()
    {
        StartCoroutine(Mending());
    }
    IEnumerator Mending()
    {
        IsMending = true;
        yield return new WaitForSeconds(mendTime);
        armourLevelState = armourLevel;
        if(!GetComponent<InventorySystem>().GetIsDisplaying())
           WeaponsCam.SetActive(true);
        IsMending = false;
    }
    public int GetArmourLevel()
    {
        return armourLevel;
    }
    public int GetArmourLevelState()
    {
        return armourLevelState;
    }
    public int GetUpgradeCost()
    {
        return upgradeCost;
    }
    public void Upgrade()
    {
        armourLevel = Mathf.Clamp(armourLevel + 1, 0, 10);
        armourLevelState = armourLevel;
        upgradeCost = Mathf.Clamp(upgradeCost + 5000, 0, 50000);
        mendTime = Mathf.Clamp(mendTime + 1, 0, 10);
        hitLimit = Mathf.Clamp(hitLimit + 1, 0, 20);
    }
}
