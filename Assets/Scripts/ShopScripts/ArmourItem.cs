using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArmourItem : MonoBehaviour
{
    private int armourCost;
    public ArmourSystem PlayerArmour;
    public MoneySystem PlayerMoney;
    public Text CostText;
    public Text DetailsText;
    public Text ToUpgrade;
    private void OnEnable()
    {
        if (PlayerArmour.GetArmourLevel() != 10)
        {
            armourCost = PlayerArmour.GetUpgradeCost();
            CostText.text = "$" + armourCost.ToString();
            DetailsText.text = "Level : " + PlayerArmour.GetArmourLevel();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(PlayerMoney.GetCurrentBalance() >= armourCost && PlayerArmour.GetArmourLevel() < 10)
            {
                PlayerMoney.Deduct(armourCost);
                PlayerArmour.Upgrade();
                armourCost = PlayerArmour.GetUpgradeCost();
                CostText.text = "$" + armourCost.ToString();
                DetailsText.text = "Level : " + PlayerArmour.GetArmourLevel();
            }
        }
        if(PlayerArmour.GetArmourLevel() == 10)
        {
            CostText.text = "MAX";
            DetailsText.text = "MAX";
            ToUpgrade.text = "MAX";
        }
    }
}
