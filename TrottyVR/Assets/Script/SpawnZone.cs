using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;  // Tableau de prefabs pour les pièces
    [SerializeField] private Vector3 zoneSize;

    private int piecesSpawned = 0; // Nombre de pièces apparues
    private GameObject currentPiece;

    void Start()
    {
        SpawnRandomPiece();
    }

    void SpawnRandomPiece()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("Aucun prefab n'est assigné au script SpawnZone.");
            return;
        }

        if (piecesSpawned >= 5)
        {
            Debug.Log("Toutes les pièces ont été apparues. Arrêt de l'apparition.");
            return; // Arrête l'apparition si 5 pièces ont été apparues
        }

        int randomIndex = Random.Range(0, prefabs.Length);  // Sélectionne un prefab aléatoire
        GameObject selectedPrefab = prefabs[randomIndex];

        currentPiece = Instantiate(selectedPrefab);
        currentPiece.transform.position = new Vector3(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
            Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2),
            Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2)
        );

        // Assigner ce script comme zone de spawn à la pièce pour qu'elle puisse appeler la fonction PieceCollected
        currentPiece.GetComponent<Collectible>().spawnZone = this;

        piecesSpawned++; // Incrémente le nombre de pièces apparues
    }

    public void PieceCollected()
    {
        if (currentPiece != null)
        {
            Destroy(currentPiece);
            GameManager.Instance.AddCoin(); // Mise à jour du compteur de pièces
            SpawnRandomPiece();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
