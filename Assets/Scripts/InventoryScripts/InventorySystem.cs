using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private bool isDisplaying;
    private AudioSource soundPlayer;
    public GameObject InventoryPanel;
    public GameObject Crosshair;
    public GameObject WeaponsCam;
    public FpsController Rotation;
    public FpsMovement Translation;
    public ArmourSystem PlayerArmour;
    public AudioClip Transition;
    void Start()
    {
        isDisplaying = false;
        soundPlayer = GetComponent<AudioSource>();
    }
    public bool GetIsDisplaying()
    {
        return isDisplaying;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            soundPlayer.PlayOneShot(Transition);
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
                if (!PlayerArmour.IsMending)
                    WeaponsCam.SetActive(true);
                Rotation.enabled = true;
                Translation.enabled = true;
                InventoryPanel.SetActive(false);
                isDisplaying = !isDisplaying;
            }
        }
    }
}
