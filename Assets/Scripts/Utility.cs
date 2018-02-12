using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour {

    /// <summary>
    /// Returns the amount A has to rotate to face B in degrees.
    /// </summary>
    public static float RotationAmount( Vector2 origin, Vector2 target )
    {
        return Mathf.Atan2 ( target.y - origin.y, target.x - origin.x ) * Mathf.Rad2Deg;
    }
}
