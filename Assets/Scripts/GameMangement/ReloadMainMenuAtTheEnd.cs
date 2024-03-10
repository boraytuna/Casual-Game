using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadMainMenuAtTheEnd : MonoBehaviour
{   
    public void reloadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
