using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator[] animators;

    public SpriteRenderer[] spriteAndShadow;

    Vector3 mousePosition;
    Vector3 playerPosition;

    private void FixedUpdate()
    {
        if ( PlayerInput.movementHorizontal > .1f || PlayerInput.movementHorizontal < -.1f )
        {
            foreach(Animator animator in animators)
            {
                animator.SetBool( "isMoving", true);
            }
        }
        else if (PlayerInput.movementVertical > .1f || PlayerInput.movementVertical < -.1f)
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("isMoving", false);
            }
        }

        mousePosition = PlayerInput.mousePosition;
        playerPosition = gameObject.transform.position;
        if ( mousePosition.x - gameObject.transform.position.x < 0 )
        {
            FlipSprites ( true );
        }
        else
        {
            FlipSprites ( false );
        }
    }

    void FlipSprites( bool facingRight )
    {
        foreach (SpriteRenderer sprite in spriteAndShadow)
        {
            sprite.flipX = facingRight;
        }
    }
}
