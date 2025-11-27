using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    string respawnScene;


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

    public int playerhealth = 10;

    public void PlayerHealth(int damage)
    {
        playerhealth += damage;
        if (playerhealth <= 0)
        {
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
    
}
