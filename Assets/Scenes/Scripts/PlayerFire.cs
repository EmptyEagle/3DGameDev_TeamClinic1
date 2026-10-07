using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour
{
    public GameObject playerOrientation;
    public GameObject projectilePrefab;
    public float playerFireRate;
    private bool canFire;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 spawnLocation = transform.position + (playerOrientation.transform.forward * 0.5f);
        Instantiate(projectilePrefab, spawnLocation, playerOrientation.transform.rotation);
        canFire = false;
        StartCoroutine(FireCooldown());
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(playerFireRate);
        canFire = true;
    }
}
