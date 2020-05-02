using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShop : MonoBehaviour
{
    private bool isAtShop;
    private bool isShopping;
    private AudioSource soundPlayer;
    public GameObject Crosshair;
    public GameObject HUDPanel;
    public GameObject ShopPanel;
    public GameObject EnemyCountHUD;
    public GameObject WeaponsCam;
    public FpsController Rotation;
    public FpsMovement Translation;
    public InventorySystem Inventory;
    public AudioClip InVicinity;
    public AudioClip EnterExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inventory.enabled = false;
            WeaponsCam.SetActive(false);
            Crosshair.SetActive(false);
            HUDPanel.SetActive(true);
            isAtShop = true;
            soundPlayer.PlayOneShot(InVicinity);
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
            soundPlayer.PlayOneShot(InVicinity);
        }
    }
    void Start()
    {
        isAtShop = false;
        isShopping = false;
        soundPlayer = GetComponent<AudioSource>();
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
                    soundPlayer.PlayOneShot(EnterExit);
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
                    soundPlayer.PlayOneShot(EnterExit);
                }
            }
        }
    }
}
