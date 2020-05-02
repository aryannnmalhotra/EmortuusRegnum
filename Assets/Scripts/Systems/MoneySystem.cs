using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneySystem : MonoBehaviour
{
    private int currentBalance = 10000;
    private AudioSource soundPlayer;
    public Text CashUI;
    public AudioClip Transaction;
    public void Deduct(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance - amount, 0 , 100000);
        CashUI.text = "$" + currentBalance.ToString();
        soundPlayer.PlayOneShot(Transaction);
    }
    public void Credit(int amount)
    {
        currentBalance = Mathf.Clamp(currentBalance + amount, 0, 100000);
        CashUI.text = "$" + currentBalance.ToString();
        soundPlayer.PlayOneShot(Transaction);
    }
    public int GetCurrentBalance()
    {
        return currentBalance;
    }
    private void Start()
    {
        CashUI.text = "$" + currentBalance.ToString();
        soundPlayer = GetComponent<AudioSource>();
    }
}
