using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    private int currentGrenadeCount;
    public int MaxGrenadeCount = 20;
    public float ThrowForce = 16;
    public GameObject Grenade;
    void Start()
    {
        currentGrenadeCount = MaxGrenadeCount;
    }
    public bool CanBuyGrenade()
    {
        if (currentGrenadeCount == MaxGrenadeCount)
            return false;
        else
            return true;
    }
    public void BuyGrenade()
    {
        currentGrenadeCount = Mathf.Clamp(currentGrenadeCount + 1, 0, MaxGrenadeCount);
    }
    public int GetGrenadeCount()
    {
        return currentGrenadeCount;
    }
    void ThrowGrenade()
    {
        GameObject ThrownGrenade = Instantiate(Grenade, transform.position, transform.rotation);
        Rigidbody rb = ThrownGrenade.GetComponent<Rigidbody>();
        rb.AddForce((ThrownGrenade.transform.forward * ThrowForce), ForceMode.VelocityChange);
        currentGrenadeCount--;
    }
    void Update()
    {
        if (currentGrenadeCount >= 0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ThrowGrenade();
            }
        }
    }
}
