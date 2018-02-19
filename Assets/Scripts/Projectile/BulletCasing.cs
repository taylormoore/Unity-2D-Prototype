using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour {

    public Animator animator;

    private void Start()
    {
        if (Random.value < .5)
        {
            animator.SetBool("animChoice", true);
        }
        else
        {
            animator.SetBool("animChoice", false);
        }
    }
}
