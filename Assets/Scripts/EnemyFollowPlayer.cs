using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private GameObject player;
    public float enemySpeed;
    private Rigidbody enemyRb;
    private Vector3 distanceToPlayer;
    [SerializeField] private float minDistanceToPlayer;
    private SphereCollider aggroRange;
    private bool isAggro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        aggroRange = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAggro)
        {
            MoveTowardPlayer();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Move toward player
            isAggro = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Stop moving toward player
            isAggro = false;
        }
    }

    void MoveTowardPlayer()
    {
        distanceToPlayer = transform.position - player.transform.position;
        if (distanceToPlayer.magnitude > minDistanceToPlayer)
        {
            // Move toward player
            Debug.Log("CAN MOVE TOWARD PLAYER");
            Vector3 directionToMove = -distanceToPlayer.normalized;
            enemyRb.AddForce(directionToMove.x * enemySpeed, 0f, directionToMove.z * enemySpeed, ForceMode.Force);
        }
        else
        {
            // Too close to player to move
            Debug.Log("CANNOT MOVE TOWARD PLAYER");
        }
    }
}
