using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        
        float angle = Utility.RotationAmount(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        spriteRenderer.flipY = angle > 90 || angle < -90;
    }
}
