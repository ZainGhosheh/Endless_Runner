/*
 * Code Artifact Name: Spawner
 * Description: Spawns obstacles dynamically at regular intervals, adjusting speed and spawn rate over time.
 * Programmer's Name: Zain Ghosheh
 * Date Created: 
 * Revision History:
 *   - [Date 1]: Initial creation of the script by [Author's Name].
 * Preconditions:
 *   - Obstacle prefabs must be assigned in the Unity Inspector.
 *   - GameManager must be configured to trigger onPlay and onGameOver events.
 * Acceptable Input Values:
 *   - Obstacle prefabs must include valid Rigidbody2D components.
 * Unacceptable Input Values:
 *   - Null references for obstacleParent or obstaclePrefabs.
 * Postconditions:
 *   - Spawns obstacles at dynamically adjusted intervals.
 * Return Values:
 *   - None (void methods).
 * Error and Exception Conditions:
 *   - NullReferenceException if obstacleParent or prefabs are not assigned.
 * Side Effects:
 *   - Instantiates new GameObjects into the scene.
 * Invariants:
 *   - Obstacles always move at a positive speed.
 * Known Faults:
 *   - Does not handle performance issues with excessive obstacles.
 */

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs; // Array of obstacle prefabs.
    [SerializeField] private Transform obstacleParent; // Parent transform for spawned obstacles.
    public float obstacleSpawnTime = 3f; // Initial spawn interval.
    [Range(0, 1)] public float obstacleSpawnTimeFactor = 0.1f; // Factor to adjust spawn interval over time.
    public float obstacleSpeed = 4f; // Initial speed of obstacles.
    [Range(0, 1)] public float obstacleSpeedFactor = 0.1f; // Factor to adjust obstacle speed over time.

    private float timeUntilObstacleSpawn; // Tracks time until the next spawn.
    private float timeAlive; // Tracks time since the game started.

    private void Start()
    {
        // Listen for game events to reset or clear obstacles.
        GameManager.Instance.onGameOver.AddListener(ClearObstacles); 
        GameManager.Instance.onPlay.AddListener(ResetFactors); 
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime; // Increment the alive time.
            SpawnLoop(); // Handle obstacle spawning.
        }
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime; // Increment spawn timer.

        if (timeUntilObstacleSpawn >= obstacleSpawnTime) // Check if it's time to spawn.
        {
            Spawn(); // Spawn a new obstacle.
            timeUntilObstacleSpawn = 0f; // Reset the spawn timer.
        }
    }

    private void ClearObstacles()
    {
        foreach (Transform child in obstacleParent) 
        {
            Destroy(child.gameObject); // Destroy all child objects under obstacleParent.
        }
    }

    private void Spawn()
    {
        // Select a random obstacle prefab to spawn.
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity); // Instantiate obstacle.
        spawnedObstacle.transform.parent = obstacleParent; // Parent the obstacle under obstacleParent.

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>(); 
        obstacleRB.velocity = Vector2.left * obstacleSpeed; // Assign speed to the obstacle.
    }
}
