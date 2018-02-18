using UnityEngine;
using UnityEngine.UI;

public class DestructibleObject : MonoBehaviour
{
    float health;
    public int maxHealth;
    public Image healthbar;

    public GameObject[] itemsToDrop;


    void Awake()
    {
        health = maxHealth;
    }

    public void ApplyDamage(int amount)
    {
        health -= amount;
        healthbar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Death();
        }
    }

    public void ApplyDamageAsPercentage(float percentage)
    {
        health *= percentage;
    }

    public void DropItems()
    {
        foreach(GameObject item in itemsToDrop)
        {
            Instantiate(item, new Vector2(transform.position.x + Random.Range(1f, 2f), transform.position.y + Random.Range(1f, 2f)), transform.rotation);
        }
    }

    public void Death()
    {
        DropItems();
        Destroy(gameObject);
    }
}
