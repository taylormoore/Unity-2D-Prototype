using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour {

    public Animator animator;
    public float duration;

    private void Start()
    {
        if (Random.value < .5)
        {
            animator.SetBool(StringConstants.bulletCasingAnim, true);
        }
        else
        {
            animator.SetBool( StringConstants.bulletCasingAnim, false);
        }
        StartCoroutine( DelayedDestroy() );
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds( duration );
        Destroy( gameObject );
    }
}
