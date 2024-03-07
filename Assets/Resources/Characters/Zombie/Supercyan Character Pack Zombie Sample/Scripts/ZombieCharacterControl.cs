// using UnityEngine;

// public class ZombieCharacterControl : MonoBehaviour
// {
//     public float moveSpeed = 2f;
//     public float attackRange = 1.5f;
//     public float damage = 10f;
//     public float attackRate = 1f;
//     public float hitPoints = 50f;

//     public GameObject currentGround; 
//     private Animator animator;
//     private Transform playerTransform;
//     private float lastAttackTime = 0f;
//     private PlayerMovement playerMovementScript; 
//     private PlayerCombat playerCombatScript;
//     // public AudioSource zombieAudioSource; 
//     public GameObject starPrefab;


//     void Awake()
//     {
//         animator = GetComponent<Animator>();
//         playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
//         playerMovementScript = playerTransform.GetComponent<PlayerMovement>(); // Get the player's movement script to access currentGround
//         //zombieAudioSource = GetComponent<AudioSource>();
//         playerCombatScript = playerTransform.GetComponent<PlayerCombat>();
//     }

//     // void Update()
//     // {
//     //     if (hitPoints <= 0 || playerCombatScript.health <= 0)
//     //     {
//     //         AudioManager.instance.Stop("ZombieSound");
//     //     }

//     //     float distance = Vector3.Distance(transform.position, playerTransform.position);

//     //     // Check if both the player and the zombie are on the same ground object
//     //     if (IsPlayerOnSameGround())
//     //     {
//     //         if (distance > attackRange)
//     //         {
//     //             MoveTowardsPlayer();
//     //             animator.SetBool("isMoving", true);
//     //         }
//     //         else
//     //         {
//     //             animator.SetBool("isMoving", false);
//     //             if (Time.time - lastAttackTime >= attackRate)
//     //             {
//     //                 AttackPlayer();
//     //             }
//     //         }
//     //     }
//     //     else
//     //     {
//     //         animator.SetBool("isMoving", false);
//     //     }

//     //     if (IsPlayerOnSameGround())
//     //     {
//     //         AudioManager.instance.Play("ZombieSound");
//     //     }
//     //     else
//     //     {
//     //         AudioManager.instance.Stop("ZombieSound");
//     //     }
//     // }

//     void Update()
//     {
//         bool isOnSameGround = IsPlayerOnSameGround();

//         // Handle playing of the zombie sound
//         if (isOnSameGround && !AudioManager.instance.IsPlaying("ZombieSound"))
//         {
//             AudioManager.instance.Play("ZombieSound");
//         }
//         else if (!isOnSameGround && AudioManager.instance.IsPlaying("ZombieSound"))
//         {
//             AudioManager.instance.Stop("ZombieSound");
//         }

//         float distance = Vector3.Distance(transform.position, playerTransform.position);

//         if (isOnSameGround && distance > attackRange)
//         {
//             MoveTowardsPlayer();
//             animator.SetBool("isMoving", true);
//         }
//         else
//         {
//             animator.SetBool("isMoving", false);
//         }

//         if (isOnSameGround && distance <= attackRange && Time.time - lastAttackTime >= attackRate)
//         {
//             AttackPlayer();
//         }

//         if (hitPoints <= 0 || playerCombatScript.health <= 0)
//         {
//             if (AudioManager.instance.IsPlaying("ZombieSound"))
//             {
//                 AudioManager.instance.Stop("ZombieSound");
//             }
//             return;
//         }
//     }


//     bool IsPlayerOnSameGround()
//     {
//         return playerMovementScript.currentGround == this.currentGround;
//     }

//     void MoveTowardsPlayer()
//     {
//         Vector3 direction = (playerTransform.position - transform.position).normalized;
//         direction.y = 0; // This ensures we only get the direction in the XZ plane.
//         transform.position += direction * moveSpeed * Time.deltaTime;
//         transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

//         animator.SetFloat("MoveSpeed", moveSpeed);

//         RaycastHit hit;
//         if (Physics.Raycast(transform.position + Vector3.up, -Vector3.up, out hit))
//         {
//             float groundY = hit.point.y + 0.1f; // The 0.1f offset raises the zombie slightly above the ground to avoid clipping.
//             transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
//         }
//     }

//     void AttackPlayer()
//     {
//         if (playerCombatScript.health > 0)
//         {
//             animator.SetTrigger("Attack");
//             if (Time.time - lastAttackTime >= attackRate)
//             {
//                 playerTransform.GetComponent<PlayerCombat>().TakeDamage(damage);
//                 lastAttackTime = Time.time;
//             }
//         }

//     }

//     public void TakeDamage(float damage)
//     {
//         hitPoints -= damage;
//         if (hitPoints <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         animator.SetTrigger("Dead");
//         AudioManager.instance.Stop("ZombieSound");
//         this.enabled = false;
//         GetComponent<Collider>().enabled = false;
//         Destroy(gameObject, 5f);

