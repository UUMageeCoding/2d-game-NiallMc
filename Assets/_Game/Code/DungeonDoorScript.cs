using UnityEngine;
using UnityEngine.UIElements;

public class DungeonDoorScript : MonoBehaviour
{
    public  string scene;
    //GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = "TileMap_Castle_dungeon_Scene";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.sceneChange(scene);
    }
}
