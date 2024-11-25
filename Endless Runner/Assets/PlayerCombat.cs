using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;
    void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            Debug.Log("Attack Button Pressed");
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
