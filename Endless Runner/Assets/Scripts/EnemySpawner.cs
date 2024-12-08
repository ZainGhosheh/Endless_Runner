using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Prefabs for enemies
    [SerializeField] private Transform EnemyParent; // Parent for spawned enemies
    public float enemySpawnTime = 5f; // Spawn interval for enemies
    [Range(0, 1)] public float enemySpawnTimeFactor = 0.05f; // Factor to adjust spawn interval over time
    public float enemySpeed = 2f; // Speed of spawned enemies
    [Range(0, 1)] public float enemySpeedFactor = 0.05f; // Factor to adjust speed over time
    private float timeUntilEnemySpawn;

    private float _enemySpawnTime;
    private float _enemySpeed;

    private float timeAlive;

    private void Start()
    {
        GameManager.Instance.onGameOver.AddListener(ClearEnemies);
        GameManager.Instance.onPlay.AddListener(ResetFactors);
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime;

            CalculateFactors();

            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilEnemySpawn += Time.deltaTime;

        if (timeUntilEnemySpawn >= _enemySpawnTime)
        {
            Spawn();
            timeUntilEnemySpawn = 0f;
        }
    }

    private void ClearEnemies()
    {
        foreach (Transform child in EnemyParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void CalculateFactors()
    {
        _enemySpawnTime = enemySpawnTime * Mathf.Pow(timeAlive, enemySpawnTimeFactor);
        _enemySpeed = enemySpeed * Mathf.Pow(timeAlive, enemySpeedFactor);
    }

    private void ResetFactors()
    {
        timeAlive = 1f;
        _enemySpawnTime = enemySpawnTime;
        _enemySpeed = enemySpeed;
    }

    private void Spawn()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        spawnedEnemy.transform.parent = EnemyParent;

        Rigidbody2D enemyRB = spawnedEnemy.GetComponent<Rigidbody2D>();
        enemyRB.linearVelocity = Vector2.left * _enemySpeed;
    }
}
