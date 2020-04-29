using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourSystem : MonoBehaviour
{
    private int armourLevel = 0;
    private int armourLevelState;
    private float upgradeCost;
    private float mendCost;
    private float hits = 0;
    public void TakeHit()
    {
        hits++;
        if (hits % 10 == 0)
        {
            hits = 0;
            armourLevelState = 0;
        }
    }
    public void MendArmour()
    {
        armourLevelState = armourLevel;
    }
    public int GetArmourLevel()
    {
        return armourLevel;
    }
    public int GetArmourLevelState()
    {
        return armourLevelState;
    }
    public float GetMendCost()
    {
        return mendCost;
    }
    public float GetUpgradeCost()
    {
        return upgradeCost;
    }
    public void SetMendCost(float newCost)
    {
        mendCost = newCost;
    }
    public void SetUpgradeCost(float newCost)
    {
        upgradeCost = newCost;
    }
}
