using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScroll : MonoBehaviour
{
    private int currentItem;
    private AudioSource soundPlayer;
    public int MaxIndex;
    public AudioClip Scroll;
    void OnEnable()
    {
        soundPlayer = GetComponent<AudioSource>();
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
                soundPlayer.PlayOneShot(Scroll);
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
