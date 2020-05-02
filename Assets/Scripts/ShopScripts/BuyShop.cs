using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShop : MonoBehaviour
{
    private bool isAtShop;
    private bool isShopping;
    public GameObject Crosshair;
    public GameObject HUDPanel;
    public GameObject ShopPanel;
    public GameObject EnemyCountHUD;
    public GameObject WeaponsCam;
    public FpsController Rotation;
    public FpsMovement Translation;
    public InventorySystem Inventory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inventory.enabled = false;
            WeaponsCam.SetActive(false);
            Crosshair.SetActive(false);
            HUDPanel.SetActive(true);
            isAtShop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inventory.enabled = true;
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
        if (isAtShop && FpsAttributes.IsAlive)
        {
            if (!isShopping)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    HUDPanel.SetActive(false);
                    ShopPanel.SetActive(true);
                    EnemyCountHUD.SetActive(false);
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
                    EnemyCountHUD.SetActive(true);
                    Rotation.enabled = true;
                    Translation.enabled = true;
                    isShopping = false;
                }
            }
        }
    }
}
