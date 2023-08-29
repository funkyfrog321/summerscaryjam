using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // WebGL doesn't support basic volume mixing, so we have to do it manually
    [Range(0f, 1f)]
    public float masterVolume = 1.0f;
    // Fader for music fade animation
    //public float musicFader = 1.0f;
    AudioSource musicSource;
    // All the audio sources
    AudioSource[] sources;
    // Original volume set for each source
    float[] volume_by_source;

    // Let the MenuManager know when you're ready
    public static event EventHandler SingletonLoaded;

    // Start is called before the first frame update
    void Start()
    {
        // There can be only one
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Keep the audio manager between scenes
        DontDestroyOnLoad(gameObject);
        // Load the player's volume preference from PlayerPrefs
        if (PlayerPrefs.HasKey("Volume"))
        {
            masterVolume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
            PlayerPrefs.Save();
        }

        sources = GetComponentsInChildren<AudioSource>();
        // Get the volume of each sound source
        volume_by_source = new float[sources.Length];
        for (int i = 0; i < sources.Length; i++)
        {
            volume_by_source[i] = sources[i].volume;
        }

        musicSource = sources[0];
        PlayTheMusic();
        SingletonLoaded?.Invoke(this, null);
    }

    public void StopTheMusic()
    {
        musicSource.Stop();
    }

    public void PlayTheMusic()
    {
        musicSource.Play();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();

        for (int i = 0; i < sources.Length; i++)
        {
            AudioSource source = sources[i];
            source.volume = volume_by_source[i] * masterVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
