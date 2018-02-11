using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject arms;

    void Update ()
    {
		if ( Input.GetButtonDown("Fire1") )
        {
            Instantiate(projectile, arms.transform.position, Quaternion.identity);
        }
	}
}
