using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    GameObject currentWeapon;
    int weaponIndex = 0;

    float scrollCooldown = .1f;
    float lastScroll = 0f;

    private void Update()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if ( ( mouseScroll > 0f ) && Time.time > ( lastScroll + scrollCooldown ) )
        {
            lastScroll = Time.time;
            weapons[weaponIndex].SetActive(false);
            weaponIndex += 1;
            weaponIndex = Utility.Mod(weaponIndex, weapons.Length);
            weapons[weaponIndex].SetActive(true);
        }
        else if ( ( mouseScroll < 0f ) && Time.time > ( lastScroll + scrollCooldown ) )
        {
            lastScroll = Time.time;
            weapons[weaponIndex].SetActive(false);
            weaponIndex -= 1;
            weaponIndex = Utility.Mod(weaponIndex, weapons.Length);
            weapons[weaponIndex].SetActive(true);
        }
    }

}
