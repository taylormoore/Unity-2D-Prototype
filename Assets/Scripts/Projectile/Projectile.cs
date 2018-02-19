using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int projectileDamage;
    public GameObject hitEffect;
    
    public float movementSpeed;
    Vector2 movementDirection;

    float hitEffectOffset = 0.5f;

    void Start()
    {
        // Rotate sprite
        transform.Rotate ( 0, 0, RotateArm.currentArmRotation );

        // Now just move forward
        movementDirection = transform.right;
    }

    void Update ()
    {
        transform.Translate( movementDirection * Time.deltaTime * movementSpeed, Space.World);
    }

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.gameObject.tag != "Player" )
        {
            collision.gameObject.SendMessage ( "ApplyDamage", projectileDamage );
            Vector2 offset = (transform.position - collision.transform.position) * hitEffectOffset;
            Destroy(Instantiate(hitEffect, ((Vector2)collision.transform.position) + offset, collision.transform.rotation), 2f);
            Destroy ( gameObject );
        }
    }
}
