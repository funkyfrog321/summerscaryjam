using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // How long to wait between the player pressing start and starting the game
    public float startDelaySeconds = 2f;
    public FlickerLights flickerLights;
    public GameObject postProcessVolume;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // The AudioManager might not be ready yet (usually the first time this scene is loaded).
        // Add an event listener to defer the slider setting and music playing
        if (AudioManager.instance == null)
        {
            AudioManager.SingletonLoaded += OnAudioSingletonLoaded;
        }
        else
        {
            OnAudioSingletonLoaded(null, null);
        }

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void OnAudioSingletonLoaded(object sender, EventArgs e)
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        AudioManager.instance.PlayTheMusic();
    }

    public void SetVolume(float value)
    {
        AudioManager.instance.SetMasterVolume(value);
    }

    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void HideOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void HideCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(DelayedStart());
        flickerLights.GetComponent<Animation>().Play("Spooky");
        postProcessVolume.GetComponent<Animation>().Play("SpookyBloom");
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(startDelaySeconds);
        AudioManager.instance.StopTheMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
