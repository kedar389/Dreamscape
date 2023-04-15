using UnityEngine;
using UnityEngine.UI;

public class LoseSanity : MonoBehaviour
{
    public float sanityDecreaseRate = 1f; // Rate at which sanity decreases per second

    private float currentSanity; // Current sanity value

    void Start()
    {
        currentSanity = 100f; // Set initial sanity value
    }

    void Update()
    {
        // Decrease sanity over time in the dark
        currentSanity -= sanityDecreaseRate * Time.deltaTime;

        // Perform sanity replenishment from specific light source
        // (you can call a function or event from the specific light source script here)
        // Example: lightSource.ReplenishSanity(currentSanity);

        // Check if sanity reaches zero or below
        if (currentSanity <= 0f)
        {
            // Player loses the game or takes appropriate action
            // Example: GameOver();
        }
    }
}

