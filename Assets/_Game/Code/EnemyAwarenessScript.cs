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
        //finds the player location via the player controller script
        player = Object.FindFirstObjectByType<PlayerController_TopDown>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        // finds the player durection an range 
        Vector2 enemyToPlayerVector = player.position - transform.position;
        playerDirection = enemyToPlayerVector.normalized;
        
        //checks distance to player
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
