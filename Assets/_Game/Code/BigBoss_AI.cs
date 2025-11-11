using UnityEngine;

public enum BigBossState
{
    idle,
    attacking
}
    
public class BigBoss_AI : MonoBehaviour
{
    public Transform playerPosition;
    int hysteresis = 2;
    SpriteRenderer spriteRenderer;
    public int attackDistance; 
    public BigBossState currentState = BigBossState.idle;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);

        switch (currentState)
        {
            case BigBossState.idle:
                if (distanceToPlayer < attackDistance)
                {
                    currentState = BigBossState.attacking;
                    spriteRenderer.color = Color.red;
                }
                break;

            case BigBossState.attacking:
                if (distanceToPlayer > attackDistance + hysteresis)
                {
                    currentState = BigBossState.idle;
                    spriteRenderer.color = Color.white;
                }
                break;
        }
    }
}
