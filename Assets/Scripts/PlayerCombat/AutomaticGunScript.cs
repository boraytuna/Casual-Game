using UnityEngine;

public class AutomaticGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 600f;
    public float fireRate = 10f;
    public float damage = 20f;

    private float nextTimeToFire = 0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>(); // Use GetComponent instead of AddComponent
        if (rb != null)
        {
            rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.VelocityChange);
        }

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = this.damage;
        }

        // Play sound if audio clip is set
        if (audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        Destroy(bullet, 2f); // Destroys the bullet after 2 seconds
    }
}
