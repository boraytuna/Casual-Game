using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void onLevel1(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(2);
    }

    public void onLevel2(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(3);
    }

    public void onLevel3(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(4);
    }

    public void onLevel4(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(2);
    }
    public void onLevel5(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(2);
    }

    public void goBack(){
        AudioManager.instance.Resume("Theme");
        SceneManager.LoadScene(0);
    }
}
