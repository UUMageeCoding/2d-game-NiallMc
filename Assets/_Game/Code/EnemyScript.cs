using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float health, maxHealth = 12f;
    [SerializeField] private bool moveX, moveY;
    [SerializeField]public int damage = -3;

    private Rigidbody2D rb;
    private EnemyAwarenessScript eas;
    private Vector2 pd;

    public float attackTimer = 0f;
    public float attackLenght = 5f;

    SpriteRenderer sr;
    Animator an;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eas = GetComponent<EnemyAwarenessScript>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (eas.awareOfPlayer)
        {
            Vector2 newPosition = rb.position + eas.playerDirection * moveSpeed * Time.fixedDeltaTime;
            if (newPosition == rb.position)
            {
                an.SetBool("IsWalking", false);
            }
            else
            {
                an.SetBool("IsWalking", true);
            }
            if (newPosition.y > rb.position.y)
            {
                an.SetBool("IsUp", true);
                an.SetBool("IsDown", false);
            }
            else if (newPosition.y < rb.position.y)
            {
                an.SetBool("IsUp", false);
                an.SetBool("IsDown", true);
            }
            if ((newPosition.x < 0) && (newPosition.y == 0))
            {
                sr.flipX = true;
            }
            else if ((newPosition.x > 0) && (newPosition.y == 0))
            {
                sr.flipX = false;
            }

            rb.MovePosition(newPosition);
        }
        else if (eas.awareOfPlayer == false)
        {
            an.SetBool("IsWalking", false);
            an.SetBool("IsDown", false);
            an.SetBool("IsUp", false);
        }

        if (eas.attackPlayer)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackLenght)
            {
                GameManager.Instance.PlayerHealth(damage);
                attackTimer = 0;
            }
        }

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }
    
}
