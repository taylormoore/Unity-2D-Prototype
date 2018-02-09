using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public float attackRange;
    public float attackDamage;
    public float movementSpeed;

    protected GameObject nearestPlayer = null;
    protected  bool inRangeToAttack = false;

    private void Start ()
    {
        // Give enemies attack range some randomness
        attackRange = Random.Range ( attackRange * 0.95f, attackRange * 1.05f );
    }
    
    void FixedUpdate () {
        if ( nearestPlayer == null )
        {
            nearestPlayer = PlayerManagement.GetNearestPlayer ( transform.position );

            if ( nearestPlayer == null )
            {
                Debug.LogWarning ( gameObject.name + " could not find a player!" );
                return;
            }
        }
        else
        {
            inRangeToAttack = Vector2.Distance ( nearestPlayer.transform.position, transform.position ) < attackRange;
        }
    }
}
