using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float attackRate = 1f;
    public float hitPoints = 50f;
    public GameObject currentGround; // The current ground the zombie is on

    private Animator animator;
    private Transform playerTransform;
    private float lastAttackTime = 0f;
    private PlayerMovement playerMovementScript; // Assuming the player movement script holds a reference to the current ground

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovementScript = playerTransform.GetComponent<PlayerMovement>(); // Get the player's movement script to access currentGround
    }

    void Update()
    {
        if (hitPoints <= 0) return;

        // Check if both the player and the zombie are on the same ground object
        if (IsPlayerOnSameGround())
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= attackRange && Time.time - lastAttackTime >= attackRate)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
    }

    bool IsPlayerOnSameGround()
    {
        // Check if the player's current ground matches the zombie's current ground
        // This requires the playerMovementScript to have a public GameObject that represents the ground it's currently on
        return playerMovementScript.currentGround == this.currentGround;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        animator.SetFloat("MoveSpeed", moveSpeed);
    }

    void AttackPlayer()
    {
        animator.SetTrigger("Attack");
        if (Time.time - lastAttackTime >= attackRate)
        {
            playerTransform.GetComponent<PlayerCombat>().TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(float amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        // Disable zombie to stop it from moving and attacking
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5f); // Wait for death animation before destroying
    }

    void OnTriggerEnter(Collider other)
    {
        // This method is left empty if not used, ensure colliders are set correctly if needed
    }
}
