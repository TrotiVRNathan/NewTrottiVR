using UnityEngine;

public class Collectible : MonoBehaviour
{
    public SpawnZone spawnZone;
    private bool isPlayerNearby = false;
    public AudioClip coinSound; // Reference to the coin sound effect (optional)
    public AudioClip obstacleSound; // Reference to the obstacle sound effect

    void Update()
    {
        // Check if the player is nearby
        if (isPlayerNearby)
        {
            CollectPiece();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected by the player");
            isPlayerNearby = true;
           
            // Optionally play coin sound
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Handle obstacle collision
            if (obstacleSound != null)
            {
                AudioSource.PlayClipAtPoint(obstacleSound, transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void CollectPiece()
    {
        if (spawnZone != null)
        {
            spawnZone.PieceCollected();
        }
        GameManager.Instance.AddCoin();
        Debug.Log("Coin destroyed");
        Destroy(gameObject);
    }
}

