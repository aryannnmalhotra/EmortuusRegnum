using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    private int currentBalance = 20000;
    public Text CashUI;
    public void Deduct(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance - amount, 0 , 100000);
        CashUI.text = "$" + currentBalance.ToString();
    }
    public void Credit(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance + amount, 0, 100000);
        CashUI.text = "$" + currentBalance.ToString();
    }
    public int GetCurrentBalance()
    {
        return currentBalance;
    }
    private void Start()
    {
        CashUI.text = "$" + currentBalance.ToString();
    }
}
