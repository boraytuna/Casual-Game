using UnityEngine;
using TMPro; 
using UnityEngine.UI;
public class LevelTimer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;
    public PlayerMovement playerMovement;
    public AutomaticGunScript AutomaticGunScript;
    public ZombieCharacterControl ZombieCharacterControl;

    public LevelManagement levelManagement;

    private void Start()
    {
        if (playerMovement == null)
            playerMovement = FindObjectOfType<PlayerMovement>();
        if (AutomaticGunScript == null)
            AutomaticGunScript = FindObjectOfType<AutomaticGunScript>();
        if (ZombieCharacterControl == null)
            ZombieCharacterControl = FindObjectOfType<ZombieCharacterControl>();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimeText();
        }
        else
        {
            TimeUp();
        }
    }

    void UpdateTimeText()
    {
        timerText.text = "Time Left: " + Mathf.Round(timeLeft).ToString();
    }

    void TimeUp()
    {
        this.enabled = false;

        if (levelManagement != null)
        {
            levelManagement.ShowFailedPanel();
        }

        // Disable player movement and shooting
        if (playerMovement != null)
            playerMovement.enabled = false;
        if (AutomaticGunScript != null)
            AutomaticGunScript.enabled = false;
        if (ZombieCharacterControl != null)
            ZombieCharacterControl.enabled = false;
    }

}
