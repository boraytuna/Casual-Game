// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class PlayerStats : MonoBehaviour
// {
//     // Static variable to keep track of stars collected across all levels
//     public static int totalCollectedStars = 0;
//     public int collectedStarPoints = 0;
//     public int currentStarsCollectedInLevel = 0;
//     public TextMeshProUGUI noOfStars;
//     public GameRespawn gameRespawn;
//     public PlayerCombat playerCombat;
//     public EndTrigger endTrigger;
//     private void Start()
//     {
//         // Add the stars collected in this level to the total
//         if(endTrigger != null)
//         {
//             if(endTrigger.levelCompleted == true)
//             {
//                 totalCollectedStars += collectedStarPoints;
//             }
//         }
//         UpdateStarCountUI();
//     }

//     public void AddStarPoint()
//     {
//         UpdateStarCountUI();
//         collectedStarPoints++;
//         totalCollectedStars++; 
//         if(playerCombat.playerisDead && gameRespawn.isPlayerDead == true)
//         {
//             currentStarsCollectedInLevel = collectedStarPoints;
//             totalCollectedStars = totalCollectedStars - currentStarsCollectedInLevel;
//         }
//     }

//     void UpdateStarCountUI()
//     {
//         if (noOfStars != null)
//         {
//             noOfStars.text = " " + collectedStarPoints;
//         }
//     }

// }

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int totalCollectedStars = 0;
    public int collectedStarPoints = 0;
    public TextMeshProUGUI noOfStars;
    public GameRespawn gameRespawn;
    public PlayerCombat playerCombat;
    public EndTrigger endTrigger; // Assuming this has access to a method to update the total star count.
    public GameEndTrigger gameEndTrigger;
    private void Start()
    {
        // Initialize stars for the level
        collectedStarPoints = 0;
        UpdateStarCountUI();
    }

    public void AddStarPoint()
    {
        collectedStarPoints++;
        UpdateStarCountUI();
    }

    private void UpdateStarCountUI()
    {
        if (noOfStars != null)
        {
            noOfStars.text = " " + collectedStarPoints;
        }
    }

    private void Update()
    {
        // Check if the level has been completed successfully
        if (endTrigger != null && endTrigger.levelCompleted)
        {
            FinishLevel();
        }
    }

    public void FinishLevel()
    {
        totalCollectedStars += collectedStarPoints;
        UpdateTotalStarsInEndTrigger();
        collectedStarPoints = 0;
        UpdateStarCountUI();
    }

    private void UpdateTotalStarsInEndTrigger()
    {
        // This function assumes your endTrigger component has a method to update the total stars.
        // You might need to replace "UpdateTotalStars" with the actual method name that does this.
        if(endTrigger != null)
        {
            endTrigger.UpdateTotalStars(totalCollectedStars);
        }
    }

    private void UpdateTotalStarsGameEndTrigger()
    {
        // This function assumes your endTrigger component has a method to update the total stars.
        // You might need to replace "UpdateTotalStars" with the actual method name that does this.
        if(gameEndTrigger != null)
        {
            gameEndTrigger.UpdateTotalStars(totalCollectedStars);
        }
    }

    private void OnPlayerDeath()
    {
        if(playerCombat.playerisDead && gameRespawn.isPlayerDead)
        {
            collectedStarPoints = 0;
            UpdateStarCountUI();
        }
    }
}
