using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator[] animators;

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
    }
}
