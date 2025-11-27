using UnityEditor.UIElements;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public GameObject melee;
    bool isAttacking = false;
    float attackDuration = 1f;
    float attackTimer = 0f;

    public Transform Aim;
    public GameObject bullet;
    public float fireForce = 10f;
    float shootCooldown = 0.25f;
    float shootTimer = 0.5f;
    WeaponScript weaponScript;


    void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
        }
        if (attackTimer >= attackDuration)
        {
            melee.SetActive(false);
            isAttacking = false;
            WeaponScript.Instance.CanAttack = true;
        }
        shootTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0))
        {
            if (isAttacking == false)
            {
                OnAttack();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButton(1))
        {
            if (isAttacking == false)
            {
                OnShoot();
            }
            
        }
        
    }

    void OnAttack()
    {
        melee.SetActive(true);
        isAttacking = true;

    }
    void OnShoot()
    {
        if (shootTimer > shootCooldown)
        {
            shootTimer = 0;
            GameObject intBullet = Instantiate(bullet, Aim.position, Aim.rotation);
            intBullet.GetComponent<Rigidbody2D>().AddForce(-Aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet, 2f);
        }
    }
}
