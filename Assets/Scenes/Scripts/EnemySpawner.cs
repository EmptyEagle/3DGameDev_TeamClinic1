using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float enemyStartSpawnTime = 15f;
    private float enemySpawnTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        Debug.Log("Start spawner");
        InvokeRepeating("SpawnEnemy", enemyStartSpawnTime, enemySpawnTime);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
