using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour {

    public float attackRange;
    public float attackDamage;
    public float movementSpeed;
    public GameObject[] droppables;
    public int maxHealth;
    public Image healthbar;
    public SpriteRenderer[] spriteRenderers;

    protected GameObject nearestPlayer = null;
    protected float distanceToPlayer;
    protected bool inRangeToAttack = false;
    protected bool isPlayerDetected = false;
    protected float enemyDetectionDistanceCurrent = 50f;

    float health;
    protected bool deathCalled;

    protected enum CurrentState
    {
        idle,
        moving,
        attacking,
        shooting
    };

    protected CurrentState currentState;

    protected void Start ()
    {
        // Give enemies attack range some randomness
        attackRange = Random.Range ( attackRange * 0.95f, attackRange * 1.05f );
        health = maxHealth;
        Debug.Assert ( attackRange <= enemyDetectionDistanceCurrent, "Attack range must be less than or equal to enemyDetectionDistance!" );
    }
    
    protected void FixedUpdate () {
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
            distanceToPlayer = Vector2.Distance ( nearestPlayer.transform.position, transform.position );
            inRangeToAttack = distanceToPlayer < attackRange;
            isPlayerDetected = distanceToPlayer < enemyDetectionDistanceCurrent;
        }
    }

    public void ApplyDamage ( int amount )
    {
        health -= amount;
        healthbar.fillAmount = health / maxHealth;

        if ( health <= 0 )
        {
            Death ();
        }
    }

    //public void ApplyDamageAsPercentage ( float percentage )
    //{
    //    Debug.Assert ( percentage <= 1, "Damage as a percentage must be <= 1." );
    //    health *= ( 1 - percentage );
    //}

    /* This function handles all enemy deaths.
     * TODO: Make it not actually destroy, but instead put them back in the enemy-pool. */
    public void Death()
    {
        deathCalled = true;
        if (droppables.Length == 0)
        {
            return;
        }

        DropItem ();

        Destroy ( gameObject );
    }

    /* TODO: Again, eventually maybe don't instantiate an item here. */ 
    protected void DropItem()
    {
        int dropIndex = Random.Range ( 0, droppables.Length );

        // TODO: a little offset off of enemy.
        Instantiate ( droppables[ dropIndex ], transform.position, Quaternion.identity );
    }

    protected bool IsPlayerOnRightSide ()
    {
        return Vector2.Dot ( transform.right, nearestPlayer.transform.position ) > Vector2.Dot ( transform.right, transform.position );
    }

    private void OnDestroy ()
    {
        //if (!deathCalled)
        //{
        //    Debug.LogError ( "You didn't call death() on a dying enemy! And if you did, make sure you remember to set deathcalled = true" );
        //}
    }
}
