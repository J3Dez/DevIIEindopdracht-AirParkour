using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float spawnInterval = 2f;
    public float spawnRangeX = 10f;
    public float spawnDistance  = 20f;

    public Transform player;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            spawnObstacle();
            timer = 0f;
        }
    }

    void spawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        float randemX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randemX, player.position.y, player.position.z + spawnDistance );

        GameObject spawned = Instantiate(obstacles[randomIndex], spawnPos, Quaternion.identity);        
        Debug.Log($"Obstacle spawned: {spawned.name} at position {spawnPos}");
    }
}