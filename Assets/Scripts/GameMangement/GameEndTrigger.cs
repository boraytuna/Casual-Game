using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AutomaticGunScript automaticGunScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameManager.EndGame();
            AudioManager.instance.Stop("StarSound");
            zombieAudioStop();
            if(automaticGunScript != null)
            {
                automaticGunScript.enabled = false;
            }

        }  
    }
        public void zombieAudioStop()
    {
        ZombieCharacterControl[] zombies = FindObjectsOfType<ZombieCharacterControl>();
        foreach (ZombieCharacterControl zombie in zombies)
        {
            zombie.StopZombieSound();
        }
    }
}
