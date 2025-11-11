using Unity.VisualScripting;
using UnityEngine;

public class weeEnemy : MonoBehaviour
{
    public Transform playerPosition;
    Vector2 directionToPlayer;
    float moveSpeed = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            directionToPlayer = (playerPosition.position - transform.position).normalized;
        }

        if (playerPosition.position - transform.position != Vector3.zero) MoveToPlayer(moveSpeed);
    }
    public void MoveToPlayer(float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
    }
}
