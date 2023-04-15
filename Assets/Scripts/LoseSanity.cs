using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class LoseSanity : MonoBehaviour
{
    public float sanityDecreaseRate = 1f; // Rate at which sanity decreases per second
    public float lightDecreaseRate = 0.5f; // Rate at which light decreases per second

    public UnityEngine.Rendering.Universal.Light2D playerLight; // Reference to the player's light component
    public float maxLightIntensity = 1f; // Maximum intensity of the player's light

    public float currentSanity; // Current sanity value
    private float currentLightIntensity; // Current intensity of the pla
    public float flowerRadius = 5f;
    public Transform spawnPoint;
    void Start()
    {
        currentSanity = 100f; // Set initial sanity value
        currentLightIntensity = maxLightIntensity; // Se // Set initial light intensity
    }

    void Update()
    {
        // Update light intensity based on current sanity
        currentLightIntensity = currentSanity / 100f * maxLightIntensity; // Calculate new light intensity based on current sanity
        playerLight.intensity = currentLightIntensity;

        GameObject[] flowerLights = GameObject.FindGameObjectsWithTag("Flower Light"); // Find all game objects with tag "Flower Light"
        foreach (GameObject flowerLight in flowerLights)
        {

            // Check if the player is within the flower radius and can see the flower light
            if (Vector3.Distance(transform.position, flowerLight.transform.position) <= flowerRadius)
            {
                ReplenishSanity(); // Call ReplenishSanity function to replenish sanity
                return; // Exit after replenishing sanity from one visible flower light
            }

        }

        DecreaseSanity();

        // Check if sanity or light reaches zero or below
        if (currentSanity <= 0f)
        {
            StartCoroutine(Respawn());
            currentSanity = 100f;
        }
    }



    bool CanSeeFlowerLight(GameObject flowerLight)
    {
        Vector3 direction = flowerLight.transform.position - transform.position; // Calculate direction towards the flower light
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.CompareTag("Flower Light"))
            {
                return true; // Return true if the ray hits the "Flower Light" game object
            }
        }
        return false; // Return false otherwise
    }


    void DecreaseSanity()
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
    }


    void ReplenishSanity()
    {
        currentSanity += sanityDecreaseRate * Time.deltaTime; // Replenish sanity
        if (currentSanity > 100f)
        {
            currentSanity = 100f;
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Nightmare").transform.position = spawnPoint.position;

    }


}