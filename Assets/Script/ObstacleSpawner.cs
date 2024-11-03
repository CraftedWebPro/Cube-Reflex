using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Reference to the obstacle prefab
    public int totalObstacles = 500; // Total number of obstacles to spawn before the game starts
    public float spawnRangeX = 10f; // Horizontal spawn range (left/right from center)
    public float groundLength = 10000f; // Total length of the ground in the Z direction
    public Vector3 playerStartPoint; // The starting point of the player
    public float safeZoneRadius = 10f; // Minimum distance around the player where obstacles will not spawn

    private List<GameObject> spawnedObstacles = new List<GameObject>(); // List to keep track of spawned obstacles

    void Start()
    {
        Debug.Log("Obstacle Spawner Start Method Called");
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        float groundWidth = spawnRangeX; // Use the provided spawn range X for width

        for (int i = 0; i < totalObstacles; i++)
        {
            Vector3 spawnPosition;
            bool validPosition = false;

            while (!validPosition)
            {
                float randomX = Random.Range(-groundWidth / 2, groundWidth / 2); // Centered around 0
                float randomZ = Random.Range(0, groundLength); // Random Z position from 0 to ground length

                Ray ray = new Ray(new Vector3(randomX, 100f, randomZ), Vector3.down);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Ground"))
                    {
                        spawnPosition = new Vector3(randomX, hit.point.y, randomZ);

                        if (Vector3.Distance(spawnPosition, playerStartPoint) > safeZoneRadius)
                        {
                            validPosition = true;

                            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
                            float difficultyFactor = (float)i / totalObstacles;
                            IncreaseObstacleDifficulty(newObstacle, difficultyFactor);
                            spawnedObstacles.Add(newObstacle);
                        }
                    }
                }
            }
        }
    }

    void IncreaseObstacleDifficulty(GameObject obstacle, float difficultyFactor)
    {
        // Define specific height and length increments based on the difficulty factor
        float heightMultiplier = 1 + (difficultyFactor * 0.5f); // Adjust this value for height scaling
        float lengthMultiplier = 1 + difficultyFactor; // Length scaling could also be adjusted

        // Apply the scaling to the obstacle
        obstacle.transform.localScale = new Vector3(lengthMultiplier, heightMultiplier, lengthMultiplier);
    }
}
