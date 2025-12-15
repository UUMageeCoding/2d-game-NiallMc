using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController_TopDown : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection;
    Vector3 vector3;
    Vector2 newPosition;
    public Transform Aim;
    bool isWalking = false;

    SpriteRenderer sr;
    Animator an;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        float moveY = 0f;
        float moveX = 0f;
        if (GameManager.Instance.inputs == true)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveY = 0f;
            moveX = 0f;
        }



        if ((moveX == 0 && moveY == 0) && (moveInput.x != 0 || moveInput.y != 0))
        {
            isWalking = false;
            lastMoveDirection = moveInput;
            vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = quaternion.LookRotation(Vector3.forward, vector3);

        }
        else if (moveX != 0 || moveY != 0)
        {
            isWalking = true;
        }
        // Get input
        if (GameManager.Instance.inputs == true)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveInput.x = 0;
            moveInput.y = 0;
        }

        // Normalise diagonal movement
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        
        // Move using Rigidbody2D.MovePosition
        newPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        if (isWalking)
        {
            vector3 = Vector3.left * moveInput.x + Vector3.down * moveInput.y;
            Aim.rotation = quaternion.LookRotation(Vector3.forward, vector3);
            an.SetBool("IsWalking", true);

            if ((moveInput.x < 0) && (moveInput.y == 0))
            {
                sr.flipX = true;
                an.SetBool("IsUp", false);
                an.SetBool("IsDown", false);
            }
            else if ((moveInput.x > 0) && (moveInput.y == 0))
            {
                sr.flipX = false;
                an.SetBool("IsUp", false);
                an.SetBool("IsDown", false);
            }
            else if (moveInput.y > 0)
            {
                an.SetBool("IsUp", true);
                an.SetBool("IsDown", false);
            }
            else if (moveInput.y < 0)
            {
                an.SetBool("IsDown", true);
                an.SetBool("IsUp", false);
            }
            

            
        }
        else if (isWalking == false)
        {
            an.SetBool("IsWalking", false);
            an.SetBool("IsDown", false);
            an.SetBool("IsUp", false);
        }
        rb.MovePosition(newPosition);

    }
}