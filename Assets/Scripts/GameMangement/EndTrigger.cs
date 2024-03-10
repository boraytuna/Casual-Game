// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EndTrigger : MonoBehaviour
// {
//     public GameManager gameManager;
//     public bool levelCompleted = false;
//     public void OnTriggerEnter (Collider other)
//     {
//         if(other.CompareTag("Player"))
//         {
//             gameManager.CompleteLevel();
//             levelCompleted = true;
//         }  
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public bool levelCompleted = false;

    // Add a public method to update the total stars in the GameManager or other relevant component.
    public void UpdateTotalStars(int totalStars)
    {
        // Assuming GameManager has a method to handle the total stars.
        // You might need to adjust this line to match your actual method signature.
        gameManager.UpdateTotalStars(totalStars);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // When the player triggers the end, mark the level as completed
            gameManager.CompleteLevel();
            levelCompleted = true;
            
            // Now, assuming your PlayerStats calls UpdateTotalStars when the level ends,
            // your GameManager should already have the updated total stars count.
            // If you need to do anything additional with the stars at this point,
            // you can call those methods here or within GameManager.CompleteLevel().
        }  
    }
}
