using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private static WeaponScript _instance;
    public int Damage = 3;
    public EnemyScript enemyScript;
    public bool CanAttack = false;
    public GameObject Door;

    public BossScript bossScript;


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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollided = collision.gameObject;
        if (objectCollided.CompareTag("Enemy") && (CanAttack = true))
        {
            enemyScript = objectCollided.GetComponent<EnemyScript>();
            enemyScript.TakeDamage(Damage);
            CanAttack = false;
        }
        if (objectCollided.CompareTag("Door") && (CanAttack = true) && (GameManager.Instance.keyCollected == true))
        {
            objectCollided.SetActive(false);
            CanAttack = false;

        }
        if (objectCollided.CompareTag("Boss") && (CanAttack = true))
        {
            bossScript = objectCollided.GetComponent<BossScript>();
            bossScript.TakeDamage(Damage);
            CanAttack = false;
        }
        if (objectCollided.CompareTag("Door2") && (CanAttack = true))
        {
            objectCollided.SetActive(false);
            CanAttack = false;

        }
    }
}
