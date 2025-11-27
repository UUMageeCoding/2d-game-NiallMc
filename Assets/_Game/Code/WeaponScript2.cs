using UnityEngine;

public class WeaponScript2 : MonoBehaviour
{
    public GameObject Door;
    public int Damage = 3;
    public EnemyScript enemyScript;
    public bool CanAttack = true;
    void Start()
    {
        enemyScript = FindAnyObjectByType<EnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (CanAttack = true))
        {
            enemyScript.TakeDamage(Damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Door") && (CanAttack = true))
        {
            Door.SetActive(false);
        }
    }
}
