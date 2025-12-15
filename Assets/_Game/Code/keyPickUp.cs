using UnityEngine;

public class keyPickUp : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollided = collision.gameObject;
        if (objectCollided.CompareTag("Player") )
        {
            GameManager.Instance.keyCollected = true;
            Destroy(gameObject);
        }
    }
}
