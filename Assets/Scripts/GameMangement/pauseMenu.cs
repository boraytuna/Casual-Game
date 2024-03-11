using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public AutomaticGunScript automaticGunScript; 
    public AudioSource[] allAudioSources;
    public GameObject playerUI;

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
        playerUI.SetActive(false);

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
        playerUI.SetActive(true);

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        AudioManager.instance.Stop("StarSound");
        AudioManager.instance.Resume("Theme");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        Time.timeScale = 1f;
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
        Time.timeScale = 1f;    
    }

    public void quitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
