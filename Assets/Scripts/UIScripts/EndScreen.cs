using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private int screenIndex;
    private AudioSource soundPlayer;
    public AudioClip Button;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        soundPlayer = GetComponent<AudioSource>();
        if (FpsAttributes.EnemyCount == 0)
            screenIndex = 0;
        else
            screenIndex = 1;
        Select();
    }
    private void Select()
    {
        int i = 0;
        foreach(Transform Screen in transform)
        {
            if (i == screenIndex)
                Screen.gameObject.SetActive(true);
            else
                Screen.gameObject.SetActive(false);
            i++;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            soundPlayer.PlayOneShot(Button);
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            soundPlayer.PlayOneShot(Button);
            SceneManager.LoadScene("GameScene");
        }
    }
}
