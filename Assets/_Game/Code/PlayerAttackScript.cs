using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public GameObject melee;
    bool isAttacking = false;
    float attackDuration = 0.9f;
    float attackTimer = 0f;


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
        }
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (isAttacking == false)
            {
                onAttack();
            }

        }
    }

    void onAttack()
    {
        melee.SetActive(true);
        isAttacking = true;

    }
}
