using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public bool isEnemyProjectile;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
