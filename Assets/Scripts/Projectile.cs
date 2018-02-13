using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector2 target;
    Vector2 startPosition;
    public float movementSpeed;
    Vector2 movementDirection;
    public int projectileDamage;
    public GameObject hitEffect;
    public GameObject armLocation;

    float hitEffectOffset = 0.5f;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition );
        startPosition = RotateArm.currentArmLocation;

        // Rotate sprite
        transform.Rotate ( 0, 0, RotateArm.currentArmRotation );
        
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
            Vector2 offset = (transform.position - collision.transform.position) * hitEffectOffset;
            Destroy(Instantiate(hitEffect, ((Vector2)collision.transform.position) + offset, collision.transform.rotation), 2f);
            Destroy ( gameObject );
        }
    }

}
