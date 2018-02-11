using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : BaseEnemy
{
    public Animator[] animators;
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
        nearestPlayer.SendMessage ( "ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver );
    }

    public void StartIdle ()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool(StringConstants.ShouldAttack, false);
            animator.SetBool(StringConstants.ShouldMove, false);
            animator.SetBool(StringConstants.ShouldIdle, true);
        }
    }

    public void StartMove ()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool(StringConstants.ShouldAttack, false);
            animator.SetBool(StringConstants.ShouldMove, true);
            animator.SetBool(StringConstants.ShouldIdle, false);
        }
    }

    public void StartAttack ()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool(StringConstants.ShouldAttack, true);
            animator.SetBool(StringConstants.ShouldMove, false);
            animator.SetBool(StringConstants.ShouldIdle, false);
        }
    }
}
