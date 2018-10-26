using UnityEngine;

public class ProjectileEnemyBehavior : BaseEnemy
{
    public float attackCooldown;
    public GameObject projectile;
    public GameObject projectileSpawn;
    float lastAttack;

    bool isAttacking;

    int idleHash;
    int movingHash;
    int attackingHash;

    private new void Start()
    {
        base.Start();
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();

        if (nearestPlayer != null)
        {
            if (!isPlayerDetected)
            {
                if (currentState != CurrentState.idle)
                {
                    currentState = CurrentState.idle;
                }

            }
            else if (!inRangeToAttack && !isAttacking)
            {
                bool shouldFaceRight = IsPlayerOnRightSide();
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.flipX = !shouldFaceRight;
                }

                if (currentState != CurrentState.moving)
                {
                    currentState = CurrentState.moving;
                }

                float speed = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed);
            }
            else
            {
                if (Time.time > lastAttack + attackCooldown)
                {
                    isAttacking = true;
                    if (currentState != CurrentState.attacking)
                    {
                        currentState = CurrentState.attacking;
                        ShootProjectile();
                        FinishedAttacking();
                        lastAttack = Time.time;
                    }
                }
            }
        }
    }

    public void FinishedAttacking()
    {
        isAttacking = false;
        currentState = CurrentState.idle;
    }

    public void ShootProjectile()
    {
        Instantiate(projectile, transform.position, projectileSpawn.transform.rotation);
    }
}
