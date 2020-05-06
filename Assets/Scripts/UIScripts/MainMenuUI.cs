using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private bool isManualActive;
    private int currentScreen = 0;
    private AudioSource soundPlayer;
    public AudioClip Button;
    public AudioClip Scroll;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        soundPlayer = GetComponent<AudioSource>();
    }
    private void Select()
    {
        int i = 0;
        foreach(Transform ManualPage in transform)
        {
            if (i == currentScreen)
                ManualPage.gameObject.SetActive(true);
            else
                ManualPage.gameObject.SetActive(false);
            i++;
        } 
    }
    private void Deselect()
    {
        foreach(Transform ManualPage in transform)
        {
            ManualPage.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (!isManualActive)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                soundPlayer.PlayOneShot(Button);
                SceneManager.LoadScene("GameScene");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                soundPlayer.PlayOneShot(Button);
                isManualActive = true;
                Select();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                soundPlayer.PlayOneShot(Scroll);
                isManualActive = false;
                Deselect();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                soundPlayer.PlayOneShot(Scroll);
                if (currentScreen < 16)
                    currentScreen++;
                else
                    currentScreen = 0;
                Select();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                soundPlayer.PlayOneShot(Scroll);
                if (currentScreen > 0)
                    currentScreen--;
                else
                    currentScreen = 16;
                Select();
            }
        }
    }
}
