using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static  bool GameisPaused = false;
    public GameObject  pauseMenuUI;
    public AutomaticGunScript automaticGunScript; 
    public StarManagement starManager;
    public ZombieCharacterControl zombieController;
    public AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

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
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = false; // Disable shooting
        }

        if (starManager != null && starManager.starAudioSource != null)
        {
            starManager.starAudioSource.Pause();
        }

        if (zombieController != null && zombieController.zombieAudioSource != null)
        {
            zombieController.zombieAudioSource.Pause();
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        if (starManager != null && starManager.starAudioSource != null)
        {
            starManager.starAudioSource.UnPause();
        }

        if (zombieController != null && zombieController.zombieAudioSource != null)
        {
            zombieController.zombieAudioSource.UnPause();
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
