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
    public LevelTimer levelTimer;
    public bool isPlayerDead = false;

    void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>(); // Find the PlayerCombat script in the scene
        gunScript = FindObjectOfType<AutomaticGunScript>(); // Find the AutomaticGunScript in the scene
        levelTimer = FindObjectOfType<LevelTimer>();
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (youDiedText != null)
        {
            youDiedText.gameObject.SetActive(true); // This ensures the GameObject is active
            youDiedText.enabled = true; // This ensures the component is active
        }
        // Start coroutine to show the respawn button after a delay
        StartCoroutine(ShowRespawnButtonWithDelay(2)); // 2 seconds delay
        
        // Disable the gun script to stop shooting
        if (gunScript != null)
            gunScript.enabled = false;
        if (levelTimer != null)
            levelTimer.enabled = false;
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
        AudioManager.instance.Stop("StarSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
