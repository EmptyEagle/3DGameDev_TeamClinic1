using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float enemyFireRate;
    private bool withinFireRange;
    private bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        withinFireRange = false;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (withinFireRange)
        {
            StartCoroutine(Fire());
        }
        else
        {
            StopCoroutine(Fire());
            canFire = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Within fire range");
            // Start firing
            withinFireRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Leaving fire range");
            // Stop firing
            withinFireRange = false;
        }
    }

    IEnumerator Fire()
    {
        if (canFire)
        {
            Debug.Log("Firing");
            Vector3 spawnLocation = transform.position + (transform.forward * 0.5f);
            Instantiate(projectilePrefab, spawnLocation, transform.rotation);
            canFire = false;
            yield return new WaitForSeconds(enemyFireRate);
            canFire = true;
        }
    }
}
