using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour {

    public int health = 10;
    private int maxHealth = 10;
    public Image healthbar;

    public void ApplyDamage(int amount) {
        health -= amount;
        healthbar.fillAmount = (float)health / maxHealth;

        if (health <= 0) {
            Death();
        }
    }

    public void Death() {
        Destroy(gameObject);
    }
}
