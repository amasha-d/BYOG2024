using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public Transform player;        // Reference to the player
    public int swarmSize = 10;      // Number of enemies to spawn
    public float spawnRadius = 5f;  // Radius around the spawn point for enemy positions
    public float followSpeed = 2f;  // Speed at which enemies follow the player

    private List<GameObject> enemySwarm;
    void Start()
    {
        enemySwarm = new List<GameObject>();
        SpawnSwarm();
    }

    void Update()
    {
        FollowPlayer();
    }
    void SpawnSwarm()
    {
        for (int i = 0; i < swarmSize; i++)
        {
            // Generate a random position within a sphere around the player
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection.y = 0; // Ensure enemies are at ground level (or 2D plane)

            Vector3 spawnPos = player.position + randomDirection;

            // Randomize enemy rotation
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // Instantiate the enemy at the random position with random rotation
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, randomRotation);
            enemySwarm.Add(enemy);
        }
    }

    // Makes the swarm follow the player
    void FollowPlayer()
    {
        foreach(GameObject enemy in enemySwarm)
        {
            if (enemy != null)
            {
                Vector3 direction = (player.position - enemy.transform.position).normalized;
                enemy.transform.position += direction * followSpeed * Time.deltaTime;
            }
        }
    }
}

