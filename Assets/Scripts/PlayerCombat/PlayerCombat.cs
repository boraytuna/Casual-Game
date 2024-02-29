using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public float health; // Player's health
    public float maxHealth;
    public Image HealthBar;
    public TextMeshProUGUI youDiedText;
    public Button respawnButton;

    public GameObject bulletPrefab; // Bullet prefab to shoot
    public Transform bulletSpawnPoint; // Where the bullet is spawned on the player
    public float bulletForce = 20f; // Force applied to the bullet for shooting
    public float attackRate = 2f; // Rate of fire
    private float lastAttackTime = 3f; // Time since last shot
    public AudioSource playerGettingHurt;

    void Awake()
    {
        playerGettingHurt = GetComponent<AudioSource>();    
    }

    private void Start()
    {
        maxHealth = health;
        if (youDiedText != null)
            youDiedText.enabled = false;
        if (respawnButton != null)
            respawnButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // HealthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (Input.GetButtonDown("Fire1") && Time.time - lastAttackTime >= attackRate)
        {
            Shoot();
            lastAttackTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.VelocityChange);
        Destroy(bullet);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        playerGettingHurt.Play();
        HealthBar.fillAmount = health / 100f;
        if (health <= 0)
        {
            Die();
            GetComponent<GameRespawn>().enabled = true;
        }
    }

    void Die()
    {
        Debug.Log("player died");
        GetComponent<PlayerMovement>().enabled = false; // Disable player movement
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(10f);
        }
    }
}