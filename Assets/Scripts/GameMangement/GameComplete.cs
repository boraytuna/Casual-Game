using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    public GameObject completeGameUI;
    public PlayerStats playerStats; 
    public static bool GameisPaused = false;
    public static bool GameisComplete = false;
    public AutomaticGunScript automaticGunScript; 
    public ZombieCharacterControl zombieCharacterControl;


    void Update()
    {
        if(GameisComplete == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (automaticGunScript != null)
            {
                automaticGunScript.enabled = false; 
            }
            GameisPaused = true;
        }
    }

    public void CompleteGame()
    {
        GameisComplete = true;
        UpdateGameEndedUI();
        completeGameUI.SetActive(true); 
        DisableZombie();
    }

    public void DisableZombie()
    {
        if(zombieCharacterControl != null)
        {
            zombieCharacterControl.enabled = false;
        }
    }

    public void UpdateGameEndedUI()
    {

        TextMeshProUGUI totalStarsText = completeGameUI.GetComponentInChildren<TextMeshProUGUI>();

        if (totalStarsText != null)
        {
            totalStarsText.text = "Total Stars Collected: " + PlayerStats.totalCollectedStars.ToString();
        }
    }

    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit the game"); 
    }

    public void onMainMenuButton()
    {
        GameisPaused = false;
        SceneManager.LoadScene(0);

        if (automaticGunScript != null)
        {
            automaticGunScript.enabled = true; // Enable shooting
        }
    }
}
