using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
using System.Collections;

public class LevelManagement : MonoBehaviour
{
    public GameObject respawnButton;
    public TextMeshProUGUI youFailedText; 

    private void Start()
    {
        if (youFailedText != null) youFailedText.enabled = false;
        if (respawnButton != null) respawnButton.SetActive(false);
    }

    public void ShowFailedPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (youFailedText != null)
        {
            youFailedText.gameObject.SetActive(true); // This ensures the GameObject is active
            youFailedText.enabled = true; // This ensures the component is active
        }

        StartCoroutine(ShowRespawnButtonWithDelay(2));
    }

    // Method to reload the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ShowRespawnButtonWithDelay(float delay)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delay);

        // After the delay, activate the respawn button
        if (respawnButton != null)
            respawnButton.gameObject.SetActive(true);
    }
}
