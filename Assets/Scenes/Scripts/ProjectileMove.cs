using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public bool isEnemyProjectile;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && isEnemyProjectile)
        {
            // GAME OVER
            gameManager.DoGameOver();
        }
        else if (col.gameObject.tag == "Enemy" && !isEnemyProjectile)
        {
            // DEFEAT ENEMY
            Destroy(col.gameObject);
            gameManager.AddScore();
        }
        else
        {
            // PROJECTILE HITS ANYTHING ELSE
            Destroy(this.gameObject);
        }
    }
}
