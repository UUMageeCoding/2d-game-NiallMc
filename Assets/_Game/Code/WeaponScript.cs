using UnityEngine;

public class WeaponScript : MonoBehaviour
{
        private static WeaponScript _instance;
    public int Damage = 3;
    public EnemyScript enemyScript;
    public bool CanAttack = true;


  public static WeaponScript Instance

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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (CanAttack = true))
        {
            enemyScript.TakeDamage(Damage);
            CanAttack = false;
        }
    }
}
