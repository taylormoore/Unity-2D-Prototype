using UnityEngine;
using System.Collections.Generic;

public class PlayerMeleeAttack : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    public GameObject damageCircle;
    public Animator animator;

    private void Update()
    {
        animator.SetBool("isAttacking", false);
        mouseWorldPosition = PlayerInput.mousePosition;
        float rotationAmount = Utility.RotationAmount(transform.position, mouseWorldPosition);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);

        if ( Input.GetButtonDown( "Fire1") )
        {
            MeleeAttack();
        }
    }


    void MeleeAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(damageCircle.transform.position, 3f);
        foreach(Collider2D collider in colliders)
        {
            if ( collider.gameObject.tag != "Player Interaction Collider" )
            {
                collider.SendMessage("ApplyDamage", 10);
            }
        }

        animator.SetBool( "isAttacking", true );
    }
}
