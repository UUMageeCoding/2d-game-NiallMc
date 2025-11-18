using UnityEngine;


public class DoorScript : MonoBehaviour
{
   public string scene;
    // GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        scene = "TileMap_Castle_Scene";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.sceneChange(scene);
    }
}
