using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScroll : MonoBehaviour
{
    private int currentWeapon;
    private AudioSource soundPlayer;
    public AudioClip WeaponSwitch;
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        currentWeapon = 1;
        SelectWeapon();
    }
    void SelectWeapon()
    {
        int i = 0; 
        foreach(Transform weapon in transform)
        {
            if (currentWeapon == i)
            {
                weapon.gameObject.SetActive(true);
                soundPlayer.PlayOneShot(WeaponSwitch);
            }
            else
            {
                if(i != 0)
                    weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon < 4)
                currentWeapon++;
            else
                currentWeapon = 1;
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentWeapon > 1)
                currentWeapon--;
            else
                currentWeapon = 4;
            SelectWeapon();
        }
    }
}
