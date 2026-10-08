using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    // THIS SCRIPT WILL MAKE THE ENEMIES MOVE SOMEWHAT ERRATICALLY WHEN NOT VIEWING THE PLAYER
    private Rigidbody rb;
    public float wanderSpeed;
    private float wanderStartAfter = 1f;
    private float wanderDelay = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //InvokeRepeating("DetermineMovement", wanderStartAfter, wanderDelay);
    }

    void DetermineMovement()
    {
        int randomMove = Random.Range(0, 1);
        switch (randomMove)
        {
            case 0:
                // Move forward
                rb.linearVelocity = transform.forward * wanderSpeed * 10f * Time.deltaTime;
                Debug.Log("Wander forward");
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Break random movement when spotting the player
            CancelInvoke();
        }
    }
}
