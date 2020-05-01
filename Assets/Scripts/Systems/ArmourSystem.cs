using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArmourSystem : MonoBehaviour
{
    private int armourLevel = 0;
    private int armourLevelState;
    private int upgradeCost = 5000;
    private int mendTime = 1;
    private int hits = 0;
    private int hitLimit = 3;
    public bool IsMending;
    public GameObject WeaponsCam;
    public Text ArmourUI;
    public void TakeHit()
    {
        if (armourLevelState == armourLevel && armourLevel != 0)
        {
            ++hits;
            if (hits % hitLimit == 0)
            {
                hits = 0;
                armourLevelState = 0;
                ArmourUI.text = "BROKEN";
            }
        }
    }
    public void MendArmour()
    {
        if(armourLevelState != armourLevel)
            StartCoroutine(Mending());
    }
    IEnumerator Mending()
    {
        IsMending = true;
        yield return new WaitForSeconds(mendTime);
        armourLevelState = armourLevel;
        ArmourUI.text = "INTACT";
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
        ArmourUI.text = "INTACT";
        upgradeCost = Mathf.Clamp(upgradeCost + 2000, 0, 50000);
        mendTime = Mathf.Clamp(mendTime + 1, 0, 10);
        hitLimit = Mathf.Clamp(hitLimit + 2, 0, 20);
    }
    private void Start()
    {
        ArmourUI.text = "NONE";
        WeaponsCam.SetActive(false);
        WeaponsCam.SetActive(true);
    }
}
