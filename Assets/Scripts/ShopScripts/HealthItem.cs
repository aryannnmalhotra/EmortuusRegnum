using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthItem : MonoBehaviour
{
    public int KitCost = 2000;
    public HealthSystem PlayerHealth;
    public MoneySystem PlayerMoney;
    public Text CostText;
    public Text DetailsText;
    private void OnEnable()
    {
        CostText.text = "$" + KitCost.ToString();
        DetailsText.text = PlayerHealth.GetHealthkitCount().ToString() + "/" + PlayerHealth.MaxHealthkitCount.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (PlayerMoney.GetCurrentBalance() >= KitCost && PlayerHealth.GetHealthkitCount() < PlayerHealth.MaxHealthkitCount)
            {
                PlayerMoney.Deduct(KitCost);
                PlayerHealth.BuyHealthkit();
                DetailsText.text = PlayerHealth.GetHealthkitCount().ToString() + "/" + PlayerHealth.MaxHealthkitCount.ToString();
            }
        }
    }
}
