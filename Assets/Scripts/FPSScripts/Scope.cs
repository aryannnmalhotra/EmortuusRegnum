using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scope : MonoBehaviour
{
    private bool isScoped;
    private Animator anim;
    public GameObject ScopeImage;
    public GameObject WeaponsCam;
    public Camera FpsCam;
    public Canvas UI;
    void Start()
    {
        anim = GetComponent<Animator>();
        isScoped = false;
    }
    private void OnDisable()
    {
        UI.enabled = true;
        isScoped = false;
        WeaponsCam.GetComponent<Camera>().enabled = true;
        ScopeImage.SetActive(false);
        FpsCam.fieldOfView = 60;
    }
    void ScopeActive()
    {
        UI.enabled = false;
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
                anim.SetBool("Scoped", true);
                Invoke("ScopeActive", .15f);
                isScoped = true;
            }
            else
            {
                WeaponsCam.GetComponent<Camera>().enabled = true;
                anim.SetBool("Scoped", false);
                ScopeImage.SetActive(false);
                FpsCam.fieldOfView = 60;
                isScoped = false;
                UI.enabled = true;
            }
        }
        if (isScoped)
        {
            if (Input.GetKey(KeyCode.E))
            {
                FpsCam.fieldOfView = Mathf.Clamp(FpsCam.fieldOfView - (15 * Time.deltaTime), 1, 50);
            }
            if (Input.GetKey(KeyCode.X))
            {
                FpsCam.fieldOfView = Mathf.Clamp(FpsCam.fieldOfView + (15 * Time.deltaTime), 1, 50);
            }
        }
    }
}
