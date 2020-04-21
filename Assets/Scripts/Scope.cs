using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    private bool isScoped;
    private Animator anim;
    public GameObject ScopeImage;
    public GameObject Crosshair;
    public GameObject WeaponsCam;
    public Camera FpsCam;
    void Start()
    {
        anim = GetComponent<Animator>();
        isScoped = false;
    }
    void ScopeActive()
    {
        ScopeImage.SetActive(true);
        WeaponsCam.GetComponent<Camera>().enabled = false;
        FpsCam.fieldOfView = 28;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (!isScoped)
            {
                Crosshair.SetActive(false);
                anim.SetBool("Scoped", true);
                Invoke("ScopeActive", .15f);
                isScoped = true;
            }
            else
            {
                Crosshair.SetActive(true);
                WeaponsCam.GetComponent<Camera>().enabled = true;
                anim.SetBool("Scoped", false);
                ScopeImage.SetActive(false);
                FpsCam.fieldOfView = 60;
                isScoped = false;
            }
        }
        if (isScoped)
        {
            if (Input.GetKey(KeyCode.E))
            {
                FpsCam.fieldOfView = Mathf.Clamp(FpsCam.fieldOfView - (15 * Time.deltaTime),5,50);
            }
            if (Input.GetKey(KeyCode.X))
            {
                FpsCam.fieldOfView = Mathf.Clamp(FpsCam.fieldOfView + (15 * Time.deltaTime), 5, 50);
            }
        }
    }
}
