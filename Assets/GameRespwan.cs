using UnityEngine;
using UnityEngine.UI;

public class GameRespwan : MonoBehaviour
{
    public float threshold;
    public Text youDiedText;

    void Start()
    {
        // Optional: Initialize the text to be hidden or display a default message
        if (youDiedText != null)
            youDiedText.enabled = false; // Hide the text at start
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            if (youDiedText != null)
            {
                youDiedText.enabled = true; // Show the text when condition is mets
            }
        }
        else
        {
            if (youDiedText != null)
                youDiedText.enabled = false; // Hide the text otherwise
        }
    }
}
