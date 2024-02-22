using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Needed for IEnumerator

public class GameRespawn : MonoBehaviour
{
    public float threshold1;
    public TextMeshProUGUI youDiedText;
    public Button respawnButton;
    public PlayerCombat playerCombat; // Reference to the player's combat script
    public AutomaticGunScript gunScript; // Reference to the AutomaticGunScript

    private bool isPlayerDead = false;

    void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>(); // Find the PlayerCombat script in the scene
        gunScript = FindObjectOfType<AutomaticGunScript>(); // Find the AutomaticGunScript in the scene
    }

    void Update()
    {
        if (playerCombat.health <= 0 && !isPlayerDead)
        {
            isPlayerDead = true;
            PlayerDied();
        }
        else if (transform.position.y < threshold1 && !isPlayerDead)
        {
            isPlayerDead = true;
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        if (youDiedText != null)
        {
            youDiedText.gameObject.SetActive(true); // This ensures the GameObject is active
            youDiedText.enabled = true; // This ensures the component is active
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Disable the gun script to stop shooting
        if (gunScript != null)
            gunScript.enabled = false;

        // Start coroutine to show the respawn button after a delay
        StartCoroutine(ShowRespawnButtonWithDelay(2)); // 2 seconds delay
    }

    IEnumerator ShowRespawnButtonWithDelay(float delay)
    {
        // Wait for the specified delay duration
        yield return new WaitForSeconds(delay);

        // After the delay, activate the respawn button
        if (respawnButton != null)
            respawnButton.gameObject.SetActive(true);
    }

    public void RespawnPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
