using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float enemySpawnTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        Debug.Log("Start spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
