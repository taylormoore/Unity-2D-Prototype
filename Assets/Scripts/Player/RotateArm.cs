using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    bool hasBeenFlipped = false;

    public static float currentArmRotation;
    public static Vector2 currentArmLocation;

    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        currentArmLocation = transform.position;
        
        currentArmRotation = Utility.RotationAmount(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(0f, 0f, currentArmRotation);

        if ( ( Utility.InSecondQuadrant(currentArmRotation) || Utility.InThirdQuadrant (currentArmRotation) ) && !hasBeenFlipped )
        {
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
            hasBeenFlipped = true;
        }
        else if ( ( ( Utility.InFirstQuadrant (currentArmRotation) ) || ( Utility.InFourthQuadrant (currentArmRotation) ) ) && hasBeenFlipped )
        {
            hasBeenFlipped = false;
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }
    }
}
