using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAwarenessScript : MonoBehaviour
{
    [SerializeField] private float PlayerAwarenessDistance;
    [SerializeField] private Transform player;
    [SerializeField] public float playerAttackDistace;
    public bool awareOfPlayer;
    public bool attackPlayer;
    public Vector2 playerDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerController_TopDown>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        playerDirection = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= PlayerAwarenessDistance)
        {
            awareOfPlayer = true;
            //Debug.Log("the enemy sees u");
            //Debug.Log(enemyToPlayerVector.magnitude);

        }
        else
        {
            awareOfPlayer = false;
        }
        if (enemyToPlayerVector.magnitude <= playerAttackDistace)
        {
            attackPlayer = true;
        }
        else
        {
            attackPlayer = false;
        }
    }
}
