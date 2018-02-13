using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject bulletCasing;
    public GameObject projectileSpawn;
    public Sprite notFiringSprite;
    public Sprite firingSprite;
    public SpriteRenderer sprite;
    public Light muzzleFlash;

    void Update ()
    {
		if ( Input.GetButtonDown("Fire1") )
        {
            Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
            Instantiate(bulletCasing, new Vector3(projectileSpawn.transform.position.x - .5f, projectileSpawn.transform.position.y, projectileSpawn.transform.position.z), Quaternion.identity);
           
            StartCoroutine("FirePistol");
        }
	}

    IEnumerator FirePistol()
    {
        sprite.sprite = firingSprite;
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(.02f);
        sprite.sprite = notFiringSprite;
        muzzleFlash.enabled = false;
    }
}
