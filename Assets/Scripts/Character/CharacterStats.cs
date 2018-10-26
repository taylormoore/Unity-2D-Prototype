using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    float health;
    public int maxHealth;
    public Image healthbar;

    void Awake ()
    {
        health = maxHealth;

        // TODO: Find a better place to do this
        if (gameObject.tag == "Player" || gameObject.tag == "Player Interaction Collider")
        {
            PlayerManagement.AddPlayer ( gameObject.transform.gameObject );
        }

    }

    public void ApplyDamage ( int amount )
    {
        health -= amount;
        healthbar.fillAmount = health / maxHealth;

        if ( health <= 0 )
        {
            Death ();
        }
    }

    public void ApplyDamageAsPercentage(float percentage)
    {
        health *= percentage;
    }

    public void Death ()
    {
        Destroy ( gameObject );
    }
}
