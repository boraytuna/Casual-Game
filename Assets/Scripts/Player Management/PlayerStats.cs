// using UnityEngine;
// using UnityEngine.UI; 
// using TMPro; // For TextMeshPro

// public class PlayerStats : MonoBehaviour
// {
//     public int collectedStarPoints = 0;
//     public Text starCountText;
//     public TextMeshProUGUI noOfStars;

//     private void Start()
//     {
//         UpdateStarCountUI();
//     }

//     public void AddStarPoint()
//     {
//         collectedStarPoints++;
//         UpdateStarCountUI();
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
using TMPro; // For TextMeshPro

public class PlayerStats : MonoBehaviour
{
    // Static variable to keep track of stars collected across all levels
    public static int totalCollectedStars = 0;
    public int collectedStarPoints = 0;
    public Text starCountText;
    public TextMeshProUGUI noOfStars;
    public TextMeshProUGUI totalStarsText; // Add a reference for displaying total stars

    private void Start()
    {
        // Add the stars collected in this level to the total
        totalCollectedStars += collectedStarPoints;

        UpdateStarCountUI();
        UpdateTotalStarsUI();
    }

    public void AddStarPoint()
    {
        collectedStarPoints++;
        totalCollectedStars++; // Increment the static variable as well

        UpdateStarCountUI();
        UpdateTotalStarsUI();
    }

    void UpdateStarCountUI()
    {
        if (noOfStars != null)
        {
            noOfStars.text = " " + collectedStarPoints;
        }
    }

    // New method to update the UI with the total stars collected
    void UpdateTotalStarsUI()
    {
        if (totalStarsText != null)
        {
            totalStarsText.text = "Total Stars: " + totalCollectedStars;
        }
    }
}
