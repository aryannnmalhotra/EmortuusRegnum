using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    private bool isAimOn;
    private bool isReloading;
    private int currentAmmo;
    private float currentFireStamp;
    private Animator anim;
    public bool IsSniper;
    public int AmmoPerRound = 5;
    public int ExtraRounds = 0;
    public int MaxRounds = 10;
    public float ReloadTime = 2.5f;
    public float Damage = 10;
    public float Range = 30;
    public float ShotForce = 10;
    public float FireRate = 5;
    public Camera FpsCam;
    public GameObject Crosshair;
    public GameObject OnShot;
    public ParticleSystem Flash;
    public ParticleSystem Smoke1;
    public ParticleSystem Smoke2;
    public Text AmmoUI;
    private void Awake()
    {
        currentAmmo = AmmoPerRound;
    }
    void Start()
    {
        isAimOn = false;
        isReloading = false;
        currentFireStamp = 0;
    }
    public bool CanBuyAmmo()
    {
        if (ExtraRounds == MaxRounds - 1)
            return false;
        else
            return true;
    }
    public void BuyAmmo()
    {
        ExtraRounds = Mathf.Clamp(ExtraRounds + 1, 0, MaxRounds);
    }
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }
    private void OnEnable()
    {
        isAimOn = false;
        Crosshair.SetActive(false);
        anim = GetComponent<Animator>();
        isReloading = false;
        anim.SetBool("Reload", false);
        AmmoUI.text = currentAmmo.ToString() + "/" + ((ExtraRounds + 1) * AmmoPerRound).ToString();
    }
    void Shoot()
    {
        anim.SetBool("Shoot", true);
        Invoke("ShootReset", 0.1f);
        Flash.Play();
        Smoke1.Play();
        Smoke2.Play();
        RaycastHit shot;
        if(Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out shot, Range))
        {
            Enemy shotEnem = shot.transform.GetComponent<Enemy>();
            if (shotEnem != null)
            {
                shotEnem.DamageInflicted(Damage);
            }
            if (shot.rigidbody != null)
                shot.rigidbody.AddForce(-shot.normal * ShotForce);
            Instantiate(OnShot, shot.point, Quaternion.LookRotation(shot.normal));
        }
        currentAmmo--;
        AmmoUI.text = currentAmmo.ToString() + "/" + ((ExtraRounds + 1) * AmmoPerRound).ToString();
    }
    void ShootReset()
    {
        anim.SetBool("Shoot", false);
    }
    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("Reload", true);
        yield return new WaitForSeconds(ReloadTime - 0.25f);
        anim.SetBool("Reload", false);
        yield return new WaitForSeconds(0.25f);
        ExtraRounds--;
        currentAmmo = AmmoPerRound;
        AmmoUI.text = currentAmmo.ToString() + "/" + ((ExtraRounds + 1) * AmmoPerRound).ToString();
        isReloading = false;
    }
    void Update()
    {
        if (isReloading)
            return;
        if(currentAmmo <= 0)
        {
            if (ExtraRounds > 0)
                StartCoroutine(Reload());
            return;
        }
        if (Input.GetKey(KeyCode.C) && Time.time >= currentFireStamp)
        {
            currentFireStamp = Time.time + 1 / FireRate;
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && !IsSniper)
        {
            Crosshair.SetActive(!isAimOn);
            isAimOn = !isAimOn;
        }
    }
}
