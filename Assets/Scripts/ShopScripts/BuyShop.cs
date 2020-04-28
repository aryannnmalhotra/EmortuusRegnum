using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShop : MonoBehaviour
{
    private bool isAtShop;
    private bool isShopping;
    public GameObject HUDPanel;
    public GameObject ShopPanel;
    public GameObject WeaponsCam;
    public FpsController Rotation;
    public FpsMovement Translation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WeaponsCam.SetActive(false);
            HUDPanel.SetActive(true);
            isAtShop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WeaponsCam.SetActive(true);
            HUDPanel.SetActive(false);
            isAtShop = false;
        }
    }
    void Start()
    {
        isAtShop = false;
        isShopping = false;
    }
    void Update()
    {
        if (isAtShop)
        {
            if (!isShopping)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    HUDPanel.SetActive(false);
                    ShopPanel.SetActive(true);
                    Rotation.enabled = false;
                    Translation.enabled = false;
                    isShopping = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    HUDPanel.SetActive(true);
                    ShopPanel.SetActive(false);
                    Rotation.enabled = true;
                    Translation.enabled = true;
                    isShopping = false;
                }
            }
        }
    }
}
