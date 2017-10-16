using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [Header("Movement")]
    public Transform boatPos1;
    public Transform boatPos2;
    public float boatSpeed;
    public bool boatOnBeach;

    [Header("Spawner")]
    public GameObject[] spawnPrefabs;
    public float spawnRadius = 1f;
    public int spawnAmount = 1;
    public float spawnInterval = 1f;
    public bool hasSpawned = false;

    // Use this for initialization
    void Start()
    {
        boatOnBeach = false;
    }

    // Update is called once per frame
    void Update()
    {
        LeftAndRightMovement();
        SpawnLocation();
    }

    #region Movement
    void LeftAndRightMovement()
    {
        if (boatOnBeach == false)
        {
            GoRight();

            if (transform.position == boatPos2.position)
            {
                boatOnBeach = true;
            }
        }

        if (boatOnBeach == true)
        {
            GoLeft();

            if (transform.position == boatPos1.position)
            {
                boatOnBeach = false;
            }
        }
    }

    void GoRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, boatPos2.position, boatSpeed * Time.deltaTime);
    }

    void GoLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, boatPos1.position, boatSpeed * Time.deltaTime);
    }
    #endregion

    #region Spawner
    void SpawnEnemy()
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

            // Cancel out the Z
            randomPos.z = 0;

            // Set spawned object's position
            clone.transform.position = randomPos;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    void SpawnLocation()
    {
        if (transform.position == boatPos2.position)
        {
            Debug.Log("SpawnLocation reached");
            SpawnNow();
        }
    }

    IEnumerator SpawnNow()
    {
        // run whatever is here first
        hasSpawned = true;

        // Spawn the bullet
        SpawnEnemy();

        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        // run whatever is here last
        hasSpawned = false;
    }
    #endregion
}
