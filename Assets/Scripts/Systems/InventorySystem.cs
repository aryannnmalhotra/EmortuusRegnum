using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private bool isDisplaying;
    public GameObject InventoryPanel;
    public GameObject Crosshair;
    public GameObject WeaponsCam;
    public FpsController Rotation;
    public FpsMovement Translation;
    void Start()
    {
        isDisplaying = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isDisplaying)
            {
                WeaponsCam.SetActive(false);
                Crosshair.SetActive(false);
                Rotation.enabled = false;
                Translation.enabled = false;
                InventoryPanel.SetActive(true);
                isDisplaying = !isDisplaying;
            }
            else
            {
                WeaponsCam.SetActive(true);
                Rotation.enabled = true;
                Translation.enabled = true;
                InventoryPanel.SetActive(false);
                isDisplaying = !isDisplaying;
            }
        }
    }
}
