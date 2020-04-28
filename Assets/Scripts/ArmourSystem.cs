using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourSystem : MonoBehaviour
{
    private int armourLevel = 5;
    private float hits = 0;
    public void TakeHit()
    {
        hits++;
        if(hits % 3 == 0)
        {
            hits = 0;
            armourLevel = Mathf.Clamp(armourLevel - 1, 1, 10);
        }
    }
    public int GetArmourLevel()
    {
        return armourLevel;
    }
}
