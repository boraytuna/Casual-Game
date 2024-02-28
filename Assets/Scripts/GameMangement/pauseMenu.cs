using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static  bool GameisPaused = false;
    public GameObject  pauseMenuUI;
    public AutomaticGunScript automaticGunScript;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(GameisPaused)
            {
                Resume();    
            }else
            {
                Pause();
            }
    }
     
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = false; // Disable shooting
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void restartLevel()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
