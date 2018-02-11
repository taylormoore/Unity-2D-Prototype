using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : BaseEnemy
{
    public Animator animator;
    public float attackCooldown;
    float lastAttack;

    void Update ()
    {
        if (nearestPlayer != null)
        {
            if (!isPlayerDetected)
            {
                StartIdle ();
            }
            else if (!inRangeToAttack)
            {
                StartMove ();
                float speed = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards ( transform.position, nearestPlayer.transform.position, speed );
            }
            else
            {
                if ( Time.time > lastAttack + attackCooldown )
                {
                    StartAttack ();
                    lastAttack = Time.time;
                }
            }
        }
    }

    public void AttackPlayer()
    {
        nearestPlayer.SendMessage ( "ApplyDamage", attackDamage );
    }

    public void StartIdle ()
    {
        animator.SetBool ( StringConstants.ShouldAttack, false );
        animator.SetBool ( StringConstants.ShouldMove, false );
        animator.SetBool ( StringConstants.ShouldIdle, true );
    }

    public void StartMove ()
    {
        animator.SetBool ( StringConstants.ShouldAttack, false );
        animator.SetBool ( StringConstants.ShouldMove, true );
        animator.SetBool ( StringConstants.ShouldIdle, false );
    }

    public void StartAttack ()
    {
        animator.SetBool ( StringConstants.ShouldAttack, true );
        animator.SetBool ( StringConstants.ShouldMove, false );
        animator.SetBool ( StringConstants.ShouldIdle, false );
    }
}
