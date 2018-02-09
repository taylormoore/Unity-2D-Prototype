using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : BaseEnemy
{

    public float attackCooldown;
    float lastAttack;
    // Update is called once per frame
    void Update ()
    {
        if (nearestPlayer != null)
        {
            if ( inRangeToAttack )
            {
                if ( Time.time > lastAttack + attackCooldown )
                {
                    nearestPlayer.SendMessage ( "ApplyDamage", attackDamage );
                    lastAttack = Time.time;
                }
                
            }
            else
            {
                float speed = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards ( transform.position, nearestPlayer.transform.position, speed );
            }
        }
    }
}
