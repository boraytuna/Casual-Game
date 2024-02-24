using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void onLevel1(){
        SceneManager.LoadScene(2);
    }

    public void onLevel2(){
        SceneManager.LoadScene(3);
    }

    public void onLevel3(){
        SceneManager.LoadScene(2);
    }

    public void onLevel4(){
        SceneManager.LoadScene(2);
    }
    public void onLevel5(){
        SceneManager.LoadScene(2);
    }

    public void goBack(){
        SceneManager.LoadScene(0);
    }
}
