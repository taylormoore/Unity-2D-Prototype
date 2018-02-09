using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;

    void Update ()
    {
		if ( Input.GetButtonDown("Fire1") )
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
	}
}
