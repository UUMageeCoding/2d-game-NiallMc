using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int Playerhealth;
    public bool isDead = false;
    
    //public GameManagerScript gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Playerhealth = MaxHealth;
    }
    public void TakeDamage (int damage)
    {
        Playerhealth -= damage;
        if (Playerhealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
            //gameObject.setactive(false);
            //gameManager.gameOver();
            Debug.Log("Dead");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
