using UnityEngine;
using System.Collections.Generic;

public class PlayerMeleeAttack : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    Camera mainCamera;
    public GameObject damageCircle;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float rotationAmount = Utility.RotationAmount(transform.position, mouseWorldPosition);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);

        if ( Input.GetButtonDown( "Fire1") )
        {
            MeleeAttack();
        }

        //Debug.DrawLine(damageCircle.transform.position, new Vector3(damageCircle.transform.position.x + 3f, damageCircle.transform.position.y, damageCircle.transform.position.z), Color.blue, 500f);
    }


    void MeleeAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(damageCircle.transform.position, 3f);
        foreach(Collider2D collider in colliders)
        {
            if ( collider.gameObject.tag != "Player" )
            {
                collider.SendMessage("ApplyDamage", 10);
            }
        }
    }
}
