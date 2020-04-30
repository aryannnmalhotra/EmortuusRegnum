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
        Details.text = "Level : " + PlayerArmour.GetArmourLevel().ToString();
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
