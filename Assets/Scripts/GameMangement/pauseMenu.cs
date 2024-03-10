using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public AutomaticGunScript automaticGunScript; 
    public AudioSource[] allAudioSources;

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();    
            }
            else
            {
                Pause();
            }
        }
    }
     
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Pause all audio sources
        PauseAllAudioSources(); 
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Resume all audio sources
        ResumeAllAudioSources();
    }

    // Method to pause all audio sources
    void PauseAllAudioSources()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource != null && audioSource.gameObject != null && audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    // Method to resume all audio sources
    void ResumeAllAudioSources()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource != null && audioSource.gameObject != null && !audioSource.isPlaying)
            {
                audioSource.UnPause();
            }
        }
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
        AudioManager.instance.Stop("StarSound");
        AudioManager.instance.Resume("Theme");
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

    public void Levels()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;    
    }

    public void quitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
