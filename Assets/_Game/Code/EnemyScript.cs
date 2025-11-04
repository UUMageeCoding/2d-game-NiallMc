using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody2D rb;
    private EnemyAwarenessScript eas;
    private Vector2 pd;
    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eas = GetComponent<EnemyAwarenessScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eas.awareOfPlayer)
        {
            Vector2 newPosition = rb.position + eas.playerDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
        
    }
}
