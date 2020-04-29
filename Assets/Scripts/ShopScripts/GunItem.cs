using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunItem : MonoBehaviour
{
    public int AmmoCost;
    public Gun GunType;
    public MoneySystem PlayerMoney;
    public Text CostText;
    public Text DetailsText;
    void Start()
    {
        CostText.text = "$" + AmmoCost.ToString();
        DetailsText.text = GunType.GetCurrentAmmo().ToString() + "/" + ((GunType.ExtraRounds + 1) * GunType.AmmoPerRound).ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (PlayerMoney.GetCurrentBalance() >= AmmoCost && GunType.CanBuyAmmo())
            {
                PlayerMoney.Deduct(AmmoCost);
                GunType.BuyAmmo();
                DetailsText.text = GunType.GetCurrentAmmo().ToString() + "/" + ((GunType.ExtraRounds + 1) * GunType.AmmoPerRound).ToString();
            }
        }
    }
}
