using UnityEngine;
using UnityEngine.UI; 
using TMPro; // For TextMeshPro

public class PlayerStats : MonoBehaviour
{
    public int collectedStarPoints = 0;

    public Text starCountText;

    public TextMeshProUGUI noOfStars;

    private void Start()
    {
        UpdateStarCountUI();
    }

    public void AddStarPoint()
    {
        collectedStarPoints++;
        UpdateStarCountUI();
    }

    void UpdateStarCountUI()
    {
        if (noOfStars != null)
        {
            noOfStars.text = " " + collectedStarPoints;
        }
    }
}
