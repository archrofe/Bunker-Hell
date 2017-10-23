using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public float spawnRadius = 1f;
    public int spawnAmount = 1;
    public int currentSpawn;
    public int maxSpawn = 1;
    public int spawnInterval = 1;
    private bool hasSpawned = false;

    void Start()
    {
        currentSpawn = 0;
    }

    void Update()
    {        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnBalls()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Spawned new GameObject
            int randomIndex = Random.Range(0, spawnPrefabs.Length);

            // Store randomly selected prefab
            GameObject randomPrefab = spawnPrefabs[randomIndex];

            // Spawned new GameObject
            GameObject clone = Instantiate(randomPrefab);

            // Calculate random position within sphere
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

            // Lock the Y
            randomPos.y = 1;

            // Set spawned object's position
            clone.transform.position = randomPos;            
        }
    }

    IEnumerator SpawnNow()
    {
        // run whatever is here first
        hasSpawned = true;

        // Spawn the Enemy
        SpawnBalls();

        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        // run whatever is here last
        hasSpawned = false;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            if (!hasSpawned && currentSpawn < maxSpawn)
            {
                StartCoroutine(SpawnNow());
                currentSpawn++;
            }
        }
    }
}