//         if (starPrefab != null)
//         {
//             Vector3 starSpawnPosition = transform.position + new Vector3(0, 1f, 0); // Spawn the star 1 unit above the ground
//             GameObject starInstance = Instantiate(starPrefab, starSpawnPosition, Quaternion.identity);
//             Quaternion starSpawnRotation = Quaternion.Euler(90f, 0f, 0f);

//             // Access the AnimationScript on the star and set properties
//             AnimationScript starAnimationScript = starInstance.GetComponent<AnimationScript>();
//             if (starAnimationScript != null)
//             {
//                 starAnimationScript.isAnimated = true;
//                 starAnimationScript.isRotating = true;
//                 starAnimationScript.isFloating = false;
//                 starAnimationScript.isScaling = false;
//                 starAnimationScript.rotationAngle = new Vector3(1, 1, 1);
//                 starAnimationScript.rotationSpeed = 100f;
//             }

//         }
//     }
//     void OnTriggerEnter(Collider other)
//     {
//         // This method is left empty if not used, ensure colliders are set correctly if needed
//     }
// }

using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float attackRate = 1f;
    public float hitPoints = 50f;

    public GameObject currentGround; 
    private Animator animator;
    private Transform playerTransform;
    private float lastAttackTime = 0f;
    private PlayerMovement playerMovementScript; 
    private PlayerCombat playerCombatScript;
    public AudioSource zombieAudioSource; 
    public GameObject starPrefab;


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovementScript = playerTransform.GetComponent<PlayerMovement>(); // Get the player's movement script to access currentGround
        zombieAudioSource = GetComponent<AudioSource>();
        playerCombatScript = playerTransform.GetComponent<PlayerCombat>();
        AudioManager.instance?.RegisterCustomPauseAction(PauseAudio, ResumeAudio);
    }

    void Update()
    {
        if (hitPoints <= 0 || playerCombatScript.health <= 0)
        {
            zombieAudioSource.Stop();
        }

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // Check if both the player and the zombie are on the same ground object
        if (IsPlayerOnSameGround())
        {
            if (distance > attackRange)
            {
                MoveTowardsPlayer();
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
                if (Time.time - lastAttackTime >= attackRate)
                {
                    AttackPlayer();
                }
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (IsPlayerOnSameGround() && !zombieAudioSource.isPlaying)
        {
            zombieAudioSource.Play();
        }
    }

    bool IsPlayerOnSameGround()
    {
        return playerMovementScript.currentGround == this.currentGround;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0; // This ensures we only get the direction in the XZ plane.
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

        animator.SetFloat("MoveSpeed", moveSpeed);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, -Vector3.up, out hit))
        {
            float groundY = hit.point.y + 0.1f; // The 0.1f offset raises the zombie slightly above the ground to avoid clipping.
            transform.position = new Vector3(transform.position.x, groundY, transform.position.z);
        }
    }

    void AttackPlayer()
    {
        if (playerCombatScript.health > 0)
        {
            animator.SetTrigger("Attack");
            if (Time.time - lastAttackTime >= attackRate)
            {
                playerTransform.GetComponent<PlayerCombat>().TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }

    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Dead");
        if (zombieAudioSource != null)
        {
            zombieAudioSource.Stop();
            Destroy(zombieAudioSource.gameObject, 0.1f); // Destroy the GameObject containing the audio source
        }
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 5f);

        if (starPrefab != null)
        {
            Vector3 starSpawnPosition = transform.position + new Vector3(0, 1f, 0); // Spawn the star 1 unit above the ground
            GameObject starInstance = Instantiate(starPrefab, starSpawnPosition, Quaternion.identity);
            Quaternion starSpawnRotation = Quaternion.Euler(90f, 0f, 0f);

            // Access the AnimationScript on the star and set properties
            AnimationScript starAnimationScript = starInstance.GetComponent<AnimationScript>();
            if (starAnimationScript != null)
            {
                starAnimationScript.isAnimated = true;
                starAnimationScript.isRotating = true;
                starAnimationScript.isFloating = false;
                starAnimationScript.isScaling = false;
                starAnimationScript.rotationAngle = new Vector3(1, 1, 1);
                starAnimationScript.rotationSpeed = 100f;
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        // This method is left empty if not used, ensure colliders are set correctly if needed
    }

    // Add methods to pause and resume zombie audio sources
    public void PauseAudio()
    {
        if (zombieAudioSource != null && zombieAudioSource.isPlaying)
        {
            zombieAudioSource.Pause();
        }
    }

    public void ResumeAudio()
    {
        if (zombieAudioSource != null && !zombieAudioSource.isPlaying)
        {
            zombieAudioSource.UnPause();
        }
    }
    void OnDestroy()
    {
        AudioManager.instance?.DeregisterCustomPauseAction(PauseAudio, ResumeAudio);
    }   

}