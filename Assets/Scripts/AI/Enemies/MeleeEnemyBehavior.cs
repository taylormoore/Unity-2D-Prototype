using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : BaseEnemy
{
    public Animator[] spriteAndShadow;
    public float attackCooldown;
    float lastAttack;

    bool isAttacking;

    int idleHash;
    int movingHash;
    int attackingHash;

    private new void Start ()
    {
        base.Start ();
        idleHash = Animator.StringToHash ( StringConstants.ShouldIdle );
        movingHash = Animator.StringToHash ( StringConstants.ShouldMove );
        attackingHash = Animator.StringToHash ( StringConstants.ShouldAttack );
    }

    new void FixedUpdate ()
    {
        base.FixedUpdate ();
        if ( nearestPlayer != null )
        {
            if ( !isPlayerDetected )
            {
                if ( currentState != CurrentState.idle )
                {
                    currentState = CurrentState.idle;
                    StartIdle ();
                }

            }
            else if ( !inRangeToAttack && !isAttacking )
            {
                bool shouldFaceRight = IsPlayerOnRightSide ();
                foreach ( SpriteRenderer spriteRenderer in spriteRenderers )
                {
                    spriteRenderer.flipX = !shouldFaceRight;
                }

                if ( currentState != CurrentState.moving )
                {
                    currentState = CurrentState.moving;
                    StartMove ();
                }

                float speed = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards ( transform.position, nearestPlayer.transform.position, speed );
            }
            else
            {
                if ( Time.time > lastAttack + attackCooldown )
                {
                    isAttacking = true;
                    if ( currentState != CurrentState.attacking )
                    {
                        currentState = CurrentState.attacking;
                        StartAttack ();
                    }

                    lastAttack = Time.time;
                }
            }
        }
    }

    public void FinishedAttacking()
    {
        isAttacking = false;
    }

    public void AttackPlayer ()
    {
        nearestPlayer.SendMessage ( "ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver );
    }

    public void StartIdle ()
    {
        foreach ( Animator animator in spriteAndShadow )
        {
            animator.SetBool ( attackingHash, false );
            animator.SetBool ( movingHash, false );
            animator.SetBool ( idleHash, true );
        }
    }

    public void StartMove ()
    {
        foreach ( Animator animator in spriteAndShadow )
        {
            animator.SetBool ( attackingHash, false );
            animator.SetBool ( movingHash, true );
            animator.SetBool ( idleHash, false );
        }
    }

    public void StartAttack ()
    {
        foreach ( Animator animator in spriteAndShadow )
        {
            animator.SetBool ( attackingHash, true );
            animator.SetBool ( movingHash, false );
            animator.SetBool ( idleHash, false );
        }
    }
}
