using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrenadeItem : MonoBehaviour
{
    public int GrenadeCost = 1000;
    public GrenadeThrower Grenade;
    public MoneySystem PlayerMoney;
    public Text CostText;
    public Text DetailsText;
    private void OnEnable()
    {
        CostText.text = "$" + GrenadeCost.ToString();
        DetailsText.text = Grenade.GetGrenadeCount().ToString() + "/" + Grenade.MaxGrenadeCount.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (PlayerMoney.GetCurrentBalance() >= GrenadeCost && Grenade.CanBuyGrenade())
            {
                PlayerMoney.Deduct(GrenadeCost);
                Grenade.BuyGrenade();
                DetailsText.text = Grenade.GetGrenadeCount().ToString() + "/" + Grenade.MaxGrenadeCount.ToString();
            }
        }
    }
}
