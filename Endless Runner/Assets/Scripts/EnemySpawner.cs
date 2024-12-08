/*
 * Code Artifact Name: EnemySpawner
 * Description: Manages the spawning of enemies dynamically, adjusting spawn time and speed over time.
 * Programmer's Name: Ghosheh Zain, Mohamed Abdulahi, Husien Mahgoub, Alonge Olufewa
 * Date Created: 10/26/24
 * Revision History:
 *   - 10/26/24: Initial creation of the script by Mahgoub Husien.
 * Preconditions:
 *   - Enemy prefabs must be assigned in the Unity Inspector.
 *   - GameManager must implement onPlay and onGameOver events.
 * Acceptable Input Values:
 *   - Valid enemy prefabs with Rigidbody2D components.
 * Unacceptable Input Values:
 *   - Null or unassigned enemy prefabs or parent objects.
 * Postconditions:
 *   - Spawns enemies at dynamically calculated intervals.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if required references are not assigned.
 * Side Effects:
 *   - Instantiates enemy GameObjects into the scene.
 * Invariants:
 *   - Enemy speed and spawn interval adjust according to time alive.
 * Known Faults:
 *   - Does not handle excessive numbers of spawned enemies.
 */

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs.
    [SerializeField] private Transform enemyParent; // Parent object for spawned enemies.
    public float enemySpawnTime = 5f; // Initial spawn time interval.
    [Range(0, 1)] public float enemySpawnTimeFactor = 0.05f; // Factor for adjusting spawn time over time.
    public float enemySpeed = 2f; // Initial enemy speed.
    [Range(0, 1)] public float enemySpeedFactor = 0.05f; // Factor for adjusting speed over time.

    private float timeUntilEnemySpawn; // Tracks time until the next spawn.
    private float timeAlive; // Tracks the total time the game has been active.

    private void Start()
    {
        // Add listeners for game events.
        GameManager.Instance.onGameOver.AddListener(ClearEnemies);
        GameManager.Instance.onPlay.AddListener(ResetFactors);
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime; // Increment time alive.

            SpawnLoop(); // Check if it’s time to spawn an enemy.
        }
    }

    private void SpawnLoop()
    {
        timeUntilEnemySpawn += Time.deltaTime; // Increment the spawn timer.

        if (timeUntilEnemySpawn >= enemySpawnTime) // Check if the timer exceeds the spawn interval.
        {
            Spawn(); // Spawn a new enemy.
            timeUntilEnemySpawn = 0f; // Reset the spawn timer.
        }
    }

    private void ClearEnemies()
    {
        foreach (Transform child in enemyParent)
        {
            Destroy(child.gameObject); // Destroy all enemy GameObjects under the parent.
        }
    }

    private void Spawn()
    {
        // Select a random enemy prefab to spawn.
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity); // Instantiate enemy.
        spawnedEnemy.transform.parent = enemyParent; // Set the enemy's parent transform.

        Rigidbody2D enemyRB = spawnedEnemy.GetComponent<Rigidbody2D>();
        enemyRB.velocity = Vector2.left * enemySpeed; // Assign speed to the enemy.
    }
}
