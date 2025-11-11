using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int Damage = 3;
    public EnemyScript enemyScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyScript.TakeDamage(Damage);

        }

    }
}
