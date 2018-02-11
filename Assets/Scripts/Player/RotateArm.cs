using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{ 
    Vector2 target;
    Vector2 startPosition;
    public float movementSpeed;
    Vector2 direction;
    public int projectileDamage;

    void FixedUpdate()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition = transform.position;
        direction = (target - startPosition).normalized;
        float dotValue = Vector2.Dot(direction, Vector2.down);
        int rotateDirection = dotValue > 0 ? -1 : 1;
        float rotateAmount = Mathf.Acos(Vector2.Dot(Vector2.right, direction)) * 180 / Mathf.PI;
       // transform.Rotate(0, 0, rotateAmount * rotateDirection);
        transform.rotation = Quaternion.EulerRotation(0f, 0f, rotateAmount * rotateDirection);
        //transform.rotation =  new Vector3( 0f, 0f, rotateAmount * rotateDirection );
    }




}
