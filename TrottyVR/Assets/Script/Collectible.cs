using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    public SpawnZone spawnZone;
    private bool isPlayerNearby = false;
    private Collider playerCollider;

    void Update()
    {
        // Vérifier l'entrée du joueur si le joueur est à proximité
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            CollectPiece();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            playerCollider = null;
        }
    }

    private void CollectPiece()
    {
        if (spawnZone != null)
        {
            spawnZone.PieceCollected();
        }
        Destroy(gameObject);
    }
}
