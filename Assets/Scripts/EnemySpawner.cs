using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTimer;

    private float timer;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            SpawnEnemies();
            timer = 0f;
        }
    }

    void SpawnEnemies()
    {
        int numberOfEnemies = Random.Range(1, 100);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
