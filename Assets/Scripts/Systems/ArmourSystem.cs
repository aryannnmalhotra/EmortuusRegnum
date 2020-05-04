using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArmourSystem : MonoBehaviour
{
    private int armourLevel = 1;
    private int armourLevelState;
    private int upgradeCost = 5000;
    private int mendTime = 1;
    private int hits = 0;
    private int hitLimit = 3;
    public bool IsMending;
    public GameObject WeaponsCam;
    public Text ArmourUI;
    public Text ArmourHits;
    public Text ArmourLevel;
    public Text DamageProtection;
    public AudioSource SoundPlayer;
    public AudioClip MendingArmour;
    public void TakeHit()
    {
        if (armourLevelState == armourLevel && armourLevel != 0)
        {
            ++hits;
            ArmourHits.text = "HITS : " + hits.ToString() + "/" + hitLimit.ToString();
            if (hits % hitLimit == 0)
            {
                hits = 0;
                armourLevelState = 0;
                ArmourUI.text = "BROKEN";
                DamageProtection.text = "PROTECTION : " + "0%";
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
        SoundPlayer.PlayOneShot(MendingArmour);
        yield return new WaitForSeconds(mendTime);
        armourLevelState = armourLevel;
        hits = 0;
        ArmourUI.text = "INTACT";
        ArmourHits.text = "HITS : " + hits.ToString() + "/" + hitLimit.ToString();
        DamageProtection.text = "PROTECTION : " + (7 * armourLevel).ToString() + "%";
        SoundPlayer.Stop();
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
    public int GetMendTime() 
    {
        return mendTime;
    }
    public void Upgrade()
    {
        armourLevel = Mathf.Clamp(armourLevel + 1, 0, 10);
        armourLevelState = armourLevel;
        upgradeCost = Mathf.Clamp(upgradeCost + 2000, 0, 50000);
        mendTime = Mathf.Clamp(mendTime + 1, 0, 10);
        hits = 0;
        hitLimit = Mathf.Clamp(hitLimit + 2, 0, 20);
        ArmourUI.text = "INTACT";
        ArmourHits.text = "HITS : " + hits.ToString() + "/" + hitLimit.ToString();
        ArmourLevel.text = "LEVEL : " + armourLevel.ToString();
        DamageProtection.text = "PROTECTION : " + (7 * armourLevel).ToString() + "%";
    }
    private void Start()
    {
        armourLevelState = armourLevel;
        ArmourUI.text = "INTACT";
        ArmourHits.text = "HITS : " + hits.ToString() + "/" + hitLimit.ToString();
        ArmourLevel.text = "LEVEL : " + armourLevel.ToString();
        DamageProtection.text = "PROTECTION : " + (7 * armourLevel).ToString() + "%";
        WeaponsCam.SetActive(false);
        WeaponsCam.SetActive(true);
    }
}
