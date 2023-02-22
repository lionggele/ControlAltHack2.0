using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SeetingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void BackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void SetVolume (float volume)
    {

        audioMixer.SetFloat("volume", volume);
    }
}
