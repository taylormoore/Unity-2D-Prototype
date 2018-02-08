using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector2 target;
    Vector2 startPosition;
    public float movementSpeed;

    public GameObject marker;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(target, Vector2.up);
        startPosition = transform.position;
    }

    void Update ()
    {
        Vector2 direction = target - startPosition;
        direction = direction.normalized;
        transform.Translate(direction * Time.deltaTime * movementSpeed);
    }

}
