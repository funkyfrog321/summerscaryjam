using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Thanks BMo
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject cursor;

    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        if (AudioManager.instance != null)
            volumeSlider.value = AudioManager.instance.masterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
        HideOrShowCursor();
    }
    
    public void ChangeVolume(float volume)
    {
        AudioManager.instance.SetMasterVolume(volume);
    }    

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void HideOrShowCursor()
    {
        if(pauseMenu.activeSelf == true)
        {
            cursor.SetActive(false );
        }
        else { cursor.SetActive(true ); }
    }
}