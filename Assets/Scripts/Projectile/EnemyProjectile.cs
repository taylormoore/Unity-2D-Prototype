using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public int projectileDamage;
    public GameObject hitEffect;

    public float movementSpeed;
    Vector2 movementDirection;
    Vector2 target;

    float hitEffectOffset = 0.5f;

    void Start()
    {
        movementDirection = transform.right;
    }

    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * movementSpeed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colliderTag = collision.gameObject.tag;
        if (colliderTag != "Enemy" && colliderTag != "GatherableResource" && colliderTag != "Projectile")
        {
            collision.gameObject.SendMessage("ApplyDamage", projectileDamage);
            Vector2 offset = (transform.position - collision.transform.position) * hitEffectOffset;
            Destroy(Instantiate(hitEffect, ((Vector2)collision.transform.position) + offset, collision.transform.rotation), 2f);
            Destroy(gameObject);
        }
    }
}
