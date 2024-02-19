using UnityEngine;

public class AutomaticGunScript : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Inspector
    public Transform bulletSpawnPoint; // The point from which bullets will be spawned
    public float bulletForce = 600f; // The force that will be applied to the bullet for propulsion
    public float fireRate = 10f; // Bullets per second
    public float damage = 20f;

    private float nextTimeToFire = 0f; // Helper variable to control the fire rate

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the left mouse button is held down and if it's time to fire the next bullet
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.AddComponent<Rigidbody>(); // Ensure this matches your setup
        rb.useGravity = false;
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.VelocityChange);
        audio.PlayOneShot(audio.clip);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = this.damage; // Correctly references the damage field
        }

        Destroy(bullet, 2f); // Destroys the bullet after 2 seconds
    }

}
