using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float laneWidth = 2f;
    public int laneCount = 5;
    public float spawnY = 6f;
    public float spawnInterval = 5f;

    private float timer = 0f;

    void Update()
    {
        if (!GameManager.Instance.IsRunning) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int lane = Random.Range(0, laneCount);
        float xPos = (lane - (laneCount / 2)) * laneWidth;
        Vector3 spawnPos = new Vector3(xPos, spawnY, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
