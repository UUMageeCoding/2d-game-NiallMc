using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealthScript : MonoBehaviour
{
    public Text text;
    public int currentHealth = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (currentHealth != GameManager.Instance.healthcheck())
        {
            currentHealth = GameManager.Instance.healthcheck();
            text.text = "Health: " + currentHealth;
        }
    }

    
}
