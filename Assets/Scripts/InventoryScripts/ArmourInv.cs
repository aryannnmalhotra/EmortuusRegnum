using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArmourInv : MonoBehaviour
{
    public ArmourSystem PlayerArmour;
    public Text Details;
    private void OnEnable()
    {
        Details.text = "MEND TIME : " + PlayerArmour.GetMendTime().ToString() + " SEC";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (PlayerArmour.GetArmourLevelState() == 0)
                PlayerArmour.MendArmour();
        }
    }
}
