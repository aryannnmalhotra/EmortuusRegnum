using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    private float currentGrenadeCount;
    public float ThrowForce = 16;
    public float MaxGrenadeCount = 10;
    public GameObject Grenade;
    void Start()
    {
        currentGrenadeCount = MaxGrenadeCount;
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
