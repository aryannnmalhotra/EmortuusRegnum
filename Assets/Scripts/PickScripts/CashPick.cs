using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPick : MonoBehaviour
{
    public int RotateSpeed = 70;
    public int decider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(decider == 0)
                other.gameObject.GetComponent<MoneySystem>().Credit(Random.Range(1000, 2001));
            else
                other.gameObject.GetComponent<MoneySystem>().Credit(Random.Range(2500, 4000));
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
    }
}
