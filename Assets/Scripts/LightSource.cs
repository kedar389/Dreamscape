using UnityEngine;
using UnityEngine.UI;

public class LightSource : MonoBehaviour
{
    public float sanityReplenishRate = 1f; // Rate at which sanity replenishes per second
    public float replenishDistance = 5f; // Distance threshold for player to be considered "near" the light source
    public LayerMask obstructionLayer; // Layer(s) to check for obstructions
    public Text sanityText; // Reference to the UI text element for displaying sanity

    private Transform player; // Reference to player's transform
    private float currentSanity; // Current sanity of the player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player object by tag
        currentSanity = 100f; // Set initial sanity value
        UpdateSanityText(); // Update sanity text element with initial sanity value
    }

    void Update()
    {
        // Calculate distance between player and light source
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is within the replenish distance
        if (distanceToPlayer < replenishDistance)
        {
            // Check if light source has clear line of sight to player
            Vector3 directionToPlayer = player.position - transform.position;
            Ray ray = new Ray(transform.position, directionToPlayer);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distanceToPlayer, obstructionLayer))
            {
                // If raycast hits an object on the obstruction layer, then line of sight is blocked
                // and sanity replenishment is not triggered
                return;
            }

            // Replenish player's sanity over time
            currentSanity += sanityReplenishRate * Time.deltaTime;

            // Clamp sanity to a maximum value of 100
            currentSanity = Mathf.Clamp(currentSanity, 0f, 100f);

            // Update sanity text element with current sanity value
            UpdateSanityText();

            // Other functionalities of the light source
            // ...
        }
    }

    void UpdateSanityText()
    {
        // Update the UI text element with the current sanity value
        sanityText.text = "Sanity: " + Mathf.RoundToInt(currentSanity).ToString();
    }

}
