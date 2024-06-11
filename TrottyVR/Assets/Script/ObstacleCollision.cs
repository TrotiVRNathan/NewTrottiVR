using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip soundEffect; // Reference to the sound effect AudioClip
    private bool isPlayerTouching = false; // Variable to track collision state

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on obstacle!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") // Check if colliding with the player
        {
            // Play sound only if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(soundEffect); // Play the sound effect
            }

            // Track collision state
            isPlayerTouching = true; 

            GetComponent<MeshRenderer>().material.color = Color.red; // Change to red material
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player") // Check if player leaves the collision area
        {
            isPlayerTouching = false; // Reset collision state
        }
    }

    private void Update()
    {
        if (!isPlayerTouching && audioSource.isPlaying) // Check if player is not touching and sound is playing
        {
            audioSource.Stop(); // Stop the sound effect
        }
    }
    
}