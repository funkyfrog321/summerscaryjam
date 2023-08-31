using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject cursor;
    public GameObject gameOverMessage;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);

    }

    public void DisplayMessage(string message)
    {
        gameOverMessage.GetComponent<TextMeshPro>().SetText(message);
    }

    public void ShowGameOverMenu()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        cursor.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PauseMenu.canPause = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level01");
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
