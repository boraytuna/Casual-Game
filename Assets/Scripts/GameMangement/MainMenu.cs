using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    void Update(){
        AudioManager.instance.Resume("Theme");
    }
    public void OnPlayButton(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton(){
        Application.Quit();
        Debug.Log("Quit the game");
    }
}
