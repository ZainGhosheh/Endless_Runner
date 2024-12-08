using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint; 
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 100;

    void Update()
    {
        if (Input.GetButtonDown("Space"))
        {
            Debug.Log("Attack Button Pressed");
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            Destroy(enemy.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
