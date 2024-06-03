using UnityEngine;

public class Collectible : MonoBehaviour
{
    public SpawnZone spawnZone;
    private bool isPlayerNearby = false;

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
        Destroy(gameObject);
    }
}