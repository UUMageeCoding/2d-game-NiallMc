using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GuyScript : MonoBehaviour
{
  public bool guy = false;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void OnTriggerEnter2D(Collider2D collision)
  {

      Debug.Log("collided with " + collision.tag);
      if (collision.CompareTag("Player"))
      {
        Destroy(gameObject);
      }
  }
}
