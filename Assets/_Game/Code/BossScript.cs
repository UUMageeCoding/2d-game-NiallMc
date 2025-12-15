using UnityEngine;


public class BossScript : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float health, maxHealth = 20f;
    [SerializeField] public int damage = -4;
    private Rigidbody2D rb;
    private EnemyAwarenessScript eas;
    SpriteRenderer sr;
    Animator an;
    public float attackTimer = 0f;
    public float attackLenght = 5f;

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
                an.SetBool("IsUp", false);
                an.SetBool("IsDown", true);
            }
            else if ((newPosition.x > 0) && (newPosition.y == 0))
            {
                sr.flipX = false;
                an.SetBool("IsUp", false);
                an.SetBool("IsDown", true);
            }

            rb.MovePosition(newPosition);
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
