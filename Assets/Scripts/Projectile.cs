using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    Vector2 target;
    Vector2 startPosition;
    public float movementSpeed;
    Vector2 direction;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startPosition = transform.position;
        direction = (target - startPosition).normalized;
        float dotValue = Vector2.Dot ( direction, Vector2.down );
        int rotateDirection = dotValue > 0 ? -1 : 1;
        float rotateAmount = Mathf.Acos ( Vector2.Dot ( Vector2.right, direction ) ) * 180 / Mathf.PI;
        transform.Rotate ( 0, 0, rotateAmount * rotateDirection );
    }

    void Update ()
    {
        transform.Translate(direction * Time.deltaTime * movementSpeed, Space.World);
    }

}
