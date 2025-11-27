using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private static WeaponScript _instance;
    public int Damage = 3;
    public EnemyScript enemyScript;
    public bool CanAttack = false;
    public GameObject Door;


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
    void Start()
    {
        enemyScript = FindAnyObjectByType<EnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (CanAttack = true))
        {
            enemyScript.TakeDamage(Damage);
            CanAttack = false;
        }
        if (collision.CompareTag("Door") && (CanAttack = true))
        {
            Door.SetActive(false);
            CanAttack = false;

        }
    }
}
