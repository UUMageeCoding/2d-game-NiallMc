using UnityEngine;

public class DoorScript : MonoBehaviour
{
   public  string scene;

    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = new GameManager();
        scene = "2_Scene_2D_SideView_Tiled2";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.sceneChange(scene);
    }
}
