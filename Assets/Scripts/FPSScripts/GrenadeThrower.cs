using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrenadeThrower : MonoBehaviour
{
    private int currentGrenadeCount;
    private AudioSource soundPlayer;
    public int MaxGrenadeCount = 10;
    public float ThrowForce = 16;
    public GameObject Grenade;
    public AudioClip Grunt;
    public AudioClip Blast;
    public Text GrenadeUI;
    void Start()
    {
        currentGrenadeCount = MaxGrenadeCount;
        soundPlayer = GetComponent<AudioSource>();
        GrenadeUI.text = "GRENADES : " + currentGrenadeCount.ToString() + "/" + MaxGrenadeCount.ToString();
    }
    public bool CanBuyGrenade()
    {
        if (currentGrenadeCount == MaxGrenadeCount)
            return false;
        else
            return true;
    }
    private void OnEnable()
    {
        GrenadeUI.text = "GRENADES : " + currentGrenadeCount.ToString() + "/" + MaxGrenadeCount.ToString();
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
        soundPlayer.PlayOneShot(Grunt);
        StartCoroutine(Blow());
        GameObject ThrownGrenade = Instantiate(Grenade, transform.position, transform.rotation);
        Rigidbody rb = ThrownGrenade.GetComponent<Rigidbody>();
        rb.AddForce((ThrownGrenade.transform.forward * ThrowForce), ForceMode.VelocityChange);
        currentGrenadeCount--;
        GrenadeUI.text = "GRENADES : " + currentGrenadeCount.ToString() + "/" + MaxGrenadeCount.ToString();
    }
    IEnumerator Blow()
    {
        yield return new WaitForSeconds(4);
        soundPlayer.PlayOneShot(Blast);
    }
    void Update()
    {
        if (currentGrenadeCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ThrowGrenade();
            }
        }
    }
}
