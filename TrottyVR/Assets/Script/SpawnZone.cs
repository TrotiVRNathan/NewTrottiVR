using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs; // Prefab for the coin
    [SerializeField] private Vector3 zoneSize;

    private GameObject currentPiece;
    private int piecesCollected = 0;

    void Start()
    {
        // Start by spawning one coin
        SpawnRandomPiece();
    }

    void SpawnRandomPiece()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogWarning("No prefab assigned to the SpawnZone script.");
            return;
        }

        if (piecesCollected >= 10)
        {
            Debug.Log("All coins have been collected. Stopping spawn.");
            return; // Stop spawning if 10 coins have been collected
        }

        int randomIndex = Random.Range(0, prefabs.Length);  // Select a random prefab
        GameObject selectedPrefab = prefabs[randomIndex];

        currentPiece = Instantiate(selectedPrefab);
        currentPiece.transform.position = GetRandomPositionWithinZone();

        // Assign this script as the spawn zone to the coin so it can call PieceCollected
        Collectible collectible = currentPiece.GetComponent<Collectible>();
        if (collectible != null)
        {
            collectible.spawnZone = this;
        }
        else
        {
            Debug.LogWarning("The spawned prefab does not have a Collectible component.");
        }
    }

    Vector3 GetRandomPositionWithinZone()
    {
        return new Vector3(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
            Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
            Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
        );
    }

    public void PieceCollected()
    {
        piecesCollected++;
        
        if (currentPiece != null)
        {
            Destroy(currentPiece);
        }

        // Spawn a new coin after the current one is destroyed
        SpawnRandomPiece();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}

