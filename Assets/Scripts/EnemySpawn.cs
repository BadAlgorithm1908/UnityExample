using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int numEnemies = 50;
    public GameObject prefab;
    public Transform playerTransform; // Drag your Player object here in the Inspector

    public float spawnRadius = 20f;

    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            makeAChild();
        }
    }

    void Update()
    {
        if (transform.childCount < numEnemies)
        {
            makeAChild();
        }
    }

    void makeAChild()
    {
        // Fallback in case the player doesn't exist or is destroyed
        Vector3 centerPosition = playerTransform != null ? playerTransform.position : Vector3.zero;

        // Spawn within a random offset around the player
        float childX = centerPosition.x + Random.Range(-spawnRadius, spawnRadius);
        float childZ = centerPosition.z + Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPosition = new Vector3(childX, 10f, childZ);

        GameObject newChild = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newChild.transform.SetParent(transform); // Parents enemy to the Spawner, not the Player
    }
}