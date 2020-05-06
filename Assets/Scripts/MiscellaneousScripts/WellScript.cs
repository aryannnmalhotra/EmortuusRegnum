using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WellScript : MonoBehaviour
{
    private AudioSource soundPlayer;
    public AudioSource SoundPlayer2;
    public GameObject MainUI;
    public GameObject ObjectiveAchievedPanel;
    public GameObject WeaponsCam;
    public ParticleSystem Smoke;
    public ParticleSystem Flash;
    public ParticleSystem Flame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FpsAttributes.EnemyCount <= 0)
            {
                MainUI.SetActive(false);
                WeaponsCam.SetActive(false);
                ObjectiveAchievedPanel.SetActive(true);
                Smoke.Play();
                Flash.Play();
                Flame.Play();
                other.gameObject.GetComponent<FpsMovement>().enabled = false;
                other.gameObject.GetComponent<InventorySystem>().enabled = false;
                SoundPlayer2.Stop();
                soundPlayer.Play();
                Invoke("SceneShift", 10);
            }
        }
    }
    private void SceneShift()
    {
        SceneManager.LoadScene("EndScene");
    }
    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }
}
