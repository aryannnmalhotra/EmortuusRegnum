using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    private int currentBalance = 2000;
    public void Deduct(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance - amount, 0 , 100000);
    }
    public void Credit(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance + amount, 0, 100000);
    }
    public int GetCurrentBalance()
    {
        return currentBalance;
    }
}
