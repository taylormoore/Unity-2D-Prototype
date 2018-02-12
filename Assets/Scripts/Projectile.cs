using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector2 target;
    Vector2 startPosition;
    public float movementSpeed;
    Vector2 movementDirection;
    public int projectileDamage;
    public GameObject hitEffect;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition );
        startPosition = transform.position;

        // Rotate sprite
        float rotateAmount = Utility.RotationAmount ( startPosition, target );
        transform.Rotate ( 0, 0, rotateAmount );
        
        // Get direction sprite should move
        movementDirection = ( target - startPosition ).normalized;
    }

    void Update ()
    {
        transform.Translate( movementDirection * Time.deltaTime * movementSpeed, Space.World);
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag == "Enemy" )
        {
            collision.gameObject.SendMessage ( "ApplyDamage", projectileDamage );
            Destroy(Instantiate(hitEffect, collision.transform.position, collision.transform.rotation), 2f);
            Destroy ( gameObject );
        }
    }

}
