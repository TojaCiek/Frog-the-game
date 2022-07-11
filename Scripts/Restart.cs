using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Gra");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
