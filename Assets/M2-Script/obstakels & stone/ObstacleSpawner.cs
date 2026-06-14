using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{[Header("Obstacles")]
    public GameObject[] obstacles;
    public float spawnInterval = 2f;
    public float spawnRangeX = 10f;
    public float spawnDistance = 20f;

    [Header("Meteors")]
    public GameObject[] meteors;
    public float meteorInterval = 1f;
    public float meteorSpawnHeight = 15f;

    public Transform player;

    private float obstacleTimer;
    private float meteorTimer;

    void Update()
    {
        if (player == null) return; 

        obstacleTimer += Time.deltaTime;
        if (obstacleTimer >= spawnInterval)
        {
            SpawnObstacle();
            obstacleTimer = 0f;
        }

        meteorTimer += Time.deltaTime;
        if (meteorTimer >= meteorInterval)
        {
            SpawnMeteor();
            meteorTimer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstacles.Length == 0) return;

        int randomIndex = Random.Range(0, obstacles.Length);
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, player.position.y, player.position.z + spawnDistance);

        Instantiate(obstacles[randomIndex], spawnPos, Quaternion.identity);
    }

    void SpawnMeteor()
    {
        if (meteors.Length == 0) return;

        int randomIndex = Random.Range(0, meteors.Length);
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        
        Vector3 spawnPos = new Vector3(
            randomX, 
            player.position.y + meteorSpawnHeight, 
            player.position.z + spawnDistance
        );

        Instantiate(meteors[randomIndex], spawnPos, Quaternion.identity);
    }
}