using UnityEngine;
using UnityEngine.UI;

public class LoseSanity : MonoBehaviour
{
    public float sanityDecreaseRate = 1f; // Rate at which sanity decreases per second
    public float lightDecreaseRate = 0.5f; // Rate at which light decreases per second

    public UnityEngine.Rendering.Universal.Light2D playerLight; // Reference to the player's light component
    public float maxLightIntensity = 1f; // Maximum intensity of the player's light

    private float currentSanity; // Current sanity value
    private float currentLightIntensity; // Current intensity of the pla


    void Start()
    {
        currentSanity = 100f; // Set initial sanity value
        currentLightIntensity = maxLightIntensity; // Se // Set initial light intensity
    }

    void Update()
    {

        // Decrease sanity over time in the dark
        if (currentSanity > 0)
        {
            currentSanity -= sanityDecreaseRate * Time.deltaTime;
            if (currentSanity < 0)
            {
                currentSanity = 0;
            }
        }
        


        // Update light intensity based on current sanity
        currentLightIntensity = currentSanity / 100f * maxLightIntensity; // Calculate new light intensity based on current sanity
        playerLight.intensity = currentLightIntensity;

        // Perform sanity replenishment from specific light source
        // (you can call a function or event from the specific light source script here)
        // Example: lightSource.ReplenishSanity(currentSanity);

        // Check if sanity or light reaches zero or below
        if (currentSanity <= 0f)
        {
            // Player loses the game or takes appropriate action
            // Example: GameOver();
        }
    }

   
}