using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScroll : MonoBehaviour
{
    private int currentItem;
    public int MaxIndex;
    void OnEnable()
    {
        currentItem = 0;
        SelectItem();
    }
    void SelectItem()
    {
        int i = 0;
        foreach (RectTransform item in transform)
        {
            if (currentItem == i)
            {
                item.gameObject.SetActive(true);
            }
            else
                item.gameObject.SetActive(false);
            i++;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentItem < MaxIndex)
                currentItem++;
            else
                currentItem = 0;
            SelectItem();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentItem > 0)
                currentItem--;
            else
                currentItem = MaxIndex;
            SelectItem();
        }
    }
}
