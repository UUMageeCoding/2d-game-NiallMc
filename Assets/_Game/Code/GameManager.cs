using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    string respawnScene;
    public bool keyCollected = false;
    public bool inputs = true;


  public static GameManager Instance

  {

    get { return _instance; }

  }

    void Awake()

    {

        // Ensure only one instance exists

        if (_instance == null)

        {

            _instance = this;

            DontDestroyOnLoad(gameObject);

        }

        else

        {

            Destroy(gameObject);

        }
    }

    public void sceneChange(String scene)
    {
        SceneManager.LoadScene(scene);
    }

    public int playerhealth = 12;

    public void PlayerHealth(int damage)
    {
        //calculates player health
        playerhealth += damage;
        if (playerhealth <= 0)
        {
            //respawns the player at the start of the current scene
            respawnScene = SceneManager.GetActiveScene().name;
            Debug.Log(respawnScene);
            sceneChange(respawnScene);

            //Application.Quit();
        }
    }
    public int healthcheck()
    {
        return playerhealth;
    }

    public void EndGame()
    {
        Application.Quit();
    }
    
}